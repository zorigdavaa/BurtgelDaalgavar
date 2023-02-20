using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaraaController : ControllerBase
    {

        public static List<Baraa> baraaList = new List<Baraa>()
        {
            new Baraa{Id = 1, Name = "Chiher", Price = 10, Meas = UnitMeas.KG},
            new Baraa{Id = 2, Name = "Jims", Price = 20, Meas = UnitMeas.Boodol},
            new Baraa{Id = 3, Name = "Chocolate", Price = 30, Meas = UnitMeas.Box},
            new Baraa{Id = 4, Name = "Mashin", Price = 40, Meas = UnitMeas.Unit}
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
                return NotFound();
            }
            return Ok(baraa);
        }

        // POST api/<BaraaController>
        [HttpPost]
        public void Post([FromBody] Baraa addingBaraa)
        {
            baraaList.Add(addingBaraa);
        }

        // PUT api/<BaraaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Baraa value)
        {
            //Baraa baraa = baraaList.Find(x=>x.Id == id);
            Baraa editn = baraaList.FirstOrDefault(x => x.Id == id);
            int index = baraaList.IndexOf(editn);
            if (editn == null)
            {
                return NotFound();
            }
            baraaList[index] = value;
            return Ok();
        }

        // DELETE api/<BaraaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Baraa removingBaraa = baraaList.FirstOrDefault(x => x.Id == id);
            if (removingBaraa == null)
            {
                return NotFound();
            }
            baraaList.Remove(removingBaraa);
            return Ok();
        }
    }
}
