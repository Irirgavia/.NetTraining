namespace ATSLibrary.AS
{
    using System;

    public class CallTimer
    {
        public CallTimer(int id, ICall call)
        {
            this.Id = id;
            this.Call = call;
        }

        public int Id { get; }

        public TimeSpan Duration { get; set; }

        public ICall Call { get; }

        public void Start()
        {
            // start thread for call
        }

        public void Stop()
        {
            // stop thread for call
            var random = new Random();
            this.Duration = new TimeSpan(random.Next(0, 59));
        }
    }
}