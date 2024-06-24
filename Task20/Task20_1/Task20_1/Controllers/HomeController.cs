using Microsoft.AspNetCore.Mvc;

namespace Task20_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<posilka> Get()
        {
            List<posilka> posilkas = new List<posilka>();
            posilkas.Add(new posilka { id = 1, name = "pole1", description = "descr1" });
            posilkas.Add(new posilka { id = 2, name = "pole2", description = "descr2" });
            posilkas.Add(new posilka { id = 3, name = "pole3", description = "descr3" });
            return posilkas;
        }
    }

    public class posilka
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }
    }
}


