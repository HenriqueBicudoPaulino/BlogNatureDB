using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogNatureDB.Controllers
{
    [Authorize] // Exige autenticação para acessar qualquer endpoint desta controller
    [ApiController]
    [Route("api/protegido")]
    public class ProtectedController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Você acessou um endpoint protegido!");
        }
    }
}
