using LibraryAPI.Data;
using LibraryAPI.DTO.UserDTOs;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(UserService service) : ControllerBase 
    {

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<User> users = await service.GetUsers();
            List<UserOut> users_out = new List<UserOut>();
            foreach (User user in users)
            {
                UserOut user_out = new UserOut(user);
                users_out.Add(user_out);
            }
            return Ok(users_out);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            User? user = await service.GetUser(id);

            if (user != null)
            {
                UserOut user_out = new UserOut(user);
                return Ok(user_out);
            }
            return NotFound();
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserIn userIn)
        {
            User user = new User
            {
                FirstName = userIn.FirstName,
                LastName = userIn.LastName,
                UserName = userIn.UserName,
                Email = userIn.Email,
                PhoneNumber = userIn.PhoneNumber
            };
            await service.CreateUser(user);
            return Ok("User created successfully!");
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserIn userIn)
        {
            User? user = await service.GetUser(id.ToString());
            if (user != null)
            {
                user.FirstName = userIn.FirstName;
                user.LastName = userIn.LastName;
                user.UserName = userIn.UserName;
                user.Email = userIn.Email;
                user.PhoneNumber = userIn.PhoneNumber;
                await service.UpdateUser(user);
                return Ok("User updated successfully!");
            }
            return NotFound();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            User? user = await service.GetUser(id);
            if (user != null)
            {
                await service.DeleteUser(user);
                return Ok("User deleted successfully!");
            }
            return NotFound();
        }
    }
}
