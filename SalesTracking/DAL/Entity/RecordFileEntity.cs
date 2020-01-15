namespace DAL.Entity
{
    using System;

    public class RecordFileEntity : IIdentifier
    {
        public RecordFileEntity(string fileName, int managerId, DateTime date)
        {
            FileName = fileName;
            ManagerId = managerId;
            Date = date;
        }

        public int Id { get; set; }

        public string FileName { get; set; }

        public int ManagerId { get; set; }

        public DateTime Date { get; set; }
    }
}