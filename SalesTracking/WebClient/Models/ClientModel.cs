namespace WebClient.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ClientModel
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; }

        [Required]
        public UserModel User { get; set; }

        [Required]
        public CredentialsModel Credentials { get; set; }
    }
}