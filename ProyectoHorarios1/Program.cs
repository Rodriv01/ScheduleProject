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

            reader.Print();

            Console.ReadKey();
        }
    }
}
