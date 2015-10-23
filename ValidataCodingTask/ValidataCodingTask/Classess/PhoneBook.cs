namespace ValidataCodingTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Serializable]
    public class PhoneBook : IPhoneBook
    {
        public PhoneBook()
        {
            this.ListOfAddedEntries = new List<PhoneBookEntry>();
        }

        public List<PhoneBookEntry> ListOfAddedEntries { get; set; }

        // Interface methods implementation

        public PhoneBookEntry CreatePhoneBookEntry(string firstName, string lastName)
        {
            if (firstName == null || lastName == null)
            {
                throw new System.ArgumentNullException("No name entered!");
            }

            int index = LocateUser(ListOfAddedEntries, firstName, lastName);

            if (index >= 0)
            {
                throw new System.ArgumentException("This user already exists!");
            }
            
            PhoneBookEntry newUser = new PhoneBookEntry(firstName, lastName);
            this.ListOfAddedEntries.Add(newUser);
            return newUser;
        }

        public PhoneBookEntry CreatePhoneBookEntry(string firstName, string lastName, PhoneType typeOfPhone, string number)
        {
            int index = LocateUser(ListOfAddedEntries, firstName, lastName);

            if (index >= 0)
            {
                throw new System.ArgumentException("This user already exists!");
            }
            if (firstName.Length <= 1)
            {
                throw new System.ArgumentException("The name is too short!");
            }

            PhoneBookEntry newUser = new PhoneBookEntry(firstName, lastName, typeOfPhone, number);
            this.ListOfAddedEntries.Add(newUser);
            return newUser;
        }

        public void DeleteEntryByFirstAndLastName(string firstName, string lastName)
        {
            int index = LocateUser(ListOfAddedEntries, firstName, lastName);
            if (index <= 0)
            {
                throw new ArgumentException("The provided user does not exist!");
            }
            ListOfAddedEntries.RemoveAt(index);
        }

        public void AddPhoneToUser(string firstName, string lastName, PhoneType typeOfPhone, string number)
        {
            foreach (var user in ListOfAddedEntries)
            {
                foreach (var phone in user.ListOfPhones)
                {
                    if (number == phone.PhoneNumber)
                    {
                        throw new System.ArgumentException("Theis phone entry already exists!");
                    }
                }
            }
            int index = LocateUser(ListOfAddedEntries, firstName, lastName);
            ListOfAddedEntries[index].ListOfPhones.Add(new Phone(number, typeOfPhone));
        }


        public void DeletePhoneFromUser(string firstName, string lastName, string number)
        {
            int userIndex = LocateUser(ListOfAddedEntries, firstName, lastName);

            if (userIndex <= 0)
            {
                throw new ArgumentException("The provided user does not exist!");
            }

            int phoneIndex = -1;
            
            foreach (var item in ListOfAddedEntries[userIndex].ListOfPhones)
            {
                if (item.PhoneNumber == number)
                {
                    phoneIndex = ListOfAddedEntries[userIndex].ListOfPhones.IndexOf(item);
                }
            }
            //TODO - Check if phone exists
            ListOfAddedEntries[userIndex].ListOfPhones.RemoveAt(phoneIndex);
        }

        public void EditeUserName(string firstName, string lastName, string newFirstName, string newLastName)
        {
            int index = LocateUser(ListOfAddedEntries, firstName, lastName);

            if (index <= 0)
            {
                throw new ArgumentException("The provided user does not exist!");
            }

            ListOfAddedEntries[index].FirstName = newFirstName;
            ListOfAddedEntries[index].LastName = newLastName;
        }

        public void EditPhoneNumber(string firstName, string lastName, PhoneType typeOfPhone, string number, PhoneType newTypeOfPhone, string newNumber)
        {
            foreach (var user in ListOfAddedEntries)
            {
                foreach (var phone in user.ListOfPhones)
                {
                    if (newNumber == phone.PhoneNumber && newTypeOfPhone == phone.TypeOfNumber)
                    {
                        throw new System.ArgumentException("This phone entry already exists!");
                    }
                }
            }

            int userIndex = LocateUser(ListOfAddedEntries, firstName, lastName);

            if (userIndex <= 0)
            {
                throw new ArgumentException("The provided user does not exist!");
            }

            int phoneIndex = -1;

            foreach (var item in ListOfAddedEntries[userIndex].ListOfPhones)
            {
                if (item.PhoneNumber == number)
                {
                    phoneIndex = ListOfAddedEntries[userIndex].ListOfPhones.IndexOf(item);
                }
            }
            
            ListOfAddedEntries[userIndex].ListOfPhones[phoneIndex].PhoneNumber = newNumber;
            ListOfAddedEntries[userIndex].ListOfPhones[phoneIndex].TypeOfNumber = newTypeOfPhone;
        }

        public List<PhoneBookEntry> GetPhoneBookEntriesSortedByFirstName()
        {
            List<PhoneBookEntry> sortedList = this.ListOfAddedEntries.OrderBy(o => o.FirstName).ToList();
            ListOfAddedEntries = sortedList;
            return ListOfAddedEntries;
        }

        public List<PhoneBookEntry> GetPhoneBookEntriesSortedByLastName()
        {
            List<PhoneBookEntry> sortedList = this.ListOfAddedEntries.OrderBy(o => o.LastName).ToList();
            ListOfAddedEntries = sortedList;
            return ListOfAddedEntries;
        }


        //----
        private int LocateUser(List<PhoneBookEntry> list, string firstName, string lastName)
        {
            int userIndex = -1;

            foreach (var item in ListOfAddedEntries)
            {
                if (item.FirstName == firstName && item.LastName == lastName)
                {
                    userIndex = ListOfAddedEntries.IndexOf(item);
                }
            }
            return userIndex;           
        }
        //----
    }
}
