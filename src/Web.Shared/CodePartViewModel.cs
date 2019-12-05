using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Shared
{
    public class CodePartViewModel
    {
        public int Id { get; set; }
        public int UserTaskId { get; set; }
        public string CodeText { get; set; }
    }

    public class CodePartList
    {
       public IList<CodePartViewModel> CodeParts { get; set; }
    }
}