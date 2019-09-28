using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_5
{
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

        //Ввод размера последовательности
        public static void Input()
        {
            do
            {
                do
                {
                    Console.Write("Введите целое число от 0 до 100: ");
                    size = Console.ReadLine();
                } while (!CheckString(size));
                if (int.Parse(size) < 0 || int.Parse(size) > 100)
                    Console.WriteLine("Некорректное значение! Повторите ввод!");
            } while (int.Parse(size) < 0 || int.Parse(size) > 100);
        }

        //Проверка на палиндром
        public static bool Palindrom(string s)
        {
            int len = s.Length;
            for (int i = 0; i < len / 2; i++)
            {
                if (s[i] != s[len - i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        //Поиск палиндромов в последовательности
        public static void FindPalindrom()
        {
            Console.Write("Числа палиндромы из заданной последовательности: ");
            for (int i = 0; i < int.Parse(size); i++)
            {
                if (Palindrom(i.ToString()))
                    Console.Write("{0} ", i);
            }
            Console.WriteLine();

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

        static void Main(string[] args)
        {
            Console.WriteLine("Данная программа ищет числа палиндромы в заданной последовательности.");
            string check = "Y";
            Point:
            switch (check)
            {
                case "Y":
                    Input();
                    FindPalindrom();
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
