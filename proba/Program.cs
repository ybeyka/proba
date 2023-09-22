namespace proba
{
    class Kontakt
    {
        public string Imya { get; set; }
        public string NomerTelefonu { get; set; }
        public string Adresa { get; set; }
    }

    class TelefonnaKnyha
    {
        private Kontakt[] kontakty;
        private int count;

        public TelefonnaKnyha(int size)
        {
            kontakty = new Kontakt[size];
            count = 0;
        }

        public void DodatyKontakt(Kontakt kontakt)
        {
            if (count < kontakty.Length)
            {
                kontakty[count] = kontakt;
                count++;
            }
            else
            {
                Console.WriteLine("Телефонна книга повна!");
            }
        }

        public void RedahuvatyKontakt(string imya)
        {
            for (int i = 0; i < count; i++)
            {
                if (kontakty[i].Imya == imya)
                {
                    Console.WriteLine("Введiть нове iм'я:");
                    kontakty[i].Imya = Console.ReadLine();
                    Console.WriteLine("Введiть новий номер телефону:");
                    kontakty[i].NomerTelefonu = Console.ReadLine();
                    Console.WriteLine("Введiть нову адресу:");
                    kontakty[i].Adresa = Console.ReadLine();
                    return;
                }
            }
            Console.WriteLine("Контакт не знайдено!");
        }

        public void VidalytyKontakt(string imya)
        {
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                if (kontakty[i].Imya == imya)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                for (int i = index; i < count - 1; i++)
                {
                    kontakty[i] = kontakty[i + 1];
                }
                count--;
                Console.WriteLine("Контакт видалено!");
            }
            else
            {
                Console.WriteLine("Контакт не знайдено!");
            }
        }

        public void VyvestyKontakt(string imya)
        {
            for (int i = 0; i < count; i++)
            {
                if (kontakty[i].Imya == imya)
                {
                    Console.WriteLine($"Iм'я: {kontakty[i].Imya}, Номер телефону: {kontakty[i].NomerTelefonu}, Адреса: {kontakty[i].Adresa}");
                    return;
                }
            }
            Console.WriteLine("Контакт не знайдено!");
        }
    }

    class Programa
    {
        static void Main()
        {
            TelefonnaKnyha telefonnaKnyha = new TelefonnaKnyha(100);

            while (true)
            {
                Console.WriteLine("1. Додати контакт");
                Console.WriteLine("2. Редагувати контакт");
                Console.WriteLine("3. Видалити контакт");
                Console.WriteLine("4. Вивести контакт");
                Console.WriteLine("5. Вийти");

                string vybir = Console.ReadLine();

                switch (vybir)
                {
                    case "1":
                        Kontakt kontakt = new Kontakt();
                        Console.WriteLine("Введiть iм'я:");
                        kontakt.Imya = Console.ReadLine();
                        Console.WriteLine("Введiть номер телефону:");
                        kontakt.NomerTelefonu = Console.ReadLine();
                        Console.WriteLine("Введiть адресу:");
                        kontakt.Adresa = Console.ReadLine();
                        telefonnaKnyha.DodatyKontakt(kontakt);
                        break;
                    case "2":
                        Console.WriteLine("Введіть iм'я контакту для редагування:");
                        telefonnaKnyha.RedahuvatyKontakt(Console.ReadLine());
                        break;
                    case "3":
                        Console.WriteLine("Введiть iм'я контакту для видалення:");
                        telefonnaKnyha.VidalytyKontakt(Console.ReadLine());
                        break;
                    case "4":
                        Console.WriteLine("Введiть iм'я контакту для виведення:");
                        telefonnaKnyha.VyvestyKontakt(Console.ReadLine());
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Невiрний вибiр, спробуйте знову.");
                        break;
                }
            }
        }
    }

}