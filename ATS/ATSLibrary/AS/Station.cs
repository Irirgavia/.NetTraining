namespace ATSLibrary.AS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public class Station
    {
        public Station(int id, List<Port> ports, List<Terminal> terminals)
        {
            this.Id = id;
            this.Ports = ports;
            this.Terminals = terminals;
            this.ActiveCallTimers = new List<CallTimer>();
            this.Histories = new List<History>();
        }

        public int Id { get; }

        public List<Port> Ports { get; }

        public Dictionary<Number, int> PortsMapping { get; set; }

        public List<Terminal> Terminals { get; }

        public List<CallTimer> ActiveCallTimers { get; }

        public List<History> Histories { get; }

        public void AddPort(int id)
        {
            if (!this.Ports.Exists(x => x.Id == id))
            {
                var port = new Port(id);
                this.RegisterEventHandlerForPort(port);
                this.Ports.Add(port);
            }
        }

        public void RemovePort(int id)
        {
            if (this.Ports.Exists(x => x.Id == id))
            {
                var port = this.Ports.FirstOrDefault(x => x.Id == id);
                this.UnregisterEventHandlerForPort(port);
                this.Ports.Remove(port);
            }
        }

        public void RegisterEventHandlerForPort(Port port)
        {
            port.Call += this.Request;
            port.Call += this.Responce;
        }

        public void UnregisterEventHandlerForPort(Port port)
        {
            port.Call -= this.Request;
            port.Call -= this.Responce;
        }

        public void RegisterEventHandlerForTerminal(Terminal terminal, Port port)
        {
            terminal.ICall += port.OnRequest;
            port.StateChanging(this, PortState.Busy);
        }

        public void UnregisterEventHandlerForTerminal(Terminal terminal, Port port)
        {
            terminal.ICall -= port.OnRequest;
            port.StateChanging(this, PortState.Free);
        }

        public void CheckNumber(Number number)
        {
            var terminal = this.GetTerminalByNumber(number);
            if (terminal == null)
            {
                throw new Exception($"Number {number} is outside the coverage area of the station.");
            }

            if (!terminal.IsConnect)
            {
                throw new Exception($"Number {number}  is not available.");
            }

            this.GetFreePort(terminal);
        }

        public void Request(object sender, ICall request)
        {
            var portIn = this.GetPortByNumber(request.IncomingNumber);
            if (portIn != null)
            {
                throw new Exception($"Subscriber {request.IncomingNumber} is Busy.");
            }

            var portOut = this.GetPortByNumber(request.OutgoingNumber);
            if (portOut != null)
            {
                throw new Exception($"Subscriber {request.OutgoingNumber} is Busy.");
            }

            this.CheckNumber(request.IncomingNumber);
            this.CheckNumber(request.OutgoingNumber);

            portIn.IncomingCall(request);
            portOut.IncomingCall(request);

            this.ActiveCallTimers.Add(new CallTimer(this.ActiveCallTimers.Count, request));
            this.ActiveCallTimers[this.ActiveCallTimers.Count - 1].Start();
        }

        public void Responce(object sender, ICall response)
        {
            this.GetCallTimerByCall(response).Stop();
            this.Histories.Add(new History(this.Histories.Count, GetCallTimerByCall(response), DateTime.Now));

            this.RemovePortListener(this.GetTerminalByNumber(response.OutgoingNumber));
            this.RemovePortListener(this.GetTerminalByNumber(response.IncomingNumber));
        }

        public CallTimer GetCallTimerByCall(ICall call)
        {
            return this.ActiveCallTimers.FirstOrDefault(x => x.Call == call);
        }

        public Terminal GetTerminalByNumber(Number number)
        {
            return this.Terminals.FirstOrDefault(x => x.Number == number);
        }

        public Port GetPortByNumber(Number number)
        {
            var portMapping = this.PortsMapping.FirstOrDefault(x => x.Key == number);
            if (portMapping.Equals(default(KeyValuePair<Number, int>)))
            {
                return null;
            }

            return this.Ports.FirstOrDefault(x => x.Id == portMapping.Value);
        }

        public void GetFreePort(Terminal terminal)
        {
            if (this.PortsMapping.ContainsKey(terminal.Number))
            {
                throw new Exception("The subscriber is temporarily unavailable, call back later.");
            }

            var port = this.Ports.FirstOrDefault(x => x.PortState == PortState.Free);
            if (port != null)
            {
                this.PortsMapping.Add(terminal.Number, port.Id);
                this.RegisterEventHandlerForTerminal(terminal, port);
            }
            else
            {
                throw new Exception("No ports available, line overloaded.");
            }
        }

        public void RemovePortListener(Terminal terminal)
        {
            var port = this.GetPortByNumber(terminal.Number);
            if (port != null)
            {
                this.PortsMapping.Remove(terminal.Number);
                this.UnregisterEventHandlerForTerminal(terminal, port);
            }
        }
    }
}