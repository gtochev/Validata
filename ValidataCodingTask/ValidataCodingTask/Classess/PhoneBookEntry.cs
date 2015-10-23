namespace ValidataCodingTask
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class PhoneBookEntry
    {
        public PhoneBookEntry(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ListOfPhones = new List<Phone>();
        }

        public PhoneBookEntry(string firstName, string lastName, PhoneType typeOfPhone, string phoneNumber)
            : this(firstName, lastName)
        {
            this.ListOfPhones.Add(new Phone(phoneNumber, typeOfPhone));
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Phone> ListOfPhones { get; set; }

    }
}
