using Microsoft.AspNetCore.Mvc;

namespace Omf.Api.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from API");
    }
}