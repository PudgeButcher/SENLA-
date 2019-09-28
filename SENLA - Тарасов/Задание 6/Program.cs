using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_6
{
    //Класс, который описывает предмет
    class Item
    {
        public string name { get; set; }
        public double weigth { get; set; }
        public double price { get; set; }
        public Item(string _name, double _weigth, double _price)
        {
            name = _name;
            weigth = _weigth;
            price = _price;
        }
    }

    //Класс, описывающий рюкзак
    class Bag
    {
        private List<Item> bestItems = null;
        private double maxWeigth;
        private double bestPrice;

        public Bag(double _maxWeigth)
        {
            maxWeigth = _maxWeigth;
        }

        //Общий вес набора предметов
        private double FindWeigth(List<Item> items)
        {
            double sumWeigth = 0;
            foreach (Item i in items)
            {
                sumWeigth += i.weigth;
            }
            return sumWeigth;
        }

        //Общая стоимость набора предметов
        private double FindPrice(List<Item> items)
        {
            double sumPrice = 0;
            foreach (Item i in items)
            {
                sumPrice += i.price;
            }
            return sumPrice;
        }

        //Проверка, является ли данный набор лучшим решением задачи
        private void CheckSet(List<Item> items)
        {
            if (bestItems == null)
            {
                if (FindWeigth(items) <= maxWeigth)
                {
                    bestItems = items;
                    bestPrice = FindPrice(items);
                }
            }
            else
            {
                if (FindWeigth(items) <= maxWeigth && FindPrice(items) > bestPrice)
                {
                    bestItems = items;
                    bestPrice = FindPrice(items);
                }
            }
        }

        //Создание всех наборов перестановок значений
        public void AllSets(List<Item> items)
        {
            if (items.Count > 0)
                CheckSet(items);
            for (int i = 0; i < items.Count; i++)
            {
                List<Item> newSet = new List<Item>(items);
                newSet.RemoveAt(i);
                AllSets(newSet);
            }
        }

        //Возвращает решение задачи (набор предметов)
        public List<Item> BestSet()
        {
            return bestItems;
        }
    }

    class Program
    {
        static string size;

        //Проверка ожидания
        public static string Enter()
        {
            string variable;
            do
            {
                Console.Write("Если желаете повторить попытку введите Y, если хотите выйти, то N: ");
                variable = Console.ReadLine();
            }
            while (variable != "Y" && variable != "N");
            return variable;
        }

        //Проверка введённых данных
        public static bool CheckString(string s)
        {
            int res;
            //на пустую строку
            if (s == string.Empty)
            {
                Console.WriteLine("Некорректное значение! Повторите ввод!");
                return false;
            }
            //на строку имеющую не только числа
            else if (!int.TryParse(s, out res))
            {
                Console.WriteLine("Некорректное значение! Повторите ввод!");
                return false;
            }
            else
                return true;
        }

        private static List<Item> items;

        //Ввод всех данных и вывод их на экран
        public static void Input()
        {
            string name, number, weigth, price;

            //Ввод количества предметов
            do
            {
                do
                {
                    Console.Write("Введите количество предметов: ");
                    number = Console.ReadLine();
                } while (!CheckString(number));
                if (int.Parse(number) < 1 || int.Parse(number) > 15)
                    Console.WriteLine("Некорректное значение! Повторите ввод!");
            } while (int.Parse(number) < 1 || int.Parse(number) > 15);

            //Ввод данных каждого предмета
            items = new List<Item>();
            for (int i = 0; i < int.Parse(number); i++)
            {
                    do
                    {
                        Console.Write("Введите название предмета [{0}]: ", i + 1);
                        name = Console.ReadLine();
                        Console.Write("Введите вес предмета [{0}]: ", i + 1);
                        weigth = Console.ReadLine();
                        Console.Write("Введите стоймость предмета [{0}]: ", i + 1);
                        price = Console.ReadLine();
                        if (!CheckString(weigth) || !CheckString(price) || int.Parse(weigth) < 1 || int.Parse(price) < 1)
                            Console.WriteLine("Некорректное значение! Введите целые числа > 0!");
                    } while (!CheckString(weigth) || !CheckString(price) || int.Parse(weigth) < 1 || int.Parse(price) < 1);
                items.Add(new Item(name, int.Parse(weigth), int.Parse(price)));
            }

            //Ввод размера рюкзака
            do
            {
                Console.Write("Введите размер рюкзака: ");
                Program.size = Console.ReadLine();
                if (!CheckString(size))
                    Console.WriteLine("Некорректное значение! Повторите ввод!");
            } while (!CheckString(size));
        }

        //Вывод всех предметов на экран
        private static void Show(List<Item> _items)
        {
            int count = 0;
            foreach (Item i in _items)
            {
                Console.WriteLine("Название: {0} Вес: {1} Стоймость: {2}", i.name, i.weigth, i.price);
                count++;
            }
        }

        //Поиск оптимального набора
        private static void Find()
        {
            Bag bag = new Bag(int.Parse(Program.size));
            bag.AllSets(items);
            List<Item> res = bag.BestSet();
            if (res == null)
            {
                Console.WriteLine("Невозможно найти оптимальный набор!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Оптимальный набор:");
                Show(res);
            }
        }

        static void Main()
        {
            Console.WriteLine("Данная программа рассчитывает наиболее ценный груз для рюкзака исходя из веса и стоймости всех предметов.");
            string check = "Y";
            Point:
            switch (check)
            {
                case "Y":
                    Input();
                    Console.WriteLine();
                    Console.WriteLine("Список всех предметов:");
                    Show(items);
                    Find();
                    Console.WriteLine();
                    check = Enter();
                    goto Point;
                case "N":
                    Environment.Exit(0);
                    break;
                default:
                    check = Enter();
                    goto Point;
            }
        }
    }
}
