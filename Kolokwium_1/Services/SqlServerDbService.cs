using Kolokwium_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_1.Services
{
    public class SqlServerDbService : IMedicamentsDbService
    {
        private string myConnection = "Data Source=db-mssql;Initial Catalog=s16503;Integrated Security=True;";
        public Medicament getMedicament(int id)
        {
           
        }
    }
}
