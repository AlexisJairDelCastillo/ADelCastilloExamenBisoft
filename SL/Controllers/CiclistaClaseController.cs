using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SL.Controllers
{
    [Route("api/ciclistaclase")]
    [ApiController]
    public class CiclistaClaseController : ControllerBase
    {
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            ML.Result result = BL.CiclistaClase.GetAll();

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
