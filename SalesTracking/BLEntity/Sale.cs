namespace BLEntity
{
    using System;

    public class Sale : IIdentifier
    {
        public Sale()
        {
        }

        public Sale(DateTime date, int clienId, int productId, decimal cost, int recordFileId)
        {
            Date = date;
            ClientId = clienId;
            ProductId = productId;
            RecordFileId = recordFileId;
            Cost = cost;
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int ClientId { get; set; }

        public int ProductId { get; set; }

        public int RecordFileId { get; set; }

        public decimal Cost { get; set; }

    }
}