using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithConsole
{
    class Interface
    {
        private static List<int> errors = new List<int>();
        public static void GetMenu()
        {
            bool a = true;
            while (true)
            {
                GeneralMenu();
                try
                {
                    int b = int.Parse(Console.ReadLine());
                    switch (b)
                    {
                        case 1:
                            WorkWithPing();
                            break;
                        case 2:
                            WorkWithTransert();
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
        /// <summary>
        /// главное меню с программами
        /// </summary>
        private static void GeneralMenu()
        {
            Console.WriteLine("Выберите команду");
            Console.WriteLine("1. PING");
            Console.WriteLine("2. TRANSERT");
            Console.WriteLine("3. NET");
            Console.WriteLine("0. EXIT");
        }
        /// <summary>
        /// работа с утилитой PING. Подробнее https://docs.microsoft.com/ru-ru/windows-server/administration/windows-commands/ping?source=docs
        /// </summary>
        private static void WorkWithPing()
        {
            Console.WriteLine("Выберите аргумент или несколько аргументов, введя их через запятую:");
            Console.WriteLine("0. отменить ввод команды");
            Console.WriteLine("1. задать число отправленных запросов. По умолчанию 4 (/n)");
            Console.WriteLine("2. задать  разрешение обратных имен выполняется на IP-адрес назначения (/а)");
            Console.WriteLine("3. задать срок жизни пакета TTL. Максимум 255 (/i)");
            Console.WriteLine("4. Указать, что проверка связи продолжит отправлять сообщения запросов в место назначения, пока не будет прервано (/t)");
            Console.WriteLine("5. указать длину (в байтах) поля данных в отправленных сообщениях запроса. По умолчанию 32, максимальный размер 65 527(/l)");
            Console.WriteLine("6. указать, что сообщения должны отправляться с пометкой \"не фрагментировать\" в заголовке IP. По умолчанию 1 (доступно только в IPv4). ообщения запроса не могут быть фрагментированы маршрутизаторами по пути к назначению (/f)");
            Console.WriteLine("7. указать значение для поля типа службы службы TOS в IP заголовке для отправки запроса (доступно только в IPv4). По умолчанию 0, максимальное значение 255 (/v)");
            Console.WriteLine("8. указать, что параметр записи Route в заголовке IP-адреса используется для записи пути, полученного сообщением запроса, и соответствующего сообщения о ответе (доступно только в IPv4). Каждый прыжок в пути использует запись в параметре запись маршрута . Диапазон прыжка от 1 до 9.(/r)");
            Console.WriteLine("9. указать, что параметр отметка времени Интернета в заголовке IP используется для записи времени прибытия сообщения запроса и соответствующего сообщения эхо-ответа для каждого прыжка. Минимальное значение 1 и максимальное 4.( /s)");
            Console.WriteLine("10. указать, что сообщения запроса используют параметр свободного исходного маршрута в заголовке IP с набором промежуточных назначений, указанных в hostlist (доступно только в IPv4). Максимальное возможное число адресов или имен в списке узлов равно 9. (/j)");
            Console.WriteLine("11. указать, что сообщения запроса используют в заголовке IP параметр с максимальным исходным маршрутом с набором промежуточных назначений, указанных в hostlist (доступно только в IPv4). Максимальное число адресов или имен в списке узлов равно 9. (/k)");
            Console.WriteLine("12. указать время (в миллисекундах) ожидания получения сообщения о ответе, соответствующего заданному сообщению запроса. Если ответное сообщение не получено в течение времени ожидания, отображается сообщение об ошибке \"запрос был превышен\").По умолчанию время ожидания составляет 4000 (4 секунды). (/w)");
            Console.WriteLine("13. Указать, что путь приема-передачи отслеживается (доступно только в IPv6). (/R)");
            Console.WriteLine("14. указать используемый адрес (доступно только в IPV6) (/S)");
            Console.WriteLine("15. указать, что протокол IPv4 используется для проверки связи. Этот параметр не требуется для определения целевого узла с IPv4-адресом. Необходимо только указать целевой узел по имени (/4)");
            Console.WriteLine("16. указать, Указывает, что протокол IPv6 используется для проверки связи. Этот параметр не требуется для определения целевого узла с IPv6-адресом. Необходимо только указать целевой узел по имени. (/6)");
            string input = Console.ReadLine();
            List<string> data = input.Split(',').ToList();
            string commandargs = "";
            string tmp = "";
            errors = new List<int>();
            foreach (string arg in data)
            {
                switch (arg)
                {
                    case "1":
                        Console.WriteLine("/n");
                        tmp = Console.ReadLine();
                        if (int.TryParse(tmp, out int t))
                            commandargs +="/n "+ t+" ";
                        else
                            errors.Add(1);
                        break;
                    case "2":
                       
                        commandargs += "/a ";
                        break;
                    case "3": 
                        Console.WriteLine("/i");
                        tmp = Console.ReadLine();
                        if (int.TryParse(tmp, out t))
                        {
                            if ((t >= 0) && (t <= 255))
                                commandargs += "/i " + t + " ";
                            else
                                errors.Add(3);
                        }
                        else
                            errors.Add(3);
                        break;
                    case "4":
                        commandargs += "-t ";//-t and /t are ecvivalented. This sintaxis don't get a conflicts.
                        break;
                    case "5":
                        Console.WriteLine("/l");
                        tmp = Console.ReadLine();
                        if (int.TryParse(tmp, out t))
                        {
                            if ((t >= 32) && (t <= 65527))
                                commandargs += "/l " + t + " ";
                            else
                                errors.Add(5);
                        }
                        else
                            errors.Add(5);
                        break;
                    case "6":
                        commandargs += "/f ";
                        break;
                    case "7":
                        Console.WriteLine("/v");
                        tmp = Console.ReadLine();
                        if (int.TryParse(tmp, out t))
                        {
                            if ((t >= 0) && (t <= 255))
                                commandargs += "/v " + t + " ";
                            else
                                errors.Add(7);
                        }
                        else
                            errors.Add(7);
                        break;
                    case "8":
                        Console.WriteLine("/r");
                        tmp = Console.ReadLine();
                        if (int.TryParse(tmp, out t))
                        {
                            if ((t >= 1) && (t <= 9))
                                commandargs += "/r " + t + " ";
                            else
                                errors.Add(8);
                        }
                        else
                            errors.Add(8);
                        break;
                    case "9":
                        Console.WriteLine("/s");
                        tmp = Console.ReadLine();
                        if (int.TryParse(tmp, out t))
                        {
                            if ((t >= 1) && (t <= 4))
                                commandargs += "/r " + t + " ";
                            else
                                errors.Add(9);
                        }
                        else
                            errors.Add(9);
                        break;
                    case "10":
                        Console.WriteLine("/j");
                        tmp = Console.ReadLine();
                        if (((tmp.Split(' ').Length<=9)))
                        {  
                            commandargs += "/j " + tmp + " ";
                           
                        }
                        else
                            errors.Add(10);
                        break;
                    case "11":
                        Console.WriteLine("/k");
                        tmp = Console.ReadLine();
                        if (int.TryParse(tmp, out t))
                        {
                            if ((t >= 0) && (t <= 9))
                                commandargs += "/k " + t + " ";
                            else
                                errors.Add(11);
                        }
                        else
                            errors.Add(11);
                        break;
                    case "12":
                        Console.WriteLine("/w");
                        tmp = Console.ReadLine();
                        if (int.TryParse(tmp, out t))
                        { 
                            commandargs += "/w " + t + " ";
                        }
                        else
                            errors.Add(12);
                        break;
                    case "13":
                        commandargs += "/R ";
                        break;
                    case "14":
                        commandargs += " /S";
                        break;
                    case "15":
                        commandargs += " /4";
                        break;
                    case "16":
                        commandargs += " /6";
                        break;
                    case "0":
                        Console.WriteLine("отмена ввода команды");
                        return;
                }
            }
            Console.WriteLine("введите IP адрес");
            string ip = getip();
            if (errors.Count==0)
            WorkWithCmd.ExecuteCommand("ping.exe", commandargs);
            else
            {
                Console.WriteLine("допушены ошибки при вводе:");
                foreach (int t in errors)
                {
                    Console.Write(t+"\t");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// работа с утилитой transert. Подробнее http://cmd4win.ru/administrirovanie-seti/diagnostika-sety/51-tracert
        /// </summary>
        private static void WorkWithTransert()
        {
            Console.WriteLine("Выберите аргумент или несколько аргументов, введя их через запятую:");
            Console.WriteLine("1. предотвратить попытки команды tracert разрешения IP-адресов промежуточных маршрутизаторов в имена. Увеличивает скорость вывода результатов команды tracert (/d)");
            Console.WriteLine("2. задать максимальное количество переходов на пути при поиске конечного объекта. Значение по умолчанию 30 (/h)");
            Console.WriteLine("3. указать для сообщений с запросом использование параметра свободной маршрутизации в заголовке IP с набором промежуточных мест назначения. Максимальное число адресов - 9, разделитель пробел (/j)");
            Console.WriteLine("4. определить время ожидания ответов протокола ICMP или сообщений ICMP об истечении времени, соответствующих данному сообщению заказа (/w). По умолчанию время ожидания составляет 4000 (4 секунды). (/w)");
            Console.WriteLine("0. отменить выполнение команды");
            string input = Console.ReadLine();
            List<string> data = input.Split(',').ToList();
            errors = new List<int>();
            string commandargs = "";
            string tmp = "";
            foreach (string arg in data)
            {
                switch (arg)
                {
                    case "1":
                        commandargs += " /d";
                        break;
                    case "2":
                        Console.WriteLine("/h");
                        tmp = Console.ReadLine();
                        if (int.TryParse(tmp, out int t))
                            commandargs += " /h " + t+" ";
                        else
                            errors.Add(2);
                        break;
                    case "4":
                        Console.WriteLine("/w");
                        tmp = Console.ReadLine();
                        if (int.TryParse(tmp, out t))
                            commandargs += " /w " + t;
                        else
                            errors.Add(3);
                        break;
                    case "3":
                        Console.WriteLine("/j");
                        tmp = Console.ReadLine();
                        if (((tmp.Split(' ').Length <= 9)))
                        {
                            commandargs += "/j " + tmp + " ";

                        }
                        else
                            errors.Add(3);
                        break;
                    case "0":
                        Console.WriteLine("отмена ввода команды");
                        return;
                }
                Console.WriteLine("введите IP адрес");
                string ip = getip();
                if (errors.Count == 0)
                    WorkWithCmd.ExecuteCommand("transert.exe", commandargs);
                else
                {
                    Console.WriteLine("допушены ошибки при вводе:");
                    foreach (int t in errors)
                    {
                        Console.Write(t + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
        /// <summary>
        /// работа с утилитой NET. Подробнее https://www.lifewire.com/net-command-2618094
        /// </summary>
        private static void WorkWithNet()
        {
            Console.WriteLine("Выберите аргумент или несколько аргументов, введя их через запятую:");
            Console.WriteLine("1. установить пароль и требования входа в систему для пользователей (NET accounts)");
            Console.WriteLine("2. добавить или удалить копьютер в домене (NET computer)");
            Console.WriteLine("3. вывести информацию о конфигурации (NET config");
            Console.WriteLine("4. перезапустить службу, которая была остановлена (NET countinue)");
            Console.WriteLine("5. показать открытые файлы на сервере, закрыть общий доступ к файлу и снятие блокировки файла (NET file)");
            Console.WriteLine("6. управлять глобальными группами на сервере (NET group)");
            Console.WriteLine("7. управлять пользователями на локальной машине (NET localgroup)");
            Console.WriteLine("8. приостановить работы службы windows (NET pause)");
            Console.WriteLine("9. управление сеансами между компьютером и другими пользователями сети (NET session)");
            Console.WriteLine("10. управление общими ресурсами копьютера (NET share)");
            Console.WriteLine("11. запустить службу или вывести список служб (NET start)");
            Console.WriteLine("12. просмотр сетевой статистики (NET statistics)");
            Console.WriteLine("13. остановить службу (NET stop)");
            Console.WriteLine("14. отображение общих ресурсов и подключение к нивым (NET use)");
            Console.WriteLine("15. просмотр компьютеров и сетевых устройств в сети (NET view)");
            Console.WriteLine("0. Отменить выполнение команды");
            string input = Console.ReadLine();
            List<string> data = input.Split(',').ToList();
            errors = new List<int>();
            string commandargs = "";
            string tmp = "";
            foreach (string arg in data)
            {
                switch (arg)
                {
                    case "0":
                        Console.WriteLine("Отмена выполнения команды");
                        return;
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    case "8":
                        break;
                    case "9":
                        break;
                    case "10":
                        break;
                    case "11":
                        break;
                    case "12":
                        break;
                    case "13":
                        break;
                    case "14":
                        break;
                    case "15":
                        break;
                }
            }              
        }
        private static bool CheckIp(string ipstr)
        {
            return ipstr.Split('.').Length == 4;
        }
        private static bool CheckArrayIp(string iparrstr)
        {
            bool rez = true;
            foreach (string data in iparrstr.Split(' '))
            {
                if (!CheckIp(data))
                {
                    rez = false;
                    break;
                }
            }
            return rez;
        }
        private static string getip()
        {
            string ip = Console.ReadLine();
            while (!(ip.Split('.').Length == 4))
            {
                Console.WriteLine("uncorrect input. please try again");
                ip = Console.ReadLine();
            }
            return ip;
        }
    }
}
