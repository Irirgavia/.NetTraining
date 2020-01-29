namespace DAL.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Records")]
    public class RecordFileEntity : IIdentifier
    {
        public RecordFileEntity(string fileName, UserEntity user, DateTime date)
        {
            FileName = fileName;
            User = user;
            Date = date;
        }

        [Key]
        public int Id { get; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public UserEntity User { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}