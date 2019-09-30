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

            return result;
        }

        public static void SplitLine(string line)
        {
            if (line != string.Empty)
            {
                string id, name, schedule, group, professor;

                id = GetRegex(line, @"\d{7}");

                name = GetRegex(line, @"[A-Z][^\d]+ ");

                group = GetRegex(line, @"\b[A-Z]\d\b|\b\d[A-Z]\b|\b[0-9]\b|\b[0-9][0-9]\b|\b[A-Z]\b");

                schedule = GetRegex(line, @"\b[A-Z]{2}\b [0-9]+-[0-9]+\([0-9]+\)|\b[A-Z]{2}\b [0-9]+-[0-9]+\([0-9A-Z]+\)");

                professor = GetRegex(line, @"\) [A-Z\s]+");

                Console.WriteLine(string.Format("ID: {0} / Nombre: {1} / Grupo: {2} / Horario: {3} / Docente: {4} \n", id, name, group, schedule, professor));
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
