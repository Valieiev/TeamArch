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

        public void Create(TasksViewModel model)
        {
            var item = ToUserTask(model);
            _DB.UserTasks.Add(item);
            _DB.SaveChanges();
            model.Id = item.Id;
        }

        public TasksViewModel GetById(int id)
        {
            var result = _DB.UserTasks.FirstOrDefault(x => x.Id == id);
            return new TasksViewModel() {Id = result .Id, Description = result.Description, Level = result .Level, Title= result.Title};
        }

        public TaskList GetList()
        {
          var result = (from task in _DB.UserTasks
                              select new TasksViewModel
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

        private UserTask ToUserTask(TasksViewModel model)
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
        public void Create(TasksViewModel model);
        public TasksViewModel GetById(int id);
        public TaskList GetList();
    }
}
