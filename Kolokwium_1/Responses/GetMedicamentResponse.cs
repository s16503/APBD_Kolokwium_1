using Kolokwium_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_1.Responses
{
    public class GetMedicamentResponse
    {
        public Medicament Medicament { get; set; }
        public List<Prescription> Prescriptions { get; set; }

    }
}
