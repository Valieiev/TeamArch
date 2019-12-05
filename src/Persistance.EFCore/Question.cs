using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EFСore
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        public int UserTaskId { get; set; }
        public UserTask UserTask { get; set; }
    }
}
