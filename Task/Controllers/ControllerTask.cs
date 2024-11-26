using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Models;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerTask : ControllerBase
    {
        using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Models;

namespace Task.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class TaskController : ControllerBase
        {
            private static List<ModelTask> modelTasks = new List<ModelTask>();

            [HttpGet]
            public ActionResult<List<ModelTask>> SearchTask()
            {
                return Ok(modelTasks);
            }

            [HttpPost]
            public ActionResult<ModelTask> AddTask(ModelTask newTask)
            {
                if (newTask.Description.Length < 10)
                {
                    return BadRequest("Need more characters");
                }

                newTask.Id = modelTasks.Count > 0 ? modelTasks[modelTasks.Count - 1].Id + 1 : 1;

                return Ok(newTask);
            }


            [HttpDelete("{id}")]
            public ActionResult<ModelTask> RemoveTask(int id)
            {
                var finded = modelTasks.Find(x => x.Id == id);

                if (finded is null)
                    return NotFound("This task doesn't exist");


                modelTasks.Remove(finded);
                return Ok();
            }


        }
    }
}
}
