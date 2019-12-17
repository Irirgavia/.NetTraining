namespace ATSLibrary.AS
{
    using System;
    using System.Collections.Generic;

    public class Terminal
    {
        public Terminal(int id, Number number)
        {
            this.Id = id;
            this.Number = number;
            this.IsConnect = true;
        }

        public event EventHandler<ICall> ICall;

        public int Id { get; }

        public Number Number { get; set; }

        public bool IsConnect { get; set; }

        public void Call(ICall call)
        {
            if (this.IsConnect)
            {
                this.ICall?.Invoke(this, call);
            }
            else
            {
                throw new Exception("Non-availability terminal.");
            }
        }

    }
}