using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace aspnetcore_web.Controllers
{
    [Route("api/[controller]")]
    public class PrivateStuffController : Controller
    {
        IConfiguration _configuration;

        public PrivateStuffController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET api/values
        [HttpGet]
        public async Task<string> Get(string value)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration["PrivateAddress"]);
                var response = await client.GetAsync(value);

                return  await response.Content.ReadAsStringAsync();  
            }
        }
    }
}
