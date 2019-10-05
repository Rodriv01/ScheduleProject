using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProyectoHorarios1
{
    class Program
    {
        static void Main(string[] args)
        {
            TextReader reader = new TextReader("Resources/Horarios Sistemas II-2019.pdf");
            reader.Insert();
            List<string> selectedSignatures = new List<string>
            {
                "INGLES I",
                "INTRODUCCION A LA PROGRAMACION"
            };
            foreach (string signature in selectedSignatures)
            {
                GenerateSchedule.Generate(signature);
            }
            Console.ReadKey();
        }
    }
}