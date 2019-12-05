using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Shared
{
    public class DiagrammViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public int UserTaskId { get; set; }
    }

    public class DiagrammList
    {
        public IList<DiagrammViewModel> List { get; set; }
    }
}
