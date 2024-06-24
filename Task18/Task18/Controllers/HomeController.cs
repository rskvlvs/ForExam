using Microsoft.AspNetCore.Mvc;

namespace Task18.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult<string> makeView([FromQuery] string localhost)
        {
            return $"Response From Get {localhost}";
        }

        [HttpPost]
        public ActionResult<int> getModel([FromBody] int smth)
        {
            return 52;
        }

        [HttpPut]
        public ActionResult<string> put([FromQuery] string value)
        {
            return ($"Response From Put {value}");
        }

        [HttpDelete]
        public ActionResult<string> delete([FromBody] string mes)
        {
            return ($"Response From Delete {mes}");
        }
            
    }
}
