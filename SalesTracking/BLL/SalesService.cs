namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    using AutoMapper;

    using BLEntity;

    using BLL.Parser;

    using DAL.Entity;
    using DAL.Repositories;
    using DAL.Repositories.Interfaces;

    public class SalesService : IDisposable
    {
        private static readonly object ProductLocker = new object();
        private static readonly object UserLocker = new object();

        private UnitOfWork unitOfWork;

        private ICSVParser parser;

        public SalesService(ICSVParser parser)
        {
            this.unitOfWork = new UnitOfWork();
            this.parser = parser;
            ObjectMapper = new ObjectMapper();
        }

        public ObjectMapper ObjectMapper { get; }

        public IEnumerable<SaleDTO> GetAllSales()
        {
            var sales = new List<SaleDTO>();
            foreach (var sale in unitOfWork.SaleRepository.GetAll())
            {
                sales.Add(ObjectMapper.ToBLO(sale));
            }

            return sales;
        }

        public SaleDTO GetSaleById(int saleId)
        {
            return ObjectMapper.ToBLO(unitOfWork.SaleRepository.FindById(saleId));
        }

        public UserDTO GetUserByLastName(string name)
        {
            return ObjectMapper.ToBLO(unitOfWork.UserRepository.FindByName(name));
        }

        public void UpdateSale(SaleDTO newSale)
        {
            unitOfWork.SaleRepository.Update(ObjectMapper.ToDLO(newSale));
            unitOfWork.SaveChanges();
        }

        public IList<int> CreateSales(string fileName)
        {
            var faultedStrings = new List<int>();
            if (!fileName.EndsWith(".csv"))
            {
                return faultedStrings;
            }

            var recordFile = ObjectMapper.ToDLO(GetRecordFile(fileName, unitOfWork.UserRepository));
            using (var streamReader = new StreamReader(fileName))
            {
                int i = 0;
                foreach (var items in parser.ParseCSV(streamReader))
                {
                    try
                    {
                        unitOfWork.SaleRepository.Create(ObjectMapper.ToDLO(CreateSale(items, recordFile)));
                        i++;
                    }
                    catch (FormatException)
                    {
                        faultedStrings.Add(i);
                    }
                }
            }

            return faultedStrings;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.unitOfWork?.Dispose();
            }
        }

        private RecordFileDTO GetRecordFile(string fileName, IUserSaleRepository repository)
        {
            try
            {
                var recordInfo = Path.GetFileNameWithoutExtension(fileName)?.Split('_');
                var user = new UserEntity(recordInfo?[0]);
                int userId;
                lock (UserLocker)
                {
                    userId = repository.CreateOrUpdate(user, x => x.LastName == user.LastName);
                }

                var date = DateTime.ParseExact(recordInfo?[1], "ddMMyyyy", CultureInfo.InvariantCulture);

                return new RecordFileDTO(fileName, ObjectMapper.ToBLO(user), date);
            }
            catch
            {
                throw new FormatException("Invalid file format.");
            }
        }

        private SaleDTO CreateSale(List<string> saleItems, RecordFileEntity recordFile)
        {
            this.unitOfWork.RecordFileRepository.Create(recordFile);

            if (!DateTime.TryParse(saleItems[0], out var date))
            {
                throw new FormatException("Invalid date format.");
            }

            if (!decimal.TryParse(saleItems[3], out var cost))
            {
                throw new FormatException("Invalid cost format.");
            }

            var userName = saleItems[1].Split(' ');
            var user = new UserEntity(userName[0], userName[1]);
            int userId;
            lock (UserLocker)
            {
                userId = unitOfWork.UserRepository.CreateOrUpdate(user, x => x.LastName == user.LastName);
            }

            var product = new ProductEntity(saleItems[2]);
            int productId;
            lock (ProductLocker)
            {
                productId = this.unitOfWork.ProductRepository.CreateOrUpdate(product, x => x.Name == product.Name);
            }

            var products = new List<ProductEntity>(){ product };
            var sale = new SaleEntity(date, user, products, recordFile, cost);
            return ObjectMapper.ToBLO(sale);
        }

        public void DeleteSale(int saleId)
        {
            var sale = unitOfWork.SaleRepository.FindById(saleId);
            if (sale == null)
            {
                throw new IndexOutOfRangeException("There is no such sale.");
            }

            unitOfWork.SaleRepository.Remove(sale);
            unitOfWork.SaveChanges();
        }
    }
}