using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProyectoHorarios1
{
    public static class TextSplitter
    {
        public static List<string> result = new List<string>();

        private static Controller controller = new Controller();
        public static List<string> SplitPDF(string text)
        {
            var textSplit = Regex.Split(text, "\r\n|\r|\n");

            char stringFirstCharacter = ' ';

            foreach (string line in textSplit)
            {
                if (line != string.Empty)
                {
                    stringFirstCharacter = line.ToCharArray().ElementAt(1);
                }

                if (char.IsNumber(stringFirstCharacter))
                {
                    result.Add(line);
                }
            }
            controller.Clean();
            return result;
        }
        public static void SplitLine(string line)
        {
            if (line != string.Empty)
            {
                string id, name = "", nameAux, day, classroom, group, professor;
                int startHour, endHour;

                id = GetRegex(line, @"\d{7}");

                nameAux = GetRegex(line, @"[A-Z][^\d]+ ");

                group = GetRegex(line, @"\b[A-Z]\d\b|\b\d[A-Z]\b|\b[0-9]\b|\b[0-9][0-9]\b|\b[CDE]\b");

                day = GetRegex(line, @"\b(?:LU|MA|MI|JU|VI|SA)\b");

                startHour = int.Parse(GetRegex(line, @"\b[0-9]{4}\b|\b[0-9]{3}\b"));

                endHour = int.Parse(GetRegex(line, @"\b[0-9]{4}(?!-)\b|\b[0-9]{3}(?!-)\b"));

                classroom = GetRegex(line, @"\([0-9]+[A-Z]\)|\([0-9]+\)");

                professor = GetRegex(line, @"\) [A-Z\s]+");

                professor = professor.Remove(0, 2);

                foreach (string word in nameAux.Split(' '))
                {
                    if(!word.Equals("C") && !word.Equals("D") && !word.Equals("E"))
                    {
                        name += word;
                        name += " ";
                    }
                    else
                    {
                        break;
                    }
                }

                if(group.Equals("C") || group.Equals("D") || group.Equals("E"))
                {
                    name = name.Remove(name.Length - 1, 1);
                }
                else
                {
                    name = name.Remove(name.Length - 2, 2);
                }

                Signature signature = new Signature(name, int.Parse(id), group, day, startHour, endHour, classroom, professor);

                controller.Insert(signature);
            }
        }
        public static void Print()
        {
            foreach (Signature signature in controller.getAll())
            {
                Console.WriteLine(signature.ToString());
            }
        }
        public static string GetRegex(string line, string pattern)
        {
            string result ="";
            Regex rx = new Regex(pattern,
                RegexOptions.RightToLeft | RegexOptions.IgnoreCase);

            // Find matches.
            MatchCollection matches = rx.Matches(line);

            foreach (Match match in matches)
            {
                result = match.Value;
            }
            return result;
        }
    }
}
