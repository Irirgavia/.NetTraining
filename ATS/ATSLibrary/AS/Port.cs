namespace ATSLibrary.AS
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public class Port
    {
        public Port(int id)
        {
            this.Id = id;
            this.PortState = PortState.Free;
            this.StateChange += this.StateChanging;
            this.Call += this.Calling;
        }

        public event EventHandler<ICall> Call;

        private event EventHandler<PortState> StateChange;

        public int Id { get; }

        public PortState PortState { get; set; }

        public ICall ICall { get; private set; }

        public void StateChanging(object sender, PortState portState)
        {
            this.PortState = portState;
        }

        public void Calling(object sender, ICall call)
        {
            this.ICall = call;
        }

        public void OnRequest(object sender, ICall e)
        {
            this.StateChange(this, PortState.Busy);

            this.ICall = new Request(e.IncomingNumber, e.OutgoingNumber);
            this.Call?.Invoke(this, this.ICall);
        }

        public void OnResponse(object sender, ICall e)
        {
            this.StateChange(this, PortState.Busy);

            this.ICall = new Response(e.IncomingNumber, e.OutgoingNumber);
            this.Call?.Invoke(this, this.ICall);
        }

        public void IncomingCall(ICall call)
        {
            this.Call(this, call);
        }
    }
}