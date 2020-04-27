using Kolokwium_1.Models;
using Kolokwium_1.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_1.Services
{
    public interface IMedicamentsDbService
    {
        public GetMedicamentResponse getMedicament(int id);
        

    }
}
