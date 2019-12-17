namespace ATSLibrary
{
    using System.Collections.Generic;

    using ATSLibrary.AS;

    public class BillingSystem
    {
        public BillingSystem(List<Station> stations, List<User> users)
        {
            this.Stations = stations;
            this.Users = users;
        }

        public List<Station> Stations { get; }

        public List<User> Users { get; }

        public void AddStation(Station station)
        {
            this.Stations.Add(station);
        }

        public void RemoveStation(Station station)
        {
            this.Stations.Remove(station);
        }

        public void AddUser(User user)
        {
            this.Users.Add(user);
        }

        public void RemoveUser(User user)
        {
            this.Users.Remove(user);
        }
    }
}