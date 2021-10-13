using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleTextEditor
{
    class Program
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);
        static bool check;
        static string line;
        static string filepath;
        static void Main(string[] args)
        {
            link:
            Console.Write("Введите путь к текстовому документу... ");
            filepath = Convert.ToString(Console.ReadLine());
            Program.Checker();
            if (check == false)
                goto link;
            Program.Reader();
            goto link;
        }
        /// <summary>
        /// Проверяет расширение файла
        /// </summary>
        static void Checker()
        {
            string pattern = @".txt";
            Regex newRegex = new Regex(pattern);
            MatchCollection collection = newRegex.Matches(filepath);
            if (collection.Count < 1)
            {
                Console.Write("Выберите файл формата .txt\n");
                check = false;
            }
            else
                check = true;
        }
        /// <summary>
        /// Читает текст в документе
        /// </summary>
        static void Reader()
        {
            try
            {
                StreamReader streamreader = new StreamReader(filepath);
                line = streamreader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = streamreader.ReadLine();
                }
                streamreader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Выполнение завершено");
            }
        }
    }
}
