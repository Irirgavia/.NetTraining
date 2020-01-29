namespace DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
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
        
        [Key]
        public int Id { get; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public UserEntity User { get; set; }

        [Required]
        public ICollection<ProductEntity> Products { get; }

        [Required]
        public RecordFileEntity RecordFile { get; set; }

        [Required]
        public decimal Cost { get; set; }

    }
}