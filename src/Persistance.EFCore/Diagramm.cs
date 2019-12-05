using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Persistence.EFСore
{
    public class Diagramm
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string ImageURL { get; set; }
        public int UserTaskId { get; set; }
        public UserTask UserTask { get; set; }
    }
}
