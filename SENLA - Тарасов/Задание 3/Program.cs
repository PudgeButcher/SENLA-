using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Задание_3
{
    class Program
    {
        static string text, temptext, res_text;

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

        //Проверка строки
        public static bool CheckString(string s)
        {
            if (s == string.Empty)
            {
                return false;
            }
            else
                return true;
        }

        //Ввод текста
        public static void InputText()
        {
            Console.Write("Введите текст: ");
            text = Console.ReadLine();
            text = text.Trim();
            res_text = text;
            do
            {
                temptext = res_text;
                res_text = temptext.Replace("  ", " ");
            } while (temptext != res_text);
        }

        //Присвоение каждому слову заглавной буквы и сортировка по алфавиту, а также нахождения количества слов в предложении
        public static void TextHandling()
        {
            if (CheckString(res_text))
            {
                //Сортировка и количество слов
                string[] words = res_text.Split(' ', ',', '.', '!', '?');
                string[] textArray;
                textArray = res_text.Split(' ');
                Console.WriteLine("Количество слов: {0}", textArray.Length);
                Array.Sort(words);
                Console.Write("Отсортированные слова: ");
                foreach (var s in words)
                {
                    if (s != "")
                        Console.Write("{0} ", s);
                }

                //Заглавные буквы
                var textInfo = new CultureInfo("ru-RU").TextInfo;
                var capitalizedText = textInfo.ToTitleCase(textInfo.ToLower(res_text));
                Console.WriteLine();
                Console.WriteLine("Все слова с заглавной буквы: {0}", capitalizedText);
            }
            else
                Console.WriteLine("Вы не ввели текст!");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Данная программа подсчитывает количество слов в предложении, выводит их в отсортированном виде, делает первую букву каждого слова заглавной.");
            string check = "Y";
        Point:
            switch (check)
            {
                case "Y":
                    do
                    {
                        InputText();
                        TextHandling();
                    } while (!CheckString(res_text));
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
