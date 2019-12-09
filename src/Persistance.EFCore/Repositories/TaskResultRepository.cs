using Persistence.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Shared;

namespace Persistence.EFСore.Repositories
{
    public class TestResultRepository : ITestResultRepository
    {
        private readonly AlgorithmsDbContext _DB;


        public TestResultRepository(AlgorithmsDbContext DB)
        {
            _DB = DB;
        }

        public void Create(TestResultViewModel model)
        {
            var item = new TestResult() { Result = model.Result, StudentEmail = model.StudentEmail, TaskId = model.TaskId };
            _DB.TestResults.Add(item);
            _DB.SaveChanges();
            model.Id = item.Id;
        }

        public TestResultViewModel GetById(int id)
        {
            var result = _DB.TestResults.FirstOrDefault(x => x.Id == id);
            return new TestResultViewModel() { Id = result.Id, Result = result.Result, StudentEmail = result.StudentEmail, TaskId = result.TaskId };
        }

        public TestResultList GetList()
        {
            var item = _DB.TestResults;
            var result = (from results in _DB.TestResults
                          select new TestResultViewModel()
                          {
                              Id = results.Id,
                              Result = results.Result,
                              StudentEmail = results.StudentEmail,
                              TaskId = results.TaskId
                          }).ToList();
            TestResultList list = new TestResultList();
            list.List = result;
            return list;
        }
    }

    public interface ITestResultRepository
    {
        public void Create(TestResultViewModel model);
        public TestResultViewModel GetById(int id);
        public TestResultList GetList();
    }
}
