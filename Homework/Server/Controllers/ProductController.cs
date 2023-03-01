using Homework.Server.Data;
using Homework.Shared.DTO;
using Homework.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        AppDbContext _AppDb;
        public ProductController(AppDbContext db)
        {
            _AppDb = db;
        }

        // GET: api/<BaraaController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(await _AppDb.Product.ToListAsync());
        }

        // GET api/<BaraaController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            //Product baraa = baraaList.FirstOrDefault(x => x.Id == id);
            Product? baraa = _AppDb.Product.FirstOrDefault(x => x.Id == id);
            if (baraa == null)
            {
                return NotFound();
            }
            return Ok(baraa);
        }

        // POST api/<BaraaController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product addingBaraa)
        {
            //WareHouse? wareHouse = await _AppDb.WareHouse.FindAsync(addingBaraa.WareHouseId);
            Product? lastOne = _AppDb.Product.LastOrDefault();
            int code = lastOne != null ? lastOne.Code : 0;
            Debug.WriteLine("Product post request received");
            Product product = new Product
            {
                Id = addingBaraa.Id,
                Meas = addingBaraa.Meas,
                Name = addingBaraa.Name,
                Price = addingBaraa.Price,
                Code = code + 1
            };
            _AppDb.Product.Add(product);
            await _AppDb.SaveChangesAsync();
            return Ok();
        }

        // PUT api/<BaraaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Product value)
        {
            //Baraa baraa = baraaList.Find(x=>x.Id == id);
            //Product editn = _AppDb.Product.FirstOrDefault(x => x.Id == id);
            //int index = baraaList.IndexOf(editn);
            //if (editn == null)
            //{
            //    return NotFound();
            //}
            //baraaList[index] = value;
            //return Ok();
            var product = await _AppDb.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            // Update the properties of the product with the data from the value object
            product.Name = value.Name;
            product.Price = value.Price;
            product.Meas = value.Meas;

            // Save the changes to the database
            await _AppDb.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<BaraaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Product removingBaraa = await _AppDb.Product.FindAsync(id);
            if (removingBaraa == null)
            {
                return NotFound();
            }
            _AppDb.Product.Remove(removingBaraa);
            _AppDb.SaveChanges();
            return Ok();
        }
    }
}
