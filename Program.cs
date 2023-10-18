using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Examination_work_Library
{
    class Login_details
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public Login_details(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }

    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            //using (FileStream fs = new FileStream("login_details.json", FileMode.Create))
            //{

            //    Login_details tom = new Login_details("admin", "52955925zA");
            //    await JsonSerializer.SerializeAsync(fs, tom);
            //}

            while(true)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("1 - Авторизироваться.");
                    Console.WriteLine("2 - Выйти.");
                    Console.WriteLine("Нажмите на клавишу, которая соответствует выбранной вами опции.");
                    Console.WriteLine();
                    ConsoleKeyInfo keyPL = Console.ReadKey();

                    if (keyPL.Key == ConsoleKey.D1)
                    {
                        try
                        {
                            Console.WriteLine();
                            Console.Write("Введите логин: ");
                            string login = Console.ReadLine();
                            Console.Write("Введите пароль: ");
                            string password = Console.ReadLine();
                            Console.WriteLine();

                            if (CheckCredentials(login, password))
                            {
                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("<<Панель администратора книжного магазина>>");
                                        Console.WriteLine();
                                        Console.WriteLine("Списки книг:");
                                        Console.WriteLine("0 - Книги в наличии.");
                                        Console.WriteLine("1 - Проданные книги.");
                                        Console.WriteLine("2 - Списанные книги.");
                                        Console.WriteLine("3 - Книги по скидке.");
                                        Console.WriteLine("4 - Забронированные книги.");
                                        Console.WriteLine();
                                        Console.WriteLine("Статистика:");
                                        Console.WriteLine("5 - Новинки.");
                                        Console.WriteLine("6 - Популярные книги.");
                                        Console.WriteLine("7 - Популярные авторы.");
                                        Console.WriteLine("8 - Популярные жанры.");
                                        Console.WriteLine();
                                        Console.WriteLine("9 - Выйти.");
                                        Console.WriteLine("Нажмите на клавишу, которая соответствует выбранной вами опции.");
                                        Console.WriteLine();
                                        ConsoleKeyInfo key = Console.ReadKey();

                                        if (key.Key == ConsoleKey.D0)
                                        {
                                            try
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("<<Книги в наличии>>");
                                                using(LibraryEntities1 db = new LibraryEntities1())
                                                {
                                                    var books = db.Books.ToList();
                                                    Console.WriteLine("ID\tНазвание книги\tАвтор\tИздательство\tКол-во страниц\tЖанр\tГод издания\tЯвляется продолжением\tПрошлая книга\tСебествоимость\tЦена");
                                                    foreach (var b in books)
                                                    {
                                                        Console.WriteLine($"{b.Id}\t{b.Name}\t{b.Author}\t{b.Publisher}\t{b.Page_count}\t{b.Jenre}\t{b.Publisher_year}\t{b.Is_continued}\t{b.Previous_book}\t{b.Cost_price}\t{b.Price}");
                                                    }
                                                }
                                                Console.WriteLine();
                                                Console.WriteLine("1 - Найти книгу.");
                                                Console.WriteLine("2 - Добавить книгу.");
                                                Console.WriteLine("3 - Редактировать книгу.");
                                                Console.WriteLine("4 - Удалить книгу.");
                                                Console.WriteLine("5 - Вернуться в основное меню.");
                                                Console.WriteLine("Нажмите на клавишу, которая соответствует выбранной вами опции.");
                                                Console.WriteLine();

                                                ConsoleKeyInfo key_two = Console.ReadKey();

                                                if (key_two.Key == ConsoleKey.D1)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        Console.Write("Введите ключевое слово для поиска: ");
                                                        string keyword = Console.ReadLine().ToLower();

                                                        Console.WriteLine();
                                                        Console.WriteLine("Результаты поиска:");
                                                        using (LibraryEntities1 db = new LibraryEntities1())
                                                        {
                                                            var matchingBooks = db.Books.Where(b =>
                                                                b.Name.ToLower().Contains(keyword) ||
                                                                b.Author.ToLower().Contains(keyword) ||
                                                                b.Publisher.ToLower().Contains(keyword) ||
                                                                b.Page_count.ToString().Contains(keyword) ||
                                                                b.Jenre.ToLower().Contains(keyword) ||
                                                                b.Publisher_year.ToString().Contains(keyword) ||
                                                                b.Is_continued.ToLower().Contains(keyword) ||
                                                                b.Previous_book.ToLower().Contains(keyword) ||
                                                                b.Cost_price.ToLower().Contains(keyword) ||
                                                                b.Price.ToLower().Contains(keyword)
                                                            ).ToList();

                                                            if (matchingBooks.Any())
                                                            {
                                                                Console.WriteLine("ID\tНазвание книги\tАвтор\tИздательство\tКол-во страниц\tЖанр\tГод издания\tЯвляется продолжением\tПрошлая книга\tСебестоимость\tЦена");
                                                                foreach (var b in matchingBooks)
                                                                {
                                                                    Console.WriteLine($"{b.Id}\t{b.Name}\t{b.Author}\t{b.Publisher}\t{b.Page_count}\t{b.Jenre}\t{b.Publisher_year}\t{b.Is_continued}\t{b.Previous_book}\t{b.Cost_price}\t{b.Price}");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Ничего не найдено.");
                                                            }
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D2)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        using (LibraryEntities1 db = new LibraryEntities1())
                                                        {
                                                            Console.Write("Введите название книги: ");
                                                            string name = Console.ReadLine();
                                                            Console.Write("Введите автора книги: ");
                                                            string author = Console.ReadLine();
                                                            Console.Write("Введите издателя книги: ");
                                                            string publisher = Console.ReadLine();
                                                            Console.Write("Введите количество страниц книги: ");
                                                            int count = Convert.ToInt32(Console.ReadLine());
                                                            Console.Write("Введите жанр книги: ");
                                                            string jenre = Console.ReadLine();
                                                            Console.Write("Введите год издания книги: ");
                                                            int year = Convert.ToInt32(Console.ReadLine());
                                                            Console.Write("Является ли книга продолжением другой книги?(Да/нет): ");
                                                            string ic = Console.ReadLine();
                                                            Console.Write("В случае если в прошлом поле вы введи ДА, то введите название предыдущей книги этой серии, если нет, то введите - : ");
                                                            string pb = Console.ReadLine();
                                                            Console.Write("Введите себестоимость книги: ");
                                                            string cp = Console.ReadLine();
                                                            Console.Write("Введите цену: ");
                                                            string price = Console.ReadLine();

                                                            Books books = new Books { Name = $"{name}", Author = $"{author}", Publisher = $"{publisher}", Page_count = count, Jenre = $"{jenre}", Publisher_year = year, Is_continued = $"{ic}", Previous_book = $"{pb}", Cost_price = $"{cp}", Price = $"{price}" };
                                                            db.Books.Add(books);
                                                            db.SaveChanges();
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D3)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        Console.Write("Введите ID книги для редактирования: ");
                                                        int Id = Convert.ToInt32(Console.ReadLine());

                                                        Console.Write("Введите значение для замены: ");
                                                        string old_value = Console.ReadLine();

                                                        Console.Write("Введите новое значение: ");
                                                        Console.WriteLine("Подсказка: внимательно проверяйте корректность значений, во избежание замены не тех значений.");
                                                        string new_value = Console.ReadLine();
                                                        Console.WriteLine();

                                                        using (LibraryEntities1 db = new LibraryEntities1())
                                                        {
                                                            var book = db.Books.FirstOrDefault(b => b.Id == Id);

                                                            if (book != null)
                                                            {

                                                                if (int.TryParse(old_value, out int intOldValue))
                                                                {
                                                                    if (book.Page_count == intOldValue) book.Page_count = Convert.ToInt32(new_value);
                                                                    if (book.Publisher_year == intOldValue) book.Publisher_year = Convert.ToInt32(new_value);
                                                                }
                                                                else
                                                                {

                                                                    Console.WriteLine("Ошибка: введено некорректное значение для замены.");
                                                                }

                                                                if (book.Name == old_value) book.Name = new_value;
                                                                if (book.Author == old_value) book.Author = new_value;
                                                                if (book.Publisher == old_value) book.Publisher = new_value;
                                                                if (book.Jenre == old_value) book.Jenre = new_value;
                                                                if (book.Is_continued == old_value) book.Is_continued = new_value;
                                                                if (book.Previous_book == old_value) book.Previous_book = new_value;
                                                                if (book.Cost_price == old_value) book.Cost_price = new_value;
                                                                if (book.Price == old_value) book.Price = new_value;

                                                                db.SaveChanges();
                                                                Console.WriteLine("Запись успешно обновлена.");
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Книга с указанным ID не найдена.");
                                                            }
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D4)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        Console.Write("Введите ID книги для удаления: ");
                                                        int Id = Convert.ToInt32(Console.ReadLine());

                                                        using (LibraryEntities1 db = new LibraryEntities1())
                                                        {
                                                            var bookToDelete = db.Books.FirstOrDefault(b => b.Id == Id);

                                                            if (bookToDelete != null)
                                                            {
                                                                db.Books.Remove(bookToDelete);
                                                                db.SaveChanges();
                                                                Console.WriteLine($"Книга с ID {Id} успешно удалена.");

                                                               
                                                                var booksToUpdate = db.Books.Where(b => b.Id > Id).ToList();
                                                                foreach (var book in booksToUpdate)
                                                                {
                                                                    book.Id--;  
                                                                }

                                                                db.SaveChanges();
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine($"Книга с ID {Id} не найдена.");
                                                            }
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D5)
                                                {
                                                    try
                                                    {

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine($"Ошибка: {ex.Message}");
                                                Console.WriteLine();
                                            }
                                        }

                                        if (key.Key == ConsoleKey.D1)
                                        {
                                            try
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("<<Проданные книги>>");
                                                //тут будет отображаться список книг
                                                Console.WriteLine();
                                                Console.WriteLine("1 - Найти книгу.");
                                                Console.WriteLine("2 - Добавить книгу.");
                                                Console.WriteLine("3 - Редактировать книгу.");
                                                Console.WriteLine("4 - Удалить книгу.");
                                                Console.WriteLine("5 - Вернуться в основное меню.");
                                                Console.WriteLine("Нажмите на клавишу, которая соответствует выбранной вами опции.");
                                                Console.WriteLine();

                                                ConsoleKeyInfo key_two = Console.ReadKey();

                                                if (key_two.Key == ConsoleKey.D1)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // поиск книги в опции 1
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D2)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // добавление книги в опции 1
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D3)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // редактирование книги в опции 1
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D4)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // удаление книги в опции 1
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D5)
                                                {
                                                    try
                                                    {

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine($"Ошибка: {ex.Message}");
                                                Console.WriteLine();
                                            }
                                        }

                                        if (key.Key == ConsoleKey.D2)
                                        {
                                            try
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("<<Списанные книги>>");
                                                //тут будет отображаться список книг
                                                Console.WriteLine();
                                                Console.WriteLine("1 - Найти книгу.");
                                                Console.WriteLine("2 - Добавить книгу.");
                                                Console.WriteLine("3 - Редактировать книгу.");
                                                Console.WriteLine("4 - Удалить книгу.");
                                                Console.WriteLine("5 - Вернуться в основное меню.");
                                                Console.WriteLine("Нажмите на клавишу, которая соответствует выбранной вами опции.");
                                                Console.WriteLine();

                                                ConsoleKeyInfo key_two = Console.ReadKey();

                                                if (key_two.Key == ConsoleKey.D1)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // поиск книги в опции 2
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D2)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // добавление книги в опции 2
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D3)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // редактирование книги в опции 2
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D4)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // удаление книги в опции 2
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D5)
                                                {
                                                    try
                                                    {

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine($"Ошибка: {ex.Message}");
                                                Console.WriteLine();
                                            }
                                        }

                                        if (key.Key == ConsoleKey.D3)
                                        {
                                            try
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.WriteLine("<<Книги по скидке>>");
                                                //тут будет отображаться список книг
                                                Console.WriteLine();
                                                Console.WriteLine("1 - Найти книгу.");
                                                Console.WriteLine("2 - Добавить книгу.");
                                                Console.WriteLine("3 - Редактировать книгу.");
                                                Console.WriteLine("4 - Удалить книгу.");
                                                Console.WriteLine("5 - Вернуться в основное меню.");
                                                Console.WriteLine("Нажмите на клавишу, которая соответствует выбранной вами опции.");
                                                Console.WriteLine();

                                                ConsoleKeyInfo key_two = Console.ReadKey();

                                                if (key_two.Key == ConsoleKey.D1)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // поиск книги в опции 3
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D2)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // добавление книги в опции 3
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D3)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // редактирование книги в опции 3
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D4)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // удаление книги в опции 3
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D5)
                                                {
                                                    try
                                                    {

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }
                                                Console.WriteLine();
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine($"Ошибка: {ex.Message}");
                                                Console.WriteLine();
                                            }
                                        }

                                        if (key.Key == ConsoleKey.D4)
                                        {
                                            try
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("<<Забронированные книги>>");
                                                //тут будет отображаться список книг
                                                Console.WriteLine();
                                                Console.WriteLine("1 - Найти книгу.");
                                                Console.WriteLine("2 - Добавить книгу.");
                                                Console.WriteLine("3 - Редактировать книгу.");
                                                Console.WriteLine("4 - Удалить книгу.");
                                                Console.WriteLine("5 - Вернуться в основное меню.");
                                                Console.WriteLine("Нажмите на клавишу, которая соответствует выбранной вами опции.");
                                                Console.WriteLine();

                                                ConsoleKeyInfo key_two = Console.ReadKey();

                                                if (key_two.Key == ConsoleKey.D1)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // поиск книги в опции 4
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D2)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // добавление книги в опции 4
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D3)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // редактирование книги в опции 4
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D4)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // удаление книги в опции 4
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D5)
                                                {
                                                    try
                                                    {

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine($"Ошибка: {ex.Message}");
                                                Console.WriteLine();
                                            }
                                        }

                                        if (key.Key == ConsoleKey.D5)
                                        {
                                            try
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("<<Новинки>>");
                                                using (LibraryEntities1 db = new LibraryEntities1())
                                                {
                                                    var books = db.New_books.ToList();
                                                    Console.WriteLine("ID\tНазвание книги\tАвтор\tИздательство\tКол-во страниц\tЖанр\tГод издания\tЯвляется продолжением\tПрошлая книга\tСебествоимость\tЦена");
                                                    foreach (var b in books)
                                                    {
                                                        Console.WriteLine($"{b.Id}\t{b.Name}\t{b.Author}\t{b.Publisher}\t{b.Page_count}\t{b.Jenre}\t{b.Publisher_year}\t{b.Is_continued}\t{b.Previous_book}\t{b.Cost_price}\t{b.Price}");
                                                    }
                                                }
                                                Console.WriteLine();
                                                Console.WriteLine("1 - Найти книгу.");
                                                Console.WriteLine("2 - Добавить книгу.");
                                                Console.WriteLine("3 - Редактировать книгу.");
                                                Console.WriteLine("4 - Удалить книгу.");
                                                Console.WriteLine("5 - Вернуться в основное меню.");
                                                Console.WriteLine("Нажмите на клавишу, которая соответствует выбранной вами опции.");
                                                Console.WriteLine();

                                                ConsoleKeyInfo key_two = Console.ReadKey();

                                                if (key_two.Key == ConsoleKey.D1)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // поиск книги в опции 5
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D2)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // добавление книги в опции 5
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D3)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // редактирование книги в опции 5
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D4)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // удаление книги в опции 5
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D5)
                                                {
                                                    try
                                                    {

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine($"Ошибка: {ex.Message}");
                                                Console.WriteLine();
                                            }
                                        }

                                        if (key.Key == ConsoleKey.D6)
                                        {
                                            try
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("<<Популярные книги>>");
                                                using (LibraryEntities1 db = new LibraryEntities1())
                                                {
                                                    var books = db.Popular_books.ToList();
                                                    Console.WriteLine("ID\tНазвание книги\tАвтор\tИздательство\tКол-во страниц\tЖанр\tГод издания\tЯвляется продолжением\tПрошлая книга\tСебествоимость\tЦена");
                                                    foreach (var b in books)
                                                    {
                                                        Console.WriteLine($"{b.Id}\t{b.Name}\t{b.Author}\t{b.Publisher}\t{b.Page_count}\t{b.Jenre}\t{b.Publisher_year}\t{b.Is_continued}\t{b.Previous_book}\t{b.Cost_price}\t{b.Price}");
                                                    }
                                                }
                                                Console.WriteLine();
                                                Console.WriteLine("1 - Найти книгу.");
                                                Console.WriteLine("2 - Добавить книгу.");
                                                Console.WriteLine("3 - Редактировать книгу.");
                                                Console.WriteLine("4 - Удалить книгу.");
                                                Console.WriteLine("5 - Вернуться в основное меню.");
                                                Console.WriteLine("Нажмите на клавишу, которая соответствует выбранной вами опции.");
                                                Console.WriteLine();

                                                ConsoleKeyInfo key_two = Console.ReadKey();

                                                if (key_two.Key == ConsoleKey.D1)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // поиск книги в опции 6
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D2)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // добавление книги в опции 6
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D3)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // редактирование книги в опции 6
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D4)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // удаление книги в опции 6
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D5)
                                                {
                                                    try
                                                    {

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine($"Ошибка: {ex.Message}");
                                                Console.WriteLine();
                                            }
                                        }

                                        if (key.Key == ConsoleKey.D7)
                                        {
                                            try
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("<<Популярные авторы>>");
                                                //тут будет отображаться список книг
                                                Console.WriteLine();
                                                Console.WriteLine("1 - Найти автора.");
                                                Console.WriteLine("2 - Добавить автора.");
                                                Console.WriteLine("3 - Редактировать автора.");
                                                Console.WriteLine("4 - Удалить автора.");
                                                Console.WriteLine("5 - Вернуться в основное меню.");
                                                Console.WriteLine("Нажмите на клавишу, которая соответствует выбранной вами опции.");
                                                Console.WriteLine();

                                                ConsoleKeyInfo key_two = Console.ReadKey();

                                                if (key_two.Key == ConsoleKey.D1)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // поиск книги в опции 7
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D2)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // добавление книги в опции 7
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D3)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // редактирование книги в опции 7
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D4)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // удаление книги в опции 7
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D5)
                                                {
                                                    try
                                                    {

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine($"Ошибка: {ex.Message}");
                                                Console.WriteLine();
                                            }
                                        }

                                        if (key.Key == ConsoleKey.D8)
                                        {
                                            try
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("<<Популярные жанры>>");
                                                //тут будет отображаться список книг
                                                Console.WriteLine();
                                                Console.WriteLine("1 - Найти жанр.");
                                                Console.WriteLine("2 - Добавить жанр.");
                                                Console.WriteLine("3 - Редактировать жанр.");
                                                Console.WriteLine("4 - Удалить жанр.");
                                                Console.WriteLine("5 - Вернуться в основное меню.");
                                                Console.WriteLine("Нажмите на клавишу, которая соответствует выбранной вами опции.");
                                                Console.WriteLine();

                                                ConsoleKeyInfo key_two = Console.ReadKey();

                                                if (key_two.Key == ConsoleKey.D1)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // поиск книги в опции 0
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D2)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // добавление книги в опции 0
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D3)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // редактирование книги в опции 0
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D4)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        // удаление книги в опции 0
                                                        Console.WriteLine();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }

                                                if (key_two.Key == ConsoleKey.D5)
                                                {
                                                    try
                                                    {

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                                        Console.WriteLine();
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine($"Ошибка: {ex.Message}");
                                                Console.WriteLine();
                                            }
                                        }

                                        if (key.Key == ConsoleKey.D9)
                                        {
                                            Environment.Exit(0);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine($"Ошибка: {ex.Message}");
                                        Console.WriteLine();
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Введены неверный логин или пароль.");
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Ошибка: {ex.Message}");
                            Console.WriteLine();
                        }

                    }

                    if (keyPL.Key == ConsoleKey.D2)
                    {
                        Environment.Exit(0); 
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine();
                }
            }

            bool CheckCredentials(string login, string password)
            {
                if (!File.Exists("login_details.json"))
                    return false;

                // Чтение данных из JSON-файла
                string json = File.ReadAllText("login_details.json");

                // Десериализация JSON в объект
                Login_details loginDetails = JsonConvert.DeserializeObject<Login_details>(json);

                // Проверка логина и пароля
                return login == loginDetails?.Login && password == loginDetails?.Password;
            }

            
        }
    }
}
