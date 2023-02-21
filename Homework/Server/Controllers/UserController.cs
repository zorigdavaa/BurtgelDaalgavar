using Microsoft.AspNetCore.Mvc;
using Homework.Shared;
using Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Homework.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<Userr> Users = new List<Userr>
        {
            new Userr{ Id = 1, Name = "Admin", Email = "Admin@gmail.com", Password = "123"}
        };

        // Post: api/<UserController>
        [HttpPost]
        public ActionResult<Userr> Post([FromBody] Userr user)
        {
            Console.WriteLine(user.Password + " " + user.Email);
            Userr foundUser = Users.FirstOrDefault(x => x.Email == user.Email);
            if (foundUser == null)
            {
                return NotFound();
            }
            else if (foundUser.Password != user.Password)
            {
                return BadRequest();
            }
            return Ok(user);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public void Get(int id)
        {
            //Userr user = Users.FirstOrDefault(x => x.Id == id);
            //if (user == null)
            //{
            //    return NotFound();
            //}
            //return Ok(user);
        }

        //// POST api/<UserController>
        //[HttpPost]
        //public void Post([FromBody] Userr user)
        //{
        //    Users.Add(user);
        //}

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Userr user = Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return;
            }
            Users.Remove(user);
        }
    }
}
