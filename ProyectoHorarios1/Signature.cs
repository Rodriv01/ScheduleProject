using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHorarios1
{
    public class Signature
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Group { get; set; }
        public string Schedule { get; set; }
        public string Professor { get; set; }
        public List<Signature> signatures { get; set; }

        public Signature(string name, int id, string group, string schedule, string professor)
        {
            this.Name = name;
            this.Id = id;
            this.Group = group;
            this.Schedule = schedule;
            this.Professor = professor;

            this.signatures.Add(this);
        }
    }
}
