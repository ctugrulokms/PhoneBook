using System;

namespace phone_book
{
    class Contact
    {
        private string name;
        private string surname;
        private long phoneNum;
        public static List<Contact> Contacts;
        public Contact(string name, string surname, long phoneNum)
        {
            this.Name = name;
            this.Surname = surname;
            this.PhoneNum = phoneNum;
        }

        static Contact()
        {
            Contacts = new List<Contact>();
            Contacts.Add(new Contact("Caspar", "Sutton", 4837596732));
            Contacts.Add(new Contact("Ember", "Jackson", 5746385647));
            Contacts.Add(new Contact("Safiya", "Woodcock", 3217586732));
            Contacts.Add(new Contact("Amy-Leigh", "Portillo", 9853647825));
            Contacts.Add(new Contact("Axel", "Kim", 3765429574));
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public long PhoneNum { get => phoneNum; set => phoneNum = value; }
    }
}