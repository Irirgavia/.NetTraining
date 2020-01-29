namespace WebClient.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class UserModel
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect address")]
        public string Email { get; set; }
    }
}