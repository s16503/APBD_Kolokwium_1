using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium_1.Responses;
using Kolokwium_1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium_1.Controllers
{
    [Route("api/medicaments")]
    [ApiController]
    public class MedicamentesController : ControllerBase
    {
         private readonly IMedicamentsDbService MedicamentsService;

        public MedicamentesController (IMedicamentsDbService _service)
        {
            this.MedicamentsService = _service;
        }


        [HttpGet("{id}")]   
        public IActionResult GetMedicament(int id)
        {
              
            try
            {
                GetMedicamentResponse res = MedicamentsService.getMedicament(id);
                return Ok(res);

            } catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
           
            
        }


        [HttpDelete("{id}")]
        public IActionResult DeletePatient(string id)    
        {
           
            return Ok( MedicamentsService.DeletePatient(id));
        }




    }
}