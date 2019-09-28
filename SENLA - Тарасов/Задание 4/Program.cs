using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Задание_4
{
    class Program
    {
        static string text, word;
        
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
                return false;
            else
                return true;
        }

        //Ввод текста
        public static void InputText()
        {
            Console.Write("Введите текст: ");
            text = Console.ReadLine();
            text = text.Trim();
            var textInfo = new CultureInfo("ru-RU").TextInfo;
            text = textInfo.ToTitleCase(textInfo.ToLower(text));
        }

        //Ввод искомого слова
        public static void InputWord()
        {
            Console.Write("Введите слово, которое нужно в нём найти: ");
            word = Console.ReadLine();
            var textInfo = new CultureInfo("ru-RU").TextInfo;
            word = textInfo.ToTitleCase(textInfo.ToLower(word));
        }

        //Поиск количества раз вхождения слова в текст
        public static void Find()
        {
            int count = 0;
            string[] words = text.Split(' ', ',', '.', '!', '?');
            Array.Sort(words);
            foreach (var s in words)
            {
                if (s == word)
                    count++;
            }
            Console.WriteLine("Количество появления искомого слова в тексте: {0}", count);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Данная программа, подсчитывает сколько раз употребляется слово в тексте (без учета регистра).");
            string check = "Y";
        Point:
            switch (check)
            {
                case "Y":
                    do
                    {
                        InputText();
                        
                        if (CheckString(text))
                        {
                            do
                            {
                                InputWord();
                                if (CheckString(word))
                                {
                                    Find();
                                }
                                else
                                    Console.WriteLine("Вы не ввели слово для поиска!");
                            } while (!CheckString(word));
                        }
                        else 
                            Console.WriteLine("Вы не ввели текст!");
                    } while (!CheckString(text));
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
