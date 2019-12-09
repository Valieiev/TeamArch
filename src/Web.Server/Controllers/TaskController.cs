using Microsoft.AspNetCore.Mvc;
using Persistence.EFСore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Shared;

namespace Web.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public ActionResult<TaskList> GetTasks()
        {
            return Ok(_taskRepository.GetList());
        }

        [HttpGet]
        public ActionResult<TasksViewModel> GetById([FromQuery] int taskId)
        {
            return Ok(_taskRepository.GetById(taskId));
        }

        [HttpPost]
        public ActionResult<TasksViewModel> Create([FromBody]TasksViewModel model)
        {
            _taskRepository.Create(model);
            return Ok(model);
        }

    }
}
