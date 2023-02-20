using Microsoft.AspNetCore.Mvc;
using Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WareHouseController : ControllerBase
    {

        public static List<WareHouse> wareHouses = new List<WareHouse>()
        {
            new WareHouse() { Id = 1, Name = "Central", Capacity = 200},
            new WareHouse() { Id = 2, Name = "West", Capacity = 300},
            new WareHouse() { Id = 3, Name = "East", Capacity = 300},
            new WareHouse() { Id = 4, Name = "North", Capacity = 300}
        };
        // GET: api/<WareHouseController>
        [HttpGet]
        public ActionResult<List<WareHouse>> Get()
        {
            return Ok(wareHouses);
        }

        // GET api/<WareHouseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WareHouseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WareHouseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WareHouseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
