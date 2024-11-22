using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_4
{
    internal class Tasks
    {
        public static int IntEnter()                         // Метод для проверки числа на правильность ввода.
        {
            while (true)
            {
                Console.WriteLine("Введите целое число: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                    return number;
                else
                    Console.WriteLine("Ошибка ввода.");
            }
        }


        public static void deleteElementFromList(List<int> list, int E)
        {
            int HowManyE = 0;
            foreach (int i in list)
            {
                if (i == E)
                    HowManyE++;
            }

            if (HowManyE == 0)
                Console.WriteLine("Элемента E нет в нашем списке.");
            else
            {
                for (int i = 0; i < HowManyE; i++)
                    list.Remove(E);
            }
        }


        public static void reverseLinkedList(LinkedList<int> list)
        {
            var currentNode = list.Last;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Previous;
            }
        }

        public static void analysisForTask3(List<HashSet<string>> data, HashSet<string> firm)
        {
            var all = new HashSet<string>(firm);
            var atleastone = new HashSet<string>();
            var none = new HashSet<string>(firm);

            foreach (var shop in data)
            {
                all.IntersectWith(shop); // возвращает общие элементы
                atleastone.UnionWith(shop); // возвращает все элементы, объединяет два сета
                none.ExceptWith(shop); // возвращает элементы, которые есть в первом сете, но нет во втором
            }

            Console.WriteLine("Фирмы, у которых все закупали: ");
            foreach (var firms in all)
            {
                Console.WriteLine(firms);
            }

            Console.WriteLine("\nФирмы, у которых брало хотя бы 1 заведение: ");
            foreach (var firms in atleastone)
            {
                Console.WriteLine(firms);
            }

            Console.WriteLine("\nФирмы, у которых не заказывали пк: ");
            foreach (var firms in none)
            {
                Console.WriteLine(firms);
            }
        }

        public static void SonoursConsonants(string filePath)
        {
            HashSet<char> SonoursConsonants = ['б', 'в', 'г', 'д', 'ж', 'з', 'л', 'м', 'н', 'р'];

            HashSet<char> foundConsonants = new HashSet<char>();

            string text = File.ReadAllText(filePath);
            Console.WriteLine("Содержимое файла:");
            Console.WriteLine(text);

            foreach (var word in text.Split(new char[] { ' ', '\n', '.', ',', '!', '?', ';', ':', '-' }, StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (char c in word.ToLower())
                {
                    if (SonoursConsonants.Contains(c))
                        foundConsonants.Add(c);

                }
            }

            var sortedConsonants = foundConsonants.OrderBy(c => c).ToList();

            if (sortedConsonants.Count > 0)
            {
                Console.WriteLine("Звонкие согласные в алфавитном порядке:");
                foreach (var consonant in sortedConsonants)
                {
                    Console.Write(consonant + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Звонкие согласные не найдены.");
            }
        }


        private static void FifthTaskFileCreate(string filePath5, List<(string LastName, string FirstName)> students)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<(string LastName, string FirstName)>));
            using (StreamWriter writer = new StreamWriter(filePath5, false, Encoding.UTF8))
                serializer.Serialize(writer, students);
        }

        private static List<(string LastName, string FirstName)> FifthTaskReadFile(string filePath5)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<(string LastName, string FirstName)>));
            using (StreamReader reader = new StreamReader(filePath5))
            {
                return (List<(string LastName, string FirstName)>)serializer.Deserialize(reader) ?? throw new InvalidOperationException("Файл пуст");
            }
        }
        private static void ValidData(string lastName, string firstName)
        {
            if (lastName.Length == 0 || firstName.Length == 0)
            {
                throw new Exception("Фамилия и имя не могут быть пустыми.");
            }

            if (lastName.Length > 20)
            {
                throw new Exception("Фамилия не может быть длиннее 20 символов.");
            }

            if (firstName.Length > 15)
            {
                throw new Exception("Имя не может быть длиннее 15 символов.");
            }
        }

        public static void studentInput(string filePath5)
        {
            Console.WriteLine("Введите количество абитуриентов: ");
            int count = IntEnter();
            while (true)
            {
                if (count < 1)
                    Console.WriteLine("Количество студентов не может быть меньше 1");
                if (count > 100)
                    Console.WriteLine("Количество студентов не может быть больше 100");
                else
                    break;
            }

            var students = new List<(string LastName, string FirstName)>();
            Console.WriteLine("Введите данные абитуриентов в формате: Фамилия Имя");

            for (int i = 0; i < count; i++)
            {
                Console.Write("Введите данные студента " + (i + 1) + ": ");
                string[] input = Console.ReadLine().Split(' ');
                string lastName = input[0];
                string firstName = input[1];

                ValidData(lastName, firstName);

                students.Add((lastName, firstName));
            }
            FifthTaskFileCreate(filePath5, students);
        }

        private static List<string> GenerateLogins(List<(string LastName, string FirstName)> students)
        {
            Dictionary<string, int> loginCounter = new Dictionary<string, int>();
            List<string> logins = new List<string>();

            foreach (var student in students)
            {
                string baseLogin = $"{student.LastName}";
                if (!loginCounter.ContainsKey(baseLogin))
                {
                    loginCounter[baseLogin] = 1;
                    logins.Add(baseLogin);
                }
                else
                {
                    loginCounter[baseLogin]++;
                    logins.Add($"{baseLogin}{loginCounter[baseLogin]}");
                }
            }
            return logins;
        }

        public static void FifthTask(string filePath5)
        {
            var students = FifthTaskReadFile(filePath5);
            List<string> logins = GenerateLogins(students);

            Console.WriteLine("Сгенерированные логины:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(logins[i]);
            }
        }
    }
}
