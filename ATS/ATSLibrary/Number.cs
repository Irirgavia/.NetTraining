namespace ATSLibrary
{
    using System.Collections.Generic;

    public class Number
    {
        public Number(int id, string subscriberNumber)
        {
            this.Id = id;
            this.SubscriberNumber = subscriberNumber;
        }

        public int Id { get; }

        public string SubscriberNumber { get; set; }
    }
}