namespace WebClient.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class SaleModel
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public UserModel User { get; set; }

        [Required]
        [UIHint("Collection")]
        public ICollection<string> Products { get; set; }

        [Required]
        [UIHint("Decimal")]
        [Range(typeof(decimal), "0.00", "999999999.00")]
        public decimal Cost { get; set; }
    }
}