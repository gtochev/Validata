namespace ValidataCodingTask
{
    using NUnit.Framework;
    using System.IO;

    [TestFixture]
    class PhoneBookCreatorTests
    {
        [Test]
        public void CreateNewPhoneBookTest()
        {
            PhoneBookCreator creator = new PhoneBookCreator();

            var book = creator.CreateNewPhoneBook();

            Assert.IsInstanceOf(typeof(PhoneBook), book);
            Assert.IsEmpty(book.GetPhoneBookEntriesSortedByFirstName());
        }

        [Test]
        public void SavePhoneBookTest()
        {
            PhoneBookCreator creator = new PhoneBookCreator();
            IPhoneBook book = creator.CreateNewPhoneBook();

            string filePath = "File.bin";

            book.CreatePhoneBookEntry("Gosho", "Goshov");

            Assert.IsFalse(File.Exists(filePath));

            creator.SavePhoneBook(filePath, book);

            Assert.IsTrue(File.Exists(filePath));

            IPhoneBook loadingBook = creator.LoadPhoneBook(filePath);

            Assert.IsNotEmpty(loadingBook.GetPhoneBookEntriesSortedByFirstName());

            Assert.IsTrue(loadingBook.GetPhoneBookEntriesSortedByFirstName().Count == 1);

            Assert.AreEqual("Gosho", loadingBook.GetPhoneBookEntriesSortedByFirstName()[0].FirstName);

            File.Delete(filePath);
        }
    }
}
