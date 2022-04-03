namespace phone_book
{
    class TaskManager
    {
        public static void AddContact()
        {
            Console.WriteLine("Lütfen isim giriniz              :");
            string name = CheckAndReadLine();

            Console.WriteLine("Lütfen soyisim giriniz           :");
            string surname = CheckAndReadLine();

            Console.WriteLine("Lütfen telefon numarası giriniz  :");
            long phoneNum = EnterPhoneNumber();

            Contact.Contacts.Add(new Contact(name, surname, phoneNum));
        }

        public static void DeleteContact()
        {
            Contact? tempContact = null;
            string nameOrSurname;
            bool defined = false;
            int selection;

            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");

            nameOrSurname = CheckAndReadLine();

            foreach(Contact contact in Contact.Contacts)
            {
                if(contact.Name == nameOrSurname || contact.Surname == nameOrSurname)
                {
                    tempContact = contact;
                    defined = true;
                    break;
                }
            }

            if(!defined)
            {
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız. ");
                Console.WriteLine("* Silmeyi sonlandırmak için  : (1)");
                Console.WriteLine("* Yeniden denemek için       : (2)");

                selection = int.Parse(CheckAndReadLine());

                switch (selection)
                {
                    case 1:
                        break;
                    case 2:
                        DeleteContact();
                        break;
                }

            }
            else
            { 
                Console.WriteLine("{0} {1} isimli kişi rehberden silinmek üzere, onaylıyor musunuz?(y/n)", tempContact.Name, tempContact.Surname);

                string choice = CheckAndReadLine();

                if(choice.Equals("y") ||   choice.Equals("y".ToUpper()))
                {
                    Contact.Contacts.Remove(tempContact);
                    Console.WriteLine("Rehberden silme işlemi tamamlandı.");
                }
                else if(choice.Equals("n") || choice.Equals("n".ToUpper()))
                {
                    Console.WriteLine("Rehberden silme işlemi durduruldu.");
                }
            
            }

        }

        public static void UpdateContact()
        {
            List<Contact> sameValues = new List<Contact>();
            Contact? tempContact = null;
            string nameOrSurname;
            int selection;

            Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");

            nameOrSurname = CheckAndReadLine();

            foreach(Contact contact in Contact.Contacts)
            {
                if(contact.Name == nameOrSurname || contact.Surname == nameOrSurname)
                {
                    tempContact = contact;
                    sameValues.Add(tempContact);
                }
                    
            }

            foreach (Contact contact in sameValues)
            {
                if(sameValues.Count > 1)
                    sameValues.Remove(contact);
            }

            if(sameValues.Count == 0)
            {
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız. ");
                Console.WriteLine("* Güncellemeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için           : (2)");

                selection = int.Parse(CheckAndReadLine());

                switch (selection)
                {
                    case 1:
                        break;
                    case 2:
                        UpdateContact();
                        break;
                }
            }
            else
            {
                int updateIndex = Contact.Contacts.IndexOf(tempContact);

                Console.WriteLine("Lütfen değiştirilecek yeni numarayı yazınız.");

                Contact.Contacts[updateIndex].PhoneNum = EnterPhoneNumber();

                Console.WriteLine("{0} adlı kişinin numarası {1} olarak değiştirildi.", Contact.Contacts[updateIndex].Name + " " + Contact.Contacts[updateIndex].Surname, Contact.Contacts[updateIndex].PhoneNum);
            }
        }

        public static void ListPhoneBook()
        {
            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("******************************");
            foreach(Contact contact in Contact.Contacts)
            {
                Console.WriteLine("-");
                Console.WriteLine("İsim: " + contact.Name);
                Console.WriteLine("Soyisim: " + contact.Surname);
                Console.WriteLine("Telefon Numarası: " + contact.PhoneNum);
            }
            Console.WriteLine("******************************");
        }
        public static void Search()
        {
            int selection;

            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
            Console.WriteLine("******************************");
            Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");

            selection = int.Parse(CheckAndReadLine());

            switch (selection)
            {
                case 1:
                    Console.WriteLine("Lütfen numarasını bulmak istediğiniz kişinin adını ya da soyadını giriniz.");
                    string nameOrSurname = CheckAndReadLine();
                    
                    Console.WriteLine("Arama Sonuçlarınız:");
                    Console.WriteLine("******************************");

                    foreach (Contact contact in Contact.Contacts)
                    {
                        if(contact.Name.Equals(nameOrSurname) || contact.Surname.Equals(nameOrSurname))       
                            ListSearchResults(contact);
                    }
                    break;
                case 2:
                    Console.WriteLine("Lütfen numarasını bulmak istediğiniz kişinin telefon numarasını giriniz.");
                    long number = EnterPhoneNumber();

                    Console.WriteLine("Arama Sonuçlarınız:");
                    Console.WriteLine("******************************");

                    foreach (Contact contact in Contact.Contacts)
                    {
                        if(contact.PhoneNum.Equals(number))
                            ListSearchResults(contact);
                    }
                    break;
            }
        }
        
        public static void ListSearchResults(Contact contact)
        {
            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("******************************");
            
            Console.WriteLine("-");
            Console.WriteLine("İsim: " + contact.Name);
            Console.WriteLine("Soyisim: " + contact.Surname);
            Console.WriteLine("Telefon Numarası: " + contact.PhoneNum);
            
            Console.WriteLine("******************************");
        }
        public static string CheckAndReadLine()
        {
            string input = Console.ReadLine()!;

            if(input.Equals(null))
            {
                Console.WriteLine("Boş bir değer giremezsiniz. Tekrar deneyiniz.");
                input = Console.ReadLine()!;
            }

            return input;
        }

        public static long EnterPhoneNumber()
        {
            string phoneNumber = CheckAndReadLine();
            bool allowed = long.TryParse(phoneNumber, out long phoneNum) && phoneNumber.Length == 10;

            while(!allowed)
            {
                if(phoneNumber.Length != 10)
                    Console.WriteLine("Girdiğiniz değer, telefon numarası için uygun değildir. Tekrar deneyiniz.");
                    
                phoneNumber = CheckAndReadLine();
                allowed = long.TryParse(phoneNumber, out phoneNum) && phoneNumber.Length == 10;
            }
                
            return phoneNum;
        }
    }
}