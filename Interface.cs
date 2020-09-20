using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithConsole
{
    class Interface
    {
        public static void select()
        {
            bool a = true;
            while (true)
            {
                printlvl0();
                try
                {
                    int b = int.Parse(Console.ReadLine());
                    switch (b)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 0:
                            a = false;
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Некорректная команда");
                }
                
            }
            
        }
        private static void printlvl0()
        {
            Console.WriteLine("Выберите команду");
            Console.WriteLine("1. PING");
            Console.WriteLine("2. TRANSERT");
            Console.WriteLine("3. NET");
            Console.WriteLine("0. EXIT");
        }
        /// <summary>
        /// метод для программы PING. Подробнее https://docs.microsoft.com/ru-ru/windows-server/administration/windows-commands/ping?source=docs
        /// </summary>
        private static void printlvl1()
        {
            Console.WriteLine("Выберите аргумент или введите их через запятую");
            Console.WriteLine("1. задать число отправленных запросов. По умолчанию 4 (/n)");
            Console.WriteLine("2. задать  разрешение обратных имен выполняется на IP-адрес назначения (/а)");
            Console.WriteLine("3. задать срок жизни пакета TTL. Максимум 255 (/i)");
            Console.WriteLine("4. Указывает, что проверка связи продолжит отправлять сообщения запросов в место назначения, пока не будет прервано (/t)");
            Console.WriteLine("5. указывает длину (в байтах) поля данных в отправленных сообщениях запроса. По умолчанию 32, максимальный размер 65 527(/l)");
            Console.WriteLine("6. указывает, что сообщения должны отправляться с пометкой \"не фрагментировать\" в заголовке IP. По умолчанию 1 (доступно только в IPv4). ообщения запроса не могут быть фрагментированы маршрутизаторами по пути к назначению (/f)");
            Console.WriteLine("7. указывает значение для поля типа службы службы TOS в IP заголовке для отправки запроса (доступно только в IPv4). По умолчанию 0, максимальное значение 255 (/v)");
            Console.WriteLine("8. указать, что параметр записи Route в заголовке IP-адреса используется для записи пути, полученного сообщением запроса, и соответствующего сообщения о ответе (доступно только в IPv4). Каждый прыжок в пути использует запись в параметре запись маршрута . Диапазон прыжка от 1 до 9.(/r)");
            Console.WriteLine("9. указать, что параметр отметка времени Интернета в заголовке IP используется для записи времени прибытия сообщения запроса и соответствующего сообщения эхо-ответа для каждого прыжка. Минимальное значение 1 и максимальное 4.( /s)");
            Console.WriteLine("10. указать, что сообщения запроса используют параметр свободного исходного маршрута в заголовке IP с набором промежуточных назначений, указанных в hostlist (доступно только в IPv4). Максимальное возможное значение равно 9.");
            string input = Console.ReadLine();
            List<string> data = input.Split(',').ToList();
            string command = "ping.exe";
            foreach (string arg in data)
            {
                switch (arg)
                {
                    case "0":
                        break;
                }
            }
        }
    }
}
