using Persistence.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Shared;
using System.Linq;

namespace Persistence.EFСore.Repositories
{
    public class DiagrammRepository : IDiagrammRepository
    {

        private readonly AlgorithmsDbContext _DB;


        public DiagrammRepository(AlgorithmsDbContext DB)
        {
            _DB = DB;
        }

        public void Create(DiagrammViewModel model)
        {
            var item = ToDiagramm(model);
            _DB.Diagramms.Add(item);
            _DB.SaveChanges();
            model.Id = item.Id;
        }

        public DiagrammViewModel GetById(int id)
        {
            var result = _DB.Diagramms.FirstOrDefault(x=>x.Id == id);
            return new DiagrammViewModel() {Id= result.Id, ImageURL = result.ImageURL, Name = result.Name, UserTaskId= result.UserTaskId };
        }

        public DiagrammList GetList(int usertaskId)
        {
            var result = (from diagramm in _DB.Diagramms
                          select new DiagrammViewModel
                          ()
                          {
                              Id = diagramm.Id,
                              ImageURL= diagramm.ImageURL, 
                              Name = diagramm.Name, 
                              UserTaskId = diagramm.UserTaskId
                          }).ToList();
            DiagrammList list = new DiagrammList();
            list.List = result;
            return list;
        }

        private Diagramm ToDiagramm(DiagrammViewModel model)
        {
            return new Diagramm()
            {
                Id = model.Id,
                ImageURL = model.ImageURL,
                Name = model.Name,
                UserTaskId = model.UserTaskId
            };
        }
    }

    public interface IDiagrammRepository
    {
        public void Create(DiagrammViewModel model);

        public DiagrammViewModel GetById(int id);
        public DiagrammList GetList(int usertaskId);
    }
}
