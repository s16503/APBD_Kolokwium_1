using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_1.Models
{
    public class Prescription
    {
        public int IdPresc { get; set; }
        public string Date { get; set; }
        public string DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public int Dose { get; set; }
        public string Details { get; set; }

    }
}
