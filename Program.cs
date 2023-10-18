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
                            Console.WriteLine("Введите логин:");
                            string login = Console.ReadLine();
                            Console.WriteLine("Введите пароль:");
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
