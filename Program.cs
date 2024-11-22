using System.Collections.Generic;
using System.Text;
namespace Lab_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //===================================================
            // Задание 1
            //===================================================

            Console.WriteLine("Лабораторная работа 4, В-1");
            Console.WriteLine("\n=======================================================================\n");
            Console.WriteLine("Задание 1. Составить программу, которая удаляет из списка L все элементы E, если такие есть.");
            Console.WriteLine("Требуется задать длину списка.");

            int LenghtList;
            while (true)
            {
                int LenghtCheck = Tasks.IntEnter();                // Указываем длину листа
                if (LenghtCheck > 0)
                {
                    LenghtList = LenghtCheck;
                    break;
                }
                else
                    Console.WriteLine("Длина списка не может быть отрицательной, а также в нашем случае список не должен быть пустой");
            }
            List<int> list = new List<int>(LenghtList);

            for (int i = 0; i < LenghtList; i++)        // Заполнение листа
            {
                Console.WriteLine("Введите значение элемента номер " + (i + 1) + ": ");
                int number = Tasks.IntEnter();
                list.Add(number);
            }

            Console.Write("[");                 // Показываем готовый списочек
            foreach (int i in list)
                Console.Write(i + " ");
            Console.Write("]");


            Console.WriteLine("\nВведите элемент E, который должен быть удалён из списка.");
            int E = Tasks.IntEnter();

            Tasks.deleteElementFromList(list, E);

            Console.Write("[");                 // Показываем изменённый списочек
            foreach (int i in list)
            {
                Console.Write(i + " ");
            }
            Console.Write("]");

            //=====================================================================
            // Задание 2.
            //=====================================================================

            Console.WriteLine("\n\n=======================================================================");
            Console.WriteLine("\nЗадание 2. Напечатать в обратном порядке элементы непустого списка L.");

            LinkedList<int> LinList = new LinkedList<int>([1, 2, 3, 4, 5, 10, 9, 8, 7, 6]);

            Tasks.reverseLinkedList(LinList);

            //=====================================================================
            // Задание 3.
            //=====================================================================

            Console.WriteLine("\n\n=======================================================================");
            Console.WriteLine("\nЗадание 3.");

            List<HashSet<string>> buyingData =
            [
                new HashSet<string> {"ДНС", "Озончик", "Вайлдберриз"},
                new HashSet<string> {"ДНС", "НашПКМагазин", "Всё для дома"},
                new HashSet<string> {"ДНС", "Озончик", "Всё для дома"}
            ];

            HashSet<string> firm = ["ДНС", "Озончик", "Вайлдберриз", "НашПКМагазин", "Всё для дома", "ПермьПК"];

            Tasks.analysisForTask3(buyingData, firm);

            //=====================================================================
            // Задание 4.
            //=====================================================================

            Console.WriteLine("\n\n=======================================================================");
            Console.WriteLine("\nЗадание 4.");

            string filePath = "C:\\Users\\Syoshi\\source\\repos\\Lab 4\\text.txt";
            Tasks.SonoursConsonants(filePath);

            //=====================================================================
            // Задание 5.
            //=====================================================================

            Console.WriteLine("\n\n=======================================================================");
            Console.WriteLine("\nЗадание 5.");

            string filePath5 = "C:\\Users\\Syoshi\\source\\repos\\Lab 4\\task5.xml";
            Tasks.studentInput(filePath5);
            Tasks.FifthTask(filePath5);
        }
    }
}
