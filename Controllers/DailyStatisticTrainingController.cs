using Backend_BodyBuilder.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_BodyBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyStatisticTrainingController : Controller
    {
        public static GymtoDbContext context = new GymtoDbContext();
        [HttpGet]
        [Route("get/{userId}")]
        public ActionResult<IEnumerable<DailyStatisticTraining>> GetDailyStatisticTrainingByUserId(int userId)
        {
            try
            {
                return context.DailyStatisticTrainings.Where(x => x.UserId == userId).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }

        }
        [HttpGet]
        [Route("update/{userId}/{trainingId}")]
        public ActionResult<IEnumerable<DailyStatisticTraining>> UpdateDailyStatisticTraining(int userId, int trainingId)
        {
            try
            {
                DailyStatisticTraining dailyStatisticTraining = new DailyStatisticTraining()
                {
                    TrainingId = trainingId,
                    UserId = userId,
                    Date = DateTime.Now.Date,
                    Completed = true
                };
                context.DailyStatisticTrainings.Add(dailyStatisticTraining);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }

        }
    }
}
