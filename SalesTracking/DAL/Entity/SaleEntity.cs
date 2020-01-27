namespace DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Sales")]
    public class SaleEntity : IIdentifier
    {
        public SaleEntity(DateTime date, UserEntity user, ICollection<ProductEntity> products, RecordFileEntity recordFile, decimal cost)
        {
            Date = date;
            User = user;
            Products = products;
            RecordFile = recordFile;
            Cost = cost;
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public UserEntity User { get; set; }

        public ICollection<ProductEntity> Products { get; set; }

        public RecordFileEntity RecordFile { get; set; }

        public decimal Cost { get; set; }

    }
}