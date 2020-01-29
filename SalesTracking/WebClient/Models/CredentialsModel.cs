namespace WebClient.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CredentialsModel
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}