namespace ATSLibrary.AS
{
    public class Response : ICall
    {
        public Response(Number incomingNumber, Number outgoingNumber)
        {
            this.IncomingNumber = incomingNumber;
            this.OutgoingNumber = outgoingNumber;
        }

        public Number IncomingNumber { get; set; }

        public Number OutgoingNumber { get; set; }
    }
}