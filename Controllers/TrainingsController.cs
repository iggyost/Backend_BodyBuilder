using Backend_BodyBuilder.ApplicationData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Backend_BodyBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingsController : Controller
    {
        public static GymtoDbContext context = new GymtoDbContext();
        [HttpGet]
        [Route("get/category/{categoryId}")]
        public ActionResult<IEnumerable<Training>> GetTrainingsByCategory(int categoryId)
        {
            try
            {
                return context.Trainings.Where(x => x.CategoryId == categoryId).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpGet]
        [Route("get/today")]
        public ActionResult<IEnumerable<Training>> GetTodayTraining()
        {
            try
            {
                return context.Trainings.OrderBy(x => Guid.NewGuid()).Take(1).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpGet]
        [Route("get/id/{trainingId}")]
        public ActionResult<Training> GetTrainingById(int trainingId)
        {
            try
            {
                var data = context.Trainings.Where(x => x.TrainingId == trainingId).FirstOrDefault();
                if (data != null)
                {
                    return data;
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
    }
}
