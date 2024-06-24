using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Task20_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public async Task<IEnumerable<posilka>> Get()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7063/Home");
            var myObjects = JsonConvert.DeserializeObject<List<posilka>>(response);
            return myObjects;
        }
    }
    public class posilka
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }
    }
}
