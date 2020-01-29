namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

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
        }

        public IList<int> CreateSales(string fileName)
        {
            var faultedStrings = new List<int>();
            if (!fileName.EndsWith(".csv"))
            {
                return faultedStrings;
            }

            var recordFile = GetRecordFile(fileName, unitOfWork.UserRepository);
            using (var streamReader = new StreamReader(fileName))
            {
                int i = 0;
                foreach (var items in parser.ParseCSV(streamReader))
                {
                    try
                    {
                        this.unitOfWork.SaleRepository.Create(CreateSale(items, recordFile));
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

        private RecordFileEntity GetRecordFile(string fileName, IUserSaleRepository repository)
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

                return new RecordFileEntity(fileName, user, date);
            }
            catch
            {
                throw new FormatException("Invalid file format.");
            }
        }

        private SaleEntity CreateSale(List<string> saleItems, RecordFileEntity recordFile)
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
            return new SaleEntity(date, user, products, recordFile, cost);
        }
    }
}