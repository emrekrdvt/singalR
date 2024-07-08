using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business;

namespace SignalR.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        readonly MyBusiness _myB;

        public HomeController(MyBusiness myB)
        {
            _myB = myB;
        }

        [HttpGet("{message}")]
        public async Task<IActionResult> Index(string message)
        {
            await _myB.SendMessageAsync(message);
            return Ok();
        }
    }
}
