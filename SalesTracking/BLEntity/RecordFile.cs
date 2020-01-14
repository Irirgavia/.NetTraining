namespace BLEntity
{
    using System;

    public class RecordFile : IIdentifier
    {
        public RecordFile()
        {
        }

        public RecordFile(string fileName, int managerId, DateTime date)
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