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
        public int Number { get; set; }

        public CodePartStatus Status { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    public class CodePartList
    {
       public List<CodePartViewModel> CodeParts { get; set; }
    }

    public enum CodePartStatus
    {
        Show,
        Selected,
        Correct
    }
}