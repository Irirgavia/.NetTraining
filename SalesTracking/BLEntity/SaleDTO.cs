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

        public SaleDTO(DateTime date, UserDTO userDto, ICollection<ProductDTO> products, decimal cost, RecordFileDTO recordFileDto)
        {
            Date = date;
            this.UserDto = userDto;
            Products = products;
            this.RecordFileDto = recordFileDto;
            Cost = cost;
        }

        public int Id { get; }

        public DateTime Date { get; set; }

        public UserDTO UserDto { get; set; }

        public ICollection<ProductDTO> Products { get; set; }

        public RecordFileDTO RecordFileDto { get; set; }

        public decimal Cost { get; set; }
    }
}