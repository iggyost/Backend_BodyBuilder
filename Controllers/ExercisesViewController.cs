using Backend_BodyBuilder.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_BodyBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesViewController : Controller
    {
        public static GymtoDbContext context = new GymtoDbContext();
        [HttpGet]
        [Route("get/{trainingId}")]
        public ActionResult<IEnumerable<ExercisesView>> GetExercisesViewByTrainingId(int trainingId)
        {
            try
            {
                return context.ExercisesViews.Where(x => x.TrainingId == trainingId).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
    }
}
