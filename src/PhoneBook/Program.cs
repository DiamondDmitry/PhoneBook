using System.Text;

public class Program
{
    private static PhoneBook.PhoneBook _phoneBook;

    static void Main(string[] args)
    {
        _phoneBook = new PhoneBook.PhoneBook();

        Console.OutputEncoding = Encoding.UTF8;
        bool isRunning = true;
        
        _phoneBook.LoadBook();

        while (isRunning)
        {
            Console.WriteLine();
            Console.WriteLine("1. Добавить контакт");
            Console.WriteLine("2. Просмотреть контакты");
            Console.WriteLine("3. Обновить контакт");
            Console.WriteLine("4. Удалить контакт");
            Console.WriteLine("5. Поиск контакта");
            //Console.WriteLine("6. Сохранить книгу");
            //Console.WriteLine("7. Загрузить книгу");
            Console.WriteLine("0. Выйти");

            byte.TryParse(Console.ReadLine(), out byte choice);

            switch (choice)
            {
                case 1:
                    _phoneBook.AddContact();
                    break;
                case 2:
                    _phoneBook.ViewContacts();
                    break;
                case 3:
                    _phoneBook.UpdateContact();
                    break;
                case 4:
                    _phoneBook.DeleteContact();
                    break;
                case 5:
                    _phoneBook.SearchContact();
                    break;
                //case 6:
                //    _phoneBook.SaveBook();
                //    break;
                //case 7:
                //    _phoneBook.LoadBook();
                //    break;
                case 0:
                    _phoneBook.SaveBook();
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                    break;
            }
        }
    }
}