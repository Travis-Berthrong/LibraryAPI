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
        public async Task<IActionResult> Post([FromBody] UserIn user_dto)
        {
            User user = new User
            {
                FirstName = user_dto.FirstName,
                LastName = user_dto.LastName,
                UserName = user_dto.UserName,
                Email = user_dto.Email,
                PhoneNumber = user_dto.PhoneNumber
            };
            await service.CreateUser(user);
            return Ok("User created successfully!");
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
