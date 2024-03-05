namespace PhoneBook;

public class PhoneBook
{
    public PhoneBook(List<Contact> contacts)
    {
        Contacts = contacts;
    }

    public PhoneBook()
    {
        Contacts = new List<Contact>();
    }
    public List<Contact> Contacts { get; set; }
    public IConsoleReader ConsoleReader = new ConsoleReader();

    public void AddContact()
    {
        Contact contact = new Contact();
        do
        {
            ConsoleReader.Write("Введите имя: ");
            contact.FirstName = ConsoleReader.ReadLine();
        }
        while (contact.FirstName == "");

        do
        {
            ConsoleReader.Write("Введите фамилию: ");
            contact.LastName = ConsoleReader.ReadLine();
        }
        while (contact.LastName == "");

        do
        {
            ConsoleReader.Write("Введите номер телефона: ");
            contact.PhoneNumber = ConsoleReader.ReadLine();
        }
        while (contact.PhoneNumber == "");

        Contacts.Add(contact);
        ConsoleReader.WriteLine("Контакт добавлен.");

    }

    public void ViewContacts()
    {
        // Вывод списка контактов
        if (Contacts.Count() > 0)
        {
            int i = 0;
            ConsoleReader.WriteLine("Список контактов:");
            foreach (Contact contact in Contacts)
            {
                i++;
                ConsoleReader.WriteLine(i + ") " + "Имя: " + contact.FirstName + " Фамилия: " + contact.LastName + " Номер телефона: " + contact.PhoneNumber);
            }
        }
        else
        {
            ConsoleReader.WriteLine("Список контактов пуст.");
        }
    }

    public void UpdateContact()
    {
        // Изменение Имени и Фамилии у контакта
        ConsoleReader.Write("Введите номер телефона контакта, который хотите обновить: ");
        Contact contact = Contacts.FirstOrDefault(x => x.PhoneNumber == ConsoleReader.ReadLine());
        int index = Contacts.IndexOf(contact);
        if (contact != null)
        {
            do
            {
                ConsoleReader.Write("Введите новое имя: ");
                contact.FirstName = ConsoleReader.ReadLine();
            }
            while (contact.FirstName == "");

            do
            {
                ConsoleReader.Write("Введите новую фамилию: ");
                contact.LastName = ConsoleReader.ReadLine();
            }
            while (contact.LastName == "");

            Contacts[index] = contact;
            ConsoleReader.WriteLine("Контакт обновлен.");
        }
        else
        {
            ConsoleReader.WriteLine("Контакт с таким номером телефона не найден.");
        }
    }
    public void DeleteContact()
    {
        // Удаление контакта
        ConsoleReader.Write("Введите номер телефона контакта, который хотите удалить: ");
        Contact contact = Contacts.FirstOrDefault(x => x.PhoneNumber == ConsoleReader.ReadLine());
        if (contact != null)
        {
            Contacts.Remove(contact);
            ConsoleReader.WriteLine("Контакт удален.");
        }
        else
        {
            ConsoleReader.WriteLine("Контакт с таким номером телефона не найден.");
        }
    }

    public void SearchContact()
    {
        // Поиск контакта по доступным полям
        ConsoleReader.Write("Введите имя или фамилию или номер телефона для поиска: ");
        string searchText = ConsoleReader.ReadLine();
        Contact contact = Contacts.FirstOrDefault(x => x.FirstName == searchText || x.LastName == searchText || x.PhoneNumber == searchText);
        if (contact != null)
        {
            ConsoleReader.WriteLine("Имя: " + contact.FirstName + " Фамилия: " + contact.LastName + " Номер телефона: " + contact.PhoneNumber);
        }
        else
        {
            ConsoleReader.WriteLine("Контакты не найдены.");
        }
    }
    public void SaveBook()
    {
        // Сохранение построчно контактов из файла contacts.txt
        using (StreamWriter writer = new StreamWriter("contacts.txt"))
        {
            foreach (Contact contact in Contacts)
            {
                writer.WriteLine(contact.FirstName + "," + contact.LastName + "," + contact.PhoneNumber);
            }
        }

        ConsoleReader.WriteLine("Книга сохранена.");
    }

    public void LoadBook()
    {
        // Загрузка контактов из файла contacts.txt
        if (File.Exists("contacts.txt"))
        { 
            using (StreamReader reader = new StreamReader("contacts.txt"))
            {
                while (!reader.EndOfStream)
                {
                    Contact contact = new Contact();
                    string[] fieldsContact = reader.ReadLine().Split(',');
                    contact.FirstName = fieldsContact[0];
                    contact.LastName = fieldsContact[1];
                    contact.PhoneNumber = fieldsContact[2];
                    Contacts.Add(contact);
                }
            }
        }
    }
}
