using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp_11
{
    internal class Program
    {
        class ThisString
        {
            private StringBuilder Line;
            private int n;
            public ThisString(string str)
            {
                Line = new StringBuilder(str);
                n = str.Length;
            }
            public ThisString(string str, int len)
            {
                n = len;
                Line = new StringBuilder(str.Substring(0, n));
            }
            public int CountSpaces()
            {
                return Line.ToString().Count(x => x == ' ');
            }
            public void RemovePuncts()
            {
                string str = Line.ToString();
                Line.Clear();
                Line.Append(Regex.Replace(str, "[,.:?!]", ""));
                n = Line.Length;
            }
            public void Lower()
            {
                string str = Line.ToString();
                Line.Clear();
                Line.Append(Regex.Replace(str, @"[А-ЯЁ]", m => m.ToString().ToLower()));
                n = Line.Length;
            }
            public int Length
            {
                get { return n; }
            }
            public StringBuilder line
            {
                get
                {
                    return Line;
                }
                set
                {
                    Line = value;
                }
            }
            public char this[int index]
            {
                get { return Line[index]; }
            }
            public static string operator +(ThisString obj)
            {
                return obj.Line.ToString().ToLower();
            }
            public static string operator -(ThisString obj)
            {
                return obj.Line.ToString().ToUpper();
            }
            public static bool operator true(ThisString obj)
            {
                if (obj.Line.Length != 0)
                    return true;
                return false;
            }
            public static bool operator false(ThisString obj)
            {
                if (obj.Line.Length == 0)
                    return true;
                return false;
            }
            public static bool operator &(ThisString obj1, ThisString obj2)
            {
                return obj1.Line.ToString().ToUpper().Equals(obj2.Line.ToString().ToUpper());
            }
            public static explicit operator string(ThisString obj)
            {
                return obj.Line.ToString();
            }
            public static explicit operator ThisString(string obj)
            {
                return new ThisString(obj);
            }
            public override string ToString()
            {
                return Line.ToString();
            }
        }

        static void Main(string[] args)
        {
            string l;

            while (true)
            {
                try
                {
                    Console.Write("Введите строку: ");
                    l = (Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            ThisString s1 = new ThisString(l);
            Console.WriteLine("\nСтрока: {0} \nДлина строки: {1}", s1, s1.Length);
            Console.WriteLine("\nКоличество пробелов: {0}", s1.CountSpaces());
            s1.Lower();
            Console.WriteLine("\nЗамена прописных букв на строчные: {0}", s1);
            s1.RemovePuncts();
            Console.WriteLine("\nСтрока без знаков препинания: {0} \nДлина строки: {1}", s1, s1.Length);
            Console.WriteLine("\nСтрока: {0}", s1.line);
            Console.WriteLine("\nСимвол с индексом 4: {0}", s1.line[4]);
            Console.WriteLine("\n////////////////////////////////////////");

            while (true)
            {
                try
                {
                    Console.Write("\nВведите вторую строку: ");
                    l = (Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            ThisString s2 = new ThisString(l);
            Console.WriteLine("\nПреобразование строки к строчным символам : {0}", +s2);
            Console.WriteLine("\nПреобразование строки к прописным символам : {0}", -s2);

            if (s2)
                Console.WriteLine("\nСтрока не пустая.");
            else
                Console.WriteLine("\nСтрока пустая.");

            Console.WriteLine("\nСтроки равны? {0}", s1 & s2);
            string x = (string)s2;
            Console.WriteLine("\nПреобразование класса-строка в тип string: {0}", x);
            ThisString s3 = (ThisString)s2;
            Console.WriteLine("\nПреобразование типа string в класс-строку: {0}", s3);
        }
    }
}
