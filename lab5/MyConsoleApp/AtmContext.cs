using System;
using AtmStatePattern.States;

namespace AtmStatePattern
{
    public class AtmContext
    {
        public string ID { get; }
        public decimal Cash { get; set; }
        public double ConnectionLossProbability { get; }
        public bool IsConnected { get; set; }
        public bool IsAuthenticated { get; set; } = false;

        public IAtmState State { get; set; }

        public AtmContext(string id, decimal cash, double connectionLossProbability)
        {
            ID = id;
            Cash = cash;
            ConnectionLossProbability = connectionLossProbability;
            State = new WaitingState();
            IsConnected = true;
        }

        public void EnterPin(string pin) => State.EnterPin(this, pin);
        public void Withdraw(decimal amount) => State.Withdraw(this, amount);
        public void Finish() => State.Finish(this);
        public void LoadCash(decimal amount) => State.LoadCash(this, amount);

        public void CheckConnection()
        {
            var rnd = new Random();
            IsConnected = rnd.NextDouble() > ConnectionLossProbability;
            if (!IsConnected)
                State = new BlockedState();
        }
    }
}
