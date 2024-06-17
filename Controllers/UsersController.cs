using Backend_BodyBuilder.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_BodyBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        public static GymtoDbContext context = new GymtoDbContext();

        [HttpGet]
        [Route("enter/{email}/{password}")]
        public ActionResult<IEnumerable<User>> Enter(string email, string password)
        {
            try
            {
                var user = context.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Неверный пароль!");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpGet]
        [Route("reg/{name}/{email}/{password}")]
        public ActionResult<IEnumerable<User>> RegUser(string name, string email, string password)
        {
            try
            {
                var checkAvail = context.Users.Where(x => x.Email == email).FirstOrDefault();
                if (checkAvail == null)
                {
                    User user = new User()
                    {
                        Password = password,
                        Email = email,
                        Name = name,
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Пользователь с таким E-mail уже есть");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
    }
}
