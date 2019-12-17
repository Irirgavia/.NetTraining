namespace ATSLibrary.AS
{
    public class Request : ICall
    {
        public Request(Number incomingNumber, Number outgoingNumber)
        {
            this.IncomingNumber = incomingNumber;
            this.OutgoingNumber = outgoingNumber;
        }

        public Number IncomingNumber { get; set; }

        public Number OutgoingNumber { get; set; }
    }
}