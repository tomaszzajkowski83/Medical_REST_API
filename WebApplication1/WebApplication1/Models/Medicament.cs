using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Medicament
    {
        public Medicament()
        {
            Prescriptions = new HashSet<Prescription_Medicament>();
        }
        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public ICollection<Prescription_Medicament> Prescriptions { get; set; }
    }
}
