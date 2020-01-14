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
        private readonly object managerLocker = new object();
        private readonly object clientLocker = new object();

        public SalesService(ICSVParser parser)
        {
            Repository = new StorageRepository();
            Parser = parser;
        }

        private IStorageRepository Repository { get; }

        private ICSVParser Parser { get; }

        public List<int> CreateSales(string fileName)
        {
            List<int> faultedStrings = new List<int>();
            int i = 0;
            if (fileName.EndsWith(".csv"))
            {
                var sourceInfo = this.GetRecordFile(fileName, Repository.UserRepository);
                using (StreamReader sw = new StreamReader(fileName))
                {
                    var components = Parser.ParseCSV(sw);
                    foreach (var component in components)
                    {
                        try
                        {
                            var selling = this.CreateSale(component, sourceInfo);
                            Repository.SaleRepository.Create(selling);
                            i++;
                        }
                        catch (FormatException)
                        {
                            faultedStrings.Add(i);
                        }
                    }
                }
            }

            return faultedStrings;
        }

        public RecordFile GetRecordFile(string fileName, IUserRepository repository)
        {
            try
            {
                var parts = fileName.Split(new char[] { '\\', })
                    .ToList().Last().Split(new char[] { '_', '.' });
                var manager = new User(parts[0]);
                int managerId;
                lock (managerLocker)
                {
                    managerId = repository.CreateOrUpdate(manager, x => x.LastName == manager.LastName);
                }

                var date = new DateTime(
                    int.Parse(parts[1].Substring(4, 4)), 
                    int.Parse(parts[1].Substring(2, 2)), 
                    int.Parse(parts[1].Substring(0, 2)));

                return new RecordFile(fileName, managerId, date);
            }
            catch
            {
                throw new FormatException("File name has wrong format.");
            }
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

        private Sale CreateSale(List<string> components, RecordFile recordFile)
        {
            Repository.RecordFileRepository.Create(recordFile);
            DateTime date;
            decimal cost;
            if (!DateTime.TryParse(components[0], out date))
            {
                throw new FormatException("Date component has invalid format!");
            }
            if (!decimal.TryParse(components[3], out cost))
            {
                throw new FormatException("Cost component has invalid format!");
            }

            // Get user
            var names = components[1].Split(new char[] { ' ' });
            var user = names.Length > 1 ? new User(names[0], names[1]) : new User("", names[1]);

            int clientId;
            lock (clientLocker)
            {
                clientId = Repository.UserRepository.CreateOrUpdate(user, x => x.LastName == user.LastName);
            }

            // Get Product
            var product = new Product(components[2]);
            int productId;
            lock (productLocker)
            {
                productId = Repository.ProductRepository.CreateOrUpdate(product, x => x.Name == product.Name);
            }

            return new Sale(date, clientId, productId, cost, recordFile.Id);
        }
    }
}