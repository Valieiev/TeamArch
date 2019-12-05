using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EFСore
{
    public class CodePart
    {
        public int Id { get; set; }
        public int UserTaskId { get; set; }
        public UserTask UserTask { get; set; }
        public string CodeText { get; set; }
    }
}
