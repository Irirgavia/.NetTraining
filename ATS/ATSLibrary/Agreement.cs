namespace ATSLibrary
{
    using System.Collections.Generic;

    public class Agreement
    {
        public Agreement(int id, Number number, Tariff tariff, string description)
        {
            this.Id = id;
            this.Number = number;
            this.Tariff = tariff;
            this.Description = description;
            this.Histories = new List<History>();
        }

        public int Id { get; }

        public Number Number { get; set; }

        public Tariff Tariff { get; set; }

        public string Description { get; set; }

        public List<History> Histories { get; }

        public void AddHistory(History history)
        {
            this.Histories.Add(history);
        }

        public void RemoveHistory(History history)
        {
            this.Histories.Remove(history);
        }
    }
}