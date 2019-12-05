using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Shared
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        public int UserTaskId { get; set; }
    }

    public class QuestionList
    {
        public IList<QuestionViewModel> List { get; set; }
    }
}
