using Persistence.EFСore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class UserTaskBusiness
    {
        public int Id { get; set; }
         public string Title { get; set; }
         public string Description { get; set; }
        public int Level { get; set; }

        public QuestionRepository QuestionRepository { get; set; }
        public DiagrammRepository DiagrammRepository { get; set; }
        public CodePartRepository CodePartRepository { get; set; }
    }
}
