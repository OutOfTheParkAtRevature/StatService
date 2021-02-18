using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Repository;
using System.Net.Http;

namespace StatService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatServiceController : ControllerBase
    {
        
        static readonly HttpClient client = new HttpClient();
        string uri = "https://localhost:44337/WeatherForecast";
        [HttpGet]
        public async Task<string> getUserId()
        {
            string responseBody = " ";
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
               // HttpResponseMessage response =  client.("http://www.contoso.com/");
               // response.EnsureSuccessStatusCode();
               // string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return responseBody;
        }

        


        /*
        private readonly StatsContext _context;
        public StatServiceController(StatsContext context)
        {
            _context = context;
        }
        // GET: api/BaseballStatistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseballStatistic>>> GetBaseballStatistics()
        {
            return await _context.BaseballStatistics.ToListAsync();
        }
        */

    }
}
