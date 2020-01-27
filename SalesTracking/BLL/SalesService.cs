namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using AutoMapper;

    using BLEntity;

    using BLL.Parser;

    using DAL.Entity;
    using DAL.Repositories;
    using DAL.Repositories.Interfaces;

    public class SalesService : IDisposable
    {
        private static readonly object productLocker = new object();
        private static readonly object userLocker = new object();

        private UnitOfWork repository;

        private ICSVParser parser;

        public SalesService(ICSVParser parser)
        {
            this.repository = new UnitOfWork();
            this.parser = parser;
        }

        public IList<int> CreateSales(string fileName)
        {
            var faultedStrings = new List<int>();
            if (!fileName.EndsWith(".csv"))
            {
                return faultedStrings;
            }

            var recordFile = GetRecordFile(fileName, repository.UserRepository);
            using (var streamReader = new StreamReader(fileName))
            {
                int i = 0;
                foreach (var items in parser.ParseCSV(streamReader))
                {
                    try
                    {
                        repository.SaleRepository.Create(CreateSale(items, recordFile));
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
                repository?.Dispose();
            }
        }

        private RecordFileEntity GetRecordFile(string fileName, IUserRepository repository)
        {
            try
            {
                var recordInfo = Path.GetFileNameWithoutExtension(fileName)?.Split('_');
                var user = new UserEntity(recordInfo?[0]);
                int userId;
                lock (userLocker)
                {
                    userId = repository.CreateOrUpdate(user, x => x.LastName == user.LastName);
                }

                var date = DateTime.ParseExact(recordInfo?[1], "ddMMyyyy", CultureInfo.InvariantCulture);

                return new RecordFileEntity(fileName, userId, date);
            }
            catch
            {
                throw new FormatException("Invalid file format.");
            }
        }

        private SaleEntity CreateSale(List<string> saleItems, RecordFileEntity recordFile)
        {
            repository.RecordFileRepository.Create(recordFile);

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
            lock (userLocker)
            {
                userId = repository.UserRepository.CreateOrUpdate(user, x => x.LastName == user.LastName);
            }

            var product = new ProductEntity(saleItems[2]);
            int productId;
            lock (productLocker)
            {
                productId = repository.ProductRepository.CreateOrUpdate(product, x => x.Name == product.Name);
            }

            return new SaleEntity(date, userId, productId, cost, recordFile.Id);
        }
    }
}