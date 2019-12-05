using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Shared
{
    public class TasksViewModel
    {
        [Key] public int Id { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Description { get; set; }
        [Required] public int Level { get; set; }
    }

    public class TaskList
    {
       public List<TasksViewModel>  Tasks { get; set; }
    }
}
