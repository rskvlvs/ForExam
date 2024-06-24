using Microsoft.AspNetCore.Mvc;

namespace Task19.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController:Controller 
    {
        public IMyDIinterface imydiinterface;

        public HomeController(IMyDIinterface mydiinterface)
        {
            imydiinterface = mydiinterface;
        }

        [HttpPost]
        public ActionResult<string> postMethod([FromBody] string value)
        {
            return imydiinterface.method(value);
        }
    }
}
