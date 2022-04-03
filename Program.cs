using System;
using System.Collections.Generic;

namespace phone_book
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager.ListPhoneBook();

            int selector;

            do
            {

                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
                Console.WriteLine("*******************************************");
                Console.WriteLine("(1) Yeni Numara Kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine("(3) Varolan Numarayı Güncelleme");
                Console.WriteLine("(4) Rehberi Listelemek");
                Console.WriteLine("(5) Rehberde Arama Yapmak");

                selector = int.Parse(TaskManager.CheckAndReadLine());

                switch (selector)
                {
                    case 1:
                        TaskManager.AddContact();
                        break;
                    case 2:
                        TaskManager.DeleteContact();
                        break;
                    case 3:
                        TaskManager.UpdateContact();
                        break;
                    case 4:
                        TaskManager.ListPhoneBook();
                        break;
                    case 5:
                        TaskManager.Search();
                        break;
                }

            } while(selector > 0 && selector < 6);
        }
    }
}
