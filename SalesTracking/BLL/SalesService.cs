namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using BLEntity;

    using BLL.Parser;

    using DAL.Repositories;
    using DAL.Repositories.Interfaces;

    public class SalesService : IDisposable
    {
        private readonly object productLocker = new object();
        private readonly object userLocker = new object();

        public SalesService(ICSVParser parser)
        {
            Repository = new StorageRepository();
            Parser = parser;
        }

        private IStorageRepository Repository { get; }

        private ICSVParser Parser { get; }

        public List<int> CreateSales(string fileName)
        {
            var faultedStrings = new List<int>();
            if (!fileName.EndsWith(".csv"))
            {
                return faultedStrings;
            }

            var recordFile = GetRecordFile(fileName, Repository.UserRepository);
            using (var streamReader = new StreamReader(fileName))
            {
                int i = 0;
                foreach (var items in Parser.ParseCSV(streamReader))
                {
                    try
                    {
                        Repository.SaleRepository.Create(CreateSale(items, recordFile));
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
                this.Repository?.Dispose();
            }
        }

        private RecordFile GetRecordFile(string fileName, IUserRepository repository)
        {
            try
            {
                var recordInfo = fileName
                    .Split(new char[] { '\\', }).ToList().Last()
                    .Split(new char[] { '_', '.' });
                var user = new User(recordInfo[0]);
                int userId;
                lock (userLocker)
                {
                    userId = repository.CreateOrUpdate(user, x => x.LastName == user.LastName);
                }

                var date = new DateTime(
                    int.Parse(recordInfo[1].Substring(4, 4)),
                    int.Parse(recordInfo[1].Substring(2, 2)),
                    int.Parse(recordInfo[1].Substring(0, 2)));

                return new RecordFile(fileName, userId, date);
            }
            catch
            {
                throw new FormatException("Invalid file format.");
            }
        }

        private Sale CreateSale(List<string> saleItems, RecordFile recordFile)
        {
            Repository.RecordFileRepository.Create(recordFile);

            if (!DateTime.TryParse(saleItems[0], out var date))
            {
                throw new FormatException("Invalid date format.");
            }

            if (!decimal.TryParse(saleItems[3], out var cost))
            {
                throw new FormatException("Invalid cost format.");
            }

            var userName = saleItems[1].Split(new char[] { ' ' });
            var user = new User(userName[0], userName[1]);
            int userId;
            lock (userLocker)
            {
                userId = Repository.UserRepository.CreateOrUpdate(user, x => x.LastName == user.LastName);
            }

            var product = new Product(saleItems[2]);
            int productId;
            lock (productLocker)
            {
                productId = Repository.ProductRepository.CreateOrUpdate(product, x => x.Name == product.Name);
            }

            return new Sale(date, userId, productId, cost, recordFile.Id);
        }
    }
}