﻿using Homework.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared;
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

        public static List<Product> baraaList = new List<Product>()
        {
            new Product{Id = 1, Name = "Chiher", Price = 10, Meas = UnitMeas.KG},
            new Product{Id = 2, Name = "Jims", Price = 20, Meas = UnitMeas.Boodol},
            new Product{Id = 3, Name = "Chocolate", Price = 30, Meas = UnitMeas.Box},
            new Product{Id = 4, Name = "Mashin", Price = 40, Meas = UnitMeas.Unit}
        };

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
        public void Post([FromBody] Product addingBaraa)
        {
            _AppDb.Product.Add(addingBaraa);
            _AppDb.SaveChanges();
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
