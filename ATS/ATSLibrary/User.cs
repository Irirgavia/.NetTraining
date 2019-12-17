namespace ATSLibrary
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        public User()
        {

        }

        public int Id { get; }

        public List<Agreement> Agreements { get; }

        public void AddAgreement(Agreement agreement)
        {
            this.Agreements.Add(agreement);
        }

        public void RemoveAgreement(Agreement agreement)
        {
            this.Agreements.Remove(agreement);
        }
    }
}