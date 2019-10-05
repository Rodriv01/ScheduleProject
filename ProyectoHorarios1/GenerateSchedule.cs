using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHorarios1
{
    public static class GenerateSchedule
    {
        private static Controller controller = new Controller();

        private static List<Signature> signatures = controller.getAll();

        private static Dictionary<string, HashSet<string>> schedules = new Dictionary<string, HashSet<string>>();

        private static HashSet<string> groups = new HashSet<string>();

        public static void Generate(string signatureName)
        {
            foreach (var signature in signatures)
            {
                if (signature.Name == signatureName)
                {
                    groups.Add(signature.Group);

                }
            }
            schedules.Add(signatureName, groups);
            foreach (var item in schedules)
            {
                if (signatureName == item.Key)
                {
                    Console.WriteLine("Grupos de la materia: {0}", item.Key);
                    foreach (var group in item.Value)
                    {
                        Console.WriteLine(group);
                    }
                }
            }
            Console.WriteLine("-------------------------------------------------------");
        }
    }
}
