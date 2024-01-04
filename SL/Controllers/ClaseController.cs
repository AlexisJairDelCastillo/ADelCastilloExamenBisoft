using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SL.Controllers
{
    [Route("api/clase")]
    [ApiController]
    public class ClaseController : ControllerBase
    {
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            ML.Result result = BL.Clase.GetAll();

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
