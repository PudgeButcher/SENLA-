using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_2
{
    class Program
    {
        //Проверка на ввод целого числа
        public static bool CheckInt(string line)
        {
            int value;
            //проверка пустой строки и натуральных чисел
            if (int.TryParse(line, out value) && int.Parse(line) > 0)
                return true;
            else
            {
                Console.WriteLine("Введите натуральные целые числа!");
                return false;
            }
        }

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

        //Поиск НОД
        public static int NOD(int a, int b)
        {
            if (b < 0)
                b = -b;
            if (a < 0)
                a = -a;
            while (b > 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        //Поиск НОК
        public static int NOK(int a, int b)
        {
            return Math.Abs(a * b) / NOD(a, b);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Данная программа вычисляет НОД и НОК двух целых чисел.");
            string check = "Y";
            Point:
            switch (check)
            {
                case "Y":
                    string a, b;
                    do
                    {
                         Console.Write("Введите первое целое число: ");
                         a = Console.ReadLine();
                         Console.Write("Введите второе целое число: ");
                         b = Console.ReadLine();
                    } while (!CheckInt(a) || !CheckInt(b));
                    Console.WriteLine("НОД = {0}", NOD(int.Parse(a), int.Parse(b)));
                    Console.WriteLine("НОК = {0}", NOK(int.Parse(a), int.Parse(b)));
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
