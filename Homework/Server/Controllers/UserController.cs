using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Homework.Server.Data;
using Homework.Shared.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Homework.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<Userr> Users = new List<Userr>
        {
            new Userr{ Id = 1, Name = "Admin", Email = "admin@gmail.com", Password = "123"}
        };

        // Post: api/<UserController>
        [HttpPost]
        public ActionResult<Userr> Post([FromBody] Userr user)
        {
            Debug.WriteLine("called post");
            Userr foundUser = Users.FirstOrDefault(x => x.Email.ToLower() == user.Email);
            if (foundUser == null)
            {
                return NotFound();
            }
            else if (foundUser.Password != user.Password)
            {
                Console.WriteLine("pass " + user.Password + " coming " + foundUser.Password);
                return BadRequest();
            }
            return Ok(user);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Debug.WriteLine("called get");
            //Console.WriteLine("called get");
            Userr user = Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //// POST api/<UserController>
        //[HttpPost]
        //public void Post([FromBody] Userr user)
        //{
        //    Debug.WriteLine($"Post {user.Id}");
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
