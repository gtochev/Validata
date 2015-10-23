namespace ValidataCodingTask
{
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    public class PhoneBookCreator
    {
        public IPhoneBook CreateNewPhoneBook()
        {
            return new PhoneBook();
        }

        public void SavePhoneBook(string filePathAndFileName, IPhoneBook book)
        {
            System.Runtime.Serialization.IFormatter formatter = new BinaryFormatter();

            Stream stream = new FileStream(filePathAndFileName,
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, book);
            stream.Close();
        }

        public IPhoneBook LoadPhoneBook(string filePathAndFileName)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePathAndFileName,
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
            IPhoneBook book = (IPhoneBook)formatter.Deserialize(stream);
            stream.Close();
            return book;
        }
    }
}
