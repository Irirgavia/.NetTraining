namespace BLEntity
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SaleDTO : IIdentifier
    {
        public SaleDTO()
        {
        }

        public SaleDTO(DateTime date, UserDTO user, ICollection<ProductDTO> products, decimal cost, RecordFileDTO recordFile)
        {
            Date = date;
            User = user;
            Products = products;
            RecordFile = recordFile;
            Cost = cost;
        }

        public int Id { get; }

        public DateTime Date { get; set; }

        public UserDTO User { get; set; }

        public ICollection<ProductDTO> Products { get; set; }

        public RecordFileDTO RecordFile { get; set; }

        public decimal Cost { get; set; }
    }
}