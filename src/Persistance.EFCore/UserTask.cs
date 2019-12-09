using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Persistence.EFСore
{
    // Класс з теорією. Містить в собі багато діаграмм, частин коду і питань.
    // Класи в яких є ICollection мають выдношення багато до одного. Тобто в класі де є ICollection є той клас приймає в себе багато елементів.
    public class UserTask 
    {
        [Key]public int Id { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Description { get; set; }
        [Required] public int Level { get; set; }

        public ICollection<Diagramm> Diagramms { get; set; }
        public ICollection<CodePart> CodeParts { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
