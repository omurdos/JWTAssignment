using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [Route("Admin"), Authorize(Roles = "Admin")]
        public IActionResult SupAdmin()
        {
            return Ok(new { Message = "Sup, Admin" });
        }
        [Route("User"), Authorize(Roles = "Normal")]
        public IActionResult SupUser()
        {
            return Ok(new { Message = "Sup, User" });
        }
    }
}
