namespace BLEntity
{
    using System;

    public class RecordFileDTO : IIdentifier
    {
        public RecordFileDTO()
        {
        }

        public RecordFileDTO(string fileName, UserDTO userDto, DateTime date)
        {
            FileName = fileName;
            this.UserDto = userDto;
            Date = date;
        }

        public int Id { get; set; }

        public string FileName { get; set; }

        public UserDTO UserDto { get; set; }

        public DateTime Date { get; set; }
    }
}