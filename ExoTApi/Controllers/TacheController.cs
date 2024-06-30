using ExoTApi.Repositories;
using ExoTModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacheController : ControllerBase
    {
        private readonly ITacheRepository _service;

        public TacheController(ITacheRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult RecuperationTotale() 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_service.RecuperationTotale());
        }

        [HttpGet("Id")]
        public IActionResult RecuperationParId(int Id)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }
            return Ok(_service.RecuperationParId(Id));
        }

        [HttpPost]
        public IActionResult Creer(TacheCreation Tache)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _service.Creer(Tache);

            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Suppression(int Id)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            _service.Suppression(Id);

            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Modification(int Id,TacheUpdate tache)
        {
            if(!ModelState.IsValid)
            {
              return BadRequest(ModelState); 
            }
            _service.Modification(Id,tache);
            return Ok();
        }

    }
}
