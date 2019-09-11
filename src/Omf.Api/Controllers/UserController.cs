using Omf.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using System.Threading.Tasks;

namespace Omf.Api.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IBusClient _busClient;

        public UserController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {
            await _busClient.PublishAsync(command);

            return Accepted();
        }
    }
}