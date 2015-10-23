namespace ValidataCodingTask
{
    using System;

    [Serializable]
    public class Phone
    {
        public Phone(string phoneNumber, PhoneType typeOfNumber)
        {
            this.PhoneNumber = phoneNumber;
            this.TypeOfNumber = typeOfNumber;
        }

        public string PhoneNumber { get; set; }

        public PhoneType TypeOfNumber { get; set; }
    }
}
