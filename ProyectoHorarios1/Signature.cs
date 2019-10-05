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
        public string Day { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public string Clasroom { get; set; }
        public string Professor { get; set; }

        public Signature(string name, int id, string group, string day, int startHour, int endHour, string clasroom, string professor)
        {
            this.Name = name;
            this.Id = id;
            this.Group = group;
            this.Day = day;
            this.StartHour = startHour;
            this.EndHour = endHour;
            this.Clasroom = clasroom;
            this.Professor = professor;
        }

        public Signature() { }

        public override string ToString()
        {
            return string.Format("ID: {0}, Nombre: {1}, Grupo: {2}, Horario: {3} {4} {5} {6}, Docente: {7} \n", 
                this.Id, this.Name, this.Group, this.Day, this.StartHour, this.EndHour, this.Clasroom, this.Professor);
        }
    }
}
