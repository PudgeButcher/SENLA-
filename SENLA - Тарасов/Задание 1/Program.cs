using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_1
{
    class Program
    {
        //Проверка на ввод целого числа
        public static bool CheckInt(string line)
        {
            int value;
            //Проверка на присутствие в строке только числа от 2
            if (int.TryParse(line, out value) && int.Parse(line) > 1)
                return true;
            else
            {
                Console.Write("Введите натуральное целое число > 1!: ");
                return false;
            }
        }

        //Проверка на чётность
        public static void EvenNumber(int variable)
        {
            if (variable % 2 == 0)
            {
                Console.WriteLine("Заданное число чётное");
            }
            else
            {
                Console.WriteLine("Заданное число нечётное");
            }
        }

        //Проверка на простое/составное
        public static void SimpleNumber(int variable)
        {
            for (int i = 2; i <= variable / 2; i++)
            {
                if (variable % i == 0)
                {
                    Console.WriteLine("Заданное число является составным");
                    return;
                }
            }
            Console.WriteLine("Заданное число является простым");
            return;
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

        static void Main(string[] args)
        {
            Console.WriteLine("Данная программа проверяет целое ли число, чётное оно или нечётное, а также простое или составное.");
            string check = "Y";
            Point:
            switch (check)
            {
                case "Y":
                    Console.Write("Введите целое число: ");
                    string a = Console.ReadLine();
                    if (!CheckInt(a))
                    {
                        do
                            a = Console.ReadLine();
                        while (!CheckInt(a));
                    }
                    EvenNumber(int.Parse(a));
                    SimpleNumber(int.Parse(a));
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
