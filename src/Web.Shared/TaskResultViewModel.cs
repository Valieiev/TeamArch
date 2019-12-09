using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Shared
{
    public class TestResultViewModel
    {
        public int Id { get; set; }
        public string StudentEmail { get; set; }
        public int Result { get; set; }
        public int TaskId { get; set; }
    }

    public class TestResultList
    {
       public IList<TestResultViewModel> List { get; set; }
    }
}
