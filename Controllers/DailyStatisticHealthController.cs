using Backend_BodyBuilder.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_BodyBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyStatisticHealthController : Controller
    {
        public static GymtoDbContext context = new GymtoDbContext();
        [HttpGet]
        [Route("get/{userId}")]
        public ActionResult<IEnumerable<DailyStatisticHealth>> GetDailyStatisticHealthByUserId(int userId)
        {
            try
            {
                return context.DailyStatisticHealths.Where(x => x.UserId == userId).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpGet]
        [Route("update/{userId}/{trainingId}")]
        public ActionResult<IEnumerable<DailyStatisticHealth>> UpdateDailyStatisticHealth(int userId, int trainingId)
        {
            try
            {
                var selectedDailyStatistic = context.DailyStatisticHealths.Where(x => x.UserId == userId && x.Date == DateTime.Now.Date).FirstOrDefault();
                if (selectedDailyStatistic != null)
                {
                    selectedDailyStatistic.Calories += context.Trainings.Where(x => x.TrainingId == trainingId).Select(x => x.Calories).FirstOrDefault();
                    selectedDailyStatistic.SpentTime += context.Trainings.Where(x => x.TrainingId == trainingId).Select(x => x.TrainingTime).FirstOrDefault();
                    context.Update(selectedDailyStatistic);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    DailyStatisticHealth dailyStatisticHealth = new DailyStatisticHealth()
                    {
                        Calories = context.Trainings.Where(x => x.TrainingId == trainingId).Select(x => x.Calories).FirstOrDefault(),
                        SpentTime = context.Trainings.Where(x => x.TrainingId == trainingId).Select(x => x.TrainingTime).FirstOrDefault(),
                        Date = DateTime.Now.Date,
                        UserId = userId,
                    };
                    context.DailyStatisticHealths.Add(dailyStatisticHealth);
                    context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
    }
}
