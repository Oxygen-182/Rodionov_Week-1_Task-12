using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp_12_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
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
        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Clear();

            string l;

            while (true)
            {
                try
                {
                    l = textBox1.Text;
                    break;
                }
                catch (Exception ex)
                {
                    textBox3.Text += ex.Message;
                }
            }

            ThisString s1 = new ThisString(l);
            textBox3.Text += $"Строка: {s1}" + Environment.NewLine + $"Длина строки: {s1.Length}" + Environment.NewLine;
            textBox3.Text += Environment.NewLine + $"Количество пробелов: {s1.CountSpaces()}" + Environment.NewLine;
            s1.Lower();
            textBox3.Text += Environment.NewLine + $"Замена прописных букв на строчные: {s1}" + Environment.NewLine;
            s1.RemovePuncts();
            textBox3.Text += Environment.NewLine + $"Строка без знаков препинания: {s1}" + Environment.NewLine + $"Длина строки: {s1.Length}" + Environment.NewLine;
            textBox3.Text += Environment.NewLine + $"Строка: {s1.line}" + Environment.NewLine;
            textBox3.Text += Environment.NewLine + $"Символ с индексом 4: {s1.line[4]}" + Environment.NewLine;
            textBox3.Text += Environment.NewLine + "///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////" + Environment.NewLine;

            while (true)
            {
                try
                {
                    l = textBox2.Text;
                    break;
                }
                catch (Exception ex)
                {
                    textBox3.Text += ex.Message;
                }
            }

            ThisString s2 = new ThisString(l);
            textBox3.Text += Environment.NewLine + $"Преобразование строки к строчным символам : {+s2}" + Environment.NewLine;
            textBox3.Text += Environment.NewLine + $"Преобразование строки к прописным символам : {-s2}" + Environment.NewLine;

            if (s2)
                textBox3.Text += Environment.NewLine + "Строка не пустая." + Environment.NewLine;
            else
                textBox3.Text += Environment.NewLine + "Строка пустая." + Environment.NewLine;

            textBox3.Text += Environment.NewLine + $"Строки равны? {s1 & s2}" + Environment.NewLine;
            string x = (string)s2;
            textBox3.Text += Environment.NewLine + $"Преобразование класса-строка в тип string: {x}" + Environment.NewLine;
            ThisString s3 = (ThisString)s2;
            textBox3.Text += Environment.NewLine + $"Преобразование типа string в класс-строку: {s3}" + Environment.NewLine;
        }
    }
}
