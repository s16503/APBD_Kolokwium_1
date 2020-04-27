using Kolokwium_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_1.Services
{
    interface IMedicamentsDbService
    {
        public Medicament getMedicament(int id);
        

    }
}
