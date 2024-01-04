using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SL.Controllers
{
    [Route("api/ciclista")]
    [ApiController]
    public class CiclistaController : ControllerBase
    {
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            ML.Result result = BL.Ciclista.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("getbyid/{idCiclista}")]
        public IActionResult GetById(int idCilcista)
        {
            ML.Result result = BL.Ciclista.GetById(idCilcista);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] ML.Ciclista ciclista)
        {
            ML.Result result = BL.Ciclista.Add(ciclista);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("update/{idCiclista}")]
        public IActionResult Update(int idCiclista, [FromBody] ML.Ciclista cilclista)
        {
            ML.Result result = BL.Ciclista.Update(cilclista);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
