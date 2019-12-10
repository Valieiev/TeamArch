using Persistence.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Shared;

namespace Persistence.EFСore.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AlgorithmsDbContext _DB;


        public TaskRepository(AlgorithmsDbContext DB)
        {
            _DB = DB;
        }

        public void Create(TaskViewModel model)
        {
            var item = ToUserTask(model);
            _DB.UserTasks.Add(item);
            _DB.SaveChanges();
            model.Id = item.Id;
        }

        public TaskViewModel GetById(int id)
        {
            var result = _DB.UserTasks.FirstOrDefault(x => x.Id == id);
            return new TaskViewModel() {Id = result .Id, Description = result.Description, Level = result .Level, Title= result.Title};
        }

        public TaskList GetList()
        {
          var result = (from task in _DB.UserTasks
                              select new TaskViewModel
                              () 
                              {
                                 Id = task.Id,
                                 Description = task.Description,
                                 Level = task.Level,
                                 Title = task.Title
                              }).ToList();
            TaskList list = new TaskList();
            list.Tasks = result;
            return list;
        }

        private UserTask ToUserTask(TaskViewModel model)
        {
            return new UserTask()
            {
                Description = model.Description,
                Level = model.Level,
                Title = model.Title
            };
        }
    }

    public interface ITaskRepository
    {
        public void Create(TaskViewModel model);
        public TaskViewModel GetById(int id);
        public TaskList GetList();
    }
}
