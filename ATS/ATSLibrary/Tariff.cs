namespace ATSLibrary
{
    public class Tariff
    {
        public Tariff(int id, string name, int minuteCost)
        {
            this.Id = id;
            this.Name = name;
            this.MinuteCost = minuteCost;
        }

        public int Id { get; }

        public string Name { get; set; }

        public int MinuteCost { get; set; }
    }
}