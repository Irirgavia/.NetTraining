namespace ATSLibrary
{
    using System;
    using System.Data;

    using ATSLibrary.AS;

    public class History
    {
        public History(int id, CallTimer callTimer, DateTime dateTime)
        {
            this.Id = id;
            this.CallTimer = callTimer;
            this.DateTime = dateTime;
        }

        public int Id { get; }

        public CallTimer CallTimer { get; set; }

        public DateTime DateTime { get; set; }
    }
}