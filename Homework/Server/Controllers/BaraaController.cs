using Microsoft.AspNetCore.Mvc;
using Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaraaController : ControllerBase
    {
        public static List<WareHouse> wareHouses = new List<WareHouse>()
        {
            new WareHouse() { Id = 1, Name = "Central", Capacity = 200},
            new WareHouse() { Id = 2, Name = "West", Capacity = 300},
            new WareHouse() { Id = 3, Name = "East", Capacity = 300},
            new WareHouse() { Id = 4, Name = "North", Capacity = 300}
        };
        public static List<Baraa> baraaList = new List<Baraa>()
        {
            new Baraa{Id = 1, Name = "Chiher"},
            new Baraa{Id = 2, Name = "Jims"},
            new Baraa{Id = 3, Name = "Chocolate"},
            new Baraa{Id = 4, Name = "Jims"}
        };

        // GET: api/<BaraaController>
        [HttpGet]
        public async Task<ActionResult<List<Baraa>>> Get()
        {
            return Ok(baraaList);
        }

        // GET api/<BaraaController>/5
        [HttpGet("{id}")]
        public ActionResult<Baraa> Get(int id)
        {
            Baraa baraa = baraaList.FirstOrDefault(x => x.Id == id);
            if (baraa == null)
            {
                NotFound("Tiim Baraa Alga");
            }
            return Ok(baraa);
        }

        // POST api/<BaraaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<BaraaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BaraaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
