using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Persistence.EFСore
{
    public class UserTask
    {
        [Key]public int Id { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Description { get; set; }
        [Required] public int Level { get; set; }

        public Diagramm diagramm { get; set; }
        public ICollection<CodePart> CodeParts { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
