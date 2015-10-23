// IPhoneBook.cs
// compile with: /doc:IPhoneBook.xml

namespace ValidataCodingTask
{
    

    using System.Collections.Generic;
    /// <summary>
    /// Creates Phone book
    /// </summary>
    public interface IPhoneBook
    {
        /// <summary>
        /// Creates Phone Book entry
        /// </summary>
        /// <param name="firstName">First name of the user</param>
        /// <param name="lastName">Last name of the user</param>
        /// <returns>New Phone Book entry</returns>
        PhoneBookEntry CreatePhoneBookEntry(string firstName, string lastName);

        /// <summary>
        /// Creates Phone Book entry
        /// </summary>
        /// <param name="firstName">First name of the user</param>
        /// <param name="lastName">Last name of the user</param>
        /// <param name="typeOfPhone">Type of phone</param>
        /// <param name="number">Phone number</param>
        /// <returns>New Phone Book entry</returns>
        PhoneBookEntry CreatePhoneBookEntry(string firstName, string lastName, PhoneType typeOfPhone, string number);

        /// <summary>
        /// Adds new phone number to a user
        /// </summary>
        /// <param name="firstName">First name of the user</param>
        /// <param name="lastName">Last name of the user</param>
        /// <param name="typeOfPhone">Type of phone</param>
        /// <param name="number">Phone number</param>
        void AddPhoneToUser(string firstName, string lastName, PhoneType typeOfPhone, string number);

        /// <summary>
        /// Deletes phone number from selected user
        /// </summary>
        /// <param name="firstName">First name of the user</param>
        /// <param name="lastName">Last name of the user</param>
        /// <param name="number">Phone number to delete</param>
        void DeletePhoneFromUser(string firstName, string lastName, string number);

        /// <summary>
        /// Deletes user, selected by first and last name
        /// </summary>
        /// <param name="firstName">First name of the user</param>
        /// <param name="lastName">Last name of the user</param>
        void DeleteEntryByFirstAndLastName(string firstName, string lastName);

        /// <summary>
        /// Edits either of the names of the user
        /// </summary>
        /// <param name="firstName">First name of the user</param>
        /// <param name="lastName">Last name of the user</param>
        /// <param name="newFirstName">Enter new first name of the user or the old if it doesn't need to be changed</param>
        /// <param name="newLastName">Enter new last name of the user or the old if it doesn't need to be changed</param>
        void EditeUserName(string firstName, string lastName, string newFirstName, string newLastName);

        /// <summary>
        /// Edits the phone number of the user
        /// </summary>
        /// <param name="firstName">First name of the user</param>
        /// <param name="lastName">Last name of the user</param>
        /// <param name="typeOfPhone">Type of phone</param>
        /// <param name="number">Phone number</param>
        /// <param name="newTypeOfPhone">Enter new type of phone number or the old if it doesn't need to be changed</param>
        /// <param name="newNumber">Enter new phone number or the old if it doesn't need to be changed</param>
        void EditPhoneNumber(string firstName, string lastName, PhoneType typeOfPhone, string number, PhoneType newTypeOfPhone, string newNumber);

        /// <summary>
        /// Sorts the entries in the phone book, alphabeticly by first name
        /// </summary>
        /// <returns>The new sorted list</returns>
        List<PhoneBookEntry> GetPhoneBookEntriesSortedByFirstName();

        /// <summary>
        /// Sorts the entries in the phone book, alphabeticly by last name
        /// </summary>
        /// <returns>The new sorted list</returns>
        List<PhoneBookEntry> GetPhoneBookEntriesSortedByLastName();
    }
}
