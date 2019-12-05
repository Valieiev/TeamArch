using Persistence.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Shared;

namespace Persistence.EFСore.Repositories
{
    public class CodePartRepository : ICodePartRepository
    {
        private readonly AlgorithmsDbContext _DB;
        public CodePartRepository(AlgorithmsDbContext DB)
        {
            _DB = DB;
        }
        public void Create(CodePartViewModel model)
        {
            var item = ToCodePart(model);
            _DB.Add(item);
            _DB.SaveChanges();
            model.Id = item.Id;
        }

        public CodePartList GetList(int id)
        {
            var result = (from part in _DB.CodeParts
                          select new CodePartViewModel
                          ()
                          {
                              Id = part.Id,
                              CodeText = part.CodeText,
                              UserTaskId = part.UserTaskId
                          }).ToList();
            CodePartList list = new CodePartList();
            list.CodeParts = result;
            return list;
        }

        private CodePart ToCodePart(CodePartViewModel model)
        {
            return new CodePart()
            {
                CodeText = model.CodeText,
                Id = model.Id,
                UserTaskId = model.UserTaskId,
                UserTask = _DB.UserTasks.Where(x => x.Id == model.UserTaskId).FirstOrDefault()
            };
        }
    }

    public interface ICodePartRepository
    {
        public void Create(CodePartViewModel model);

        public CodePartList GetList(int id);
    }
}
