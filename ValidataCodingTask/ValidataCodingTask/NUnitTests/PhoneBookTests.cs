using System;
using NUnit.Framework;

namespace ValidataCodingTask
{
    [TestFixture]
    class PhoneBookTests
    {
        [Test]
        public void CreatePhoneBookEntryTest()
        {
            IPhoneBook fixture = new PhoneBook();
            var gosho = fixture.CreatePhoneBookEntry("Gosho", "Goshov");
            Assert.AreEqual("Gosho", gosho.FirstName);
            Assert.AreEqual("Goshov", gosho.LastName);
        }

        [Test,ExpectedException(typeof(ArgumentNullException))]
        public void CreatePhoneBookEntryNullFirstNameTest()
        {
            IPhoneBook fixture = new PhoneBook();
            var gosho = fixture.CreatePhoneBookEntry(null, "Goshov");
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void CreatePhoneBookEntryNullLastNameTest()
        {
            IPhoneBook fixture = new PhoneBook();
            var gosho = fixture.CreatePhoneBookEntry("Gosho", null);
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void CreatePhoneBookDupliacteEntryTest()
        {
            IPhoneBook fixture = new PhoneBook();
            var firstUser = fixture.CreatePhoneBookEntry("Gosho", "Goshov");

            var secondUser = fixture.CreatePhoneBookEntry("Gosho", "Goshov");
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void DeleteEntryByFirstAndLastNameTest()
        {
            IPhoneBook fixture = new PhoneBook();
            fixture.DeleteEntryByFirstAndLastName("Gosho", "Goshov");
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void AddPhoneToUserTest()
        {
            IPhoneBook fixture = new PhoneBook();
            var firstUser = fixture.CreatePhoneBookEntry("Gosho", "Goshov", PhoneType.Cellphone, "0888");
            fixture.AddPhoneToUser("Gosho", "Goshov", PhoneType.Cellphone, "0888");
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void DeletePhoneFromUserTest()
        {
            IPhoneBook fixture = new PhoneBook();
            var firstUser = fixture.CreatePhoneBookEntry("Gosho", "Goshov", PhoneType.Cellphone, "0888");
            fixture.DeletePhoneFromUser("Gosho", "Ivanov", "0888");
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void EditeUserNameTest()
        {
            IPhoneBook fixture = new PhoneBook();
            var firstUser = fixture.CreatePhoneBookEntry("Gosho", "Goshov");
            fixture.EditeUserName("Gosho", "ivanov", "Ivan", "Goshov");
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void EditPhoneNumberTest()
        {
            IPhoneBook fixture = new PhoneBook();
            var firstUser = fixture.CreatePhoneBookEntry("Gosho", "Goshov", PhoneType.Cellphone, "0888");
            fixture.EditPhoneNumber("Gosho", "Goshov", PhoneType.Cellphone, "0888", PhoneType.Cellphone, "0888");
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void EditPhoneNumberUserTest()
        {
            IPhoneBook fixture = new PhoneBook();
            var firstUser = fixture.CreatePhoneBookEntry("Gosho", "Goshov", PhoneType.Cellphone, "0888");
            fixture.EditPhoneNumber("Gosho", "Ivanov", PhoneType.Cellphone, "0888", PhoneType.Cellphone, "0999");
        }
    }
}
