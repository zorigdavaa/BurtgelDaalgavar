using Homework.Server.Data;
using Homework.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WareHouseController : ControllerBase
    {
        AppDbContext _db;
        public WareHouseController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/<WareHouseController>
        [HttpGet]
        public ActionResult<List<WareHouse>> Get()
        {
            Debug.WriteLine("Count of warehouse if " + _db.WareHouse.ToList().Count);
            return Ok(_db.WareHouse.ToList());
        }
        // GET: api/<WareHouseController>/tra
        [HttpGet("tra")]
        public ActionResult<List<TransactionProd>> GetTransactions()
        {
            return Ok(_db.Transactions);
        }
        // GET: api/<WareHouseController>/trafrom/5
        [HttpGet("trafrom/{id}")]
        public async Task<ActionResult<List<TransactionProd>>> GetTransactionsFromWareHouse(int id)
        {
            List<TransactionProd> transactions = await _db.Transactions.Where(x => x.FromWareHouseId == id).ToListAsync();
            if (transactions.Count == 0)
            {
                return NotFound();
            }
            return Ok(transactions);
        }
        // GET: api/<WareHouseController>/trato/5
        [HttpGet("trato/{id}")]
        public async Task<ActionResult<List<TransactionProd>>> GetTransactionsToWareHouse(int id)
        {
            List<TransactionProd> transactions = await _db.Transactions.Where(x => x.ToWareHouseId == id).ToListAsync();
            if (transactions.Count == 0)
            {
                return NotFound();
            }
            return Ok(transactions);
        }

        // POST api/<WareHouseController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TransactionProd transfer)
        {
            WareHouse? fromWareHouse = await _db.WareHouse.FindAsync(transfer.FromWareHouseId);
            WareHouse? toWarehouse = await _db.WareHouse.FindAsync(transfer.ToWareHouseId);
            Product? fromHouseProduct = fromWareHouse?.Items.Find(x => x.Id == transfer.Product.Id);
            Product? toWareHouseProduct = toWarehouse?.Items.Find(x => x.Id == transfer.Product.Id);
            if (toWarehouse != null)
            {
                if (transfer.FromWareHouseId != 0 && fromHouseProduct != null)
                {
                    if (fromHouseProduct.Count < transfer.Count)
                    {
                        return BadRequest();
                    }
                    fromHouseProduct.Count -= transfer.Count;
                    if (fromHouseProduct.Count < 1)
                    {
                        fromWareHouse.Items.Remove(fromHouseProduct);
                    }
                }
                if (toWareHouseProduct == null)
                {
                    Product addingProduct = transfer.Product;
                    addingProduct.Count = transfer.Count;
                    toWarehouse.Items.Add(addingProduct);
                }
                else
                {
                    toWareHouseProduct.Count += transfer.Count;
                }
                _db.Transactions.Add(transfer);
                _db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/<WareHouseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WareHouseController>/delete
        [HttpGet("delete")]
        public void Delete(int id)
        {
            _db.DeleteDB();
        }
    }
}
