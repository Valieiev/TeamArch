using Persistence.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Shared;
using System.Linq;

namespace Persistence.EFСore.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AlgorithmsDbContext _DB;
        public QuestionRepository(AlgorithmsDbContext DB)
        {
            _DB = DB;
        }
        public void Create(QuestionViewModel model)
        {
            var item = ToQuestion(model);
            _DB.Questions.Add(item);
            _DB.SaveChanges();
            model.Id = item.Id;
            
        }

        public QuestionViewModel GetById(int id)
        {
            var result = _DB.Questions.FirstOrDefault(x=>x.Id == id);
            return new QuestionViewModel() {Id = result.Id, Answer = result.Answer, Text = result.Text, UserTaskId = result.UserTaskId };
        }

        public QuestionList GetList(int usertaskId)
        {
            var item = _DB.Questions;
            var result = (from question in _DB.Questions
                          where question.UserTaskId == usertaskId
                          select new QuestionViewModel()
                          {
                              Id = question.Id,
                              Answer = question.Answer,
                              Text = question.Text,
                              UserTaskId = question.UserTaskId
                          }).ToList();
            QuestionList list = new QuestionList();
            list.List = result;
            return list;
        }

        public Question ToQuestion(QuestionViewModel model)
        {
            return new Question()
            {
                Id = model.Id,
                Answer = model.Answer,
                Text = model.Text,
                UserTaskId = model.UserTaskId
            };
        }
    }

    public interface IQuestionRepository
    {
        public void Create(QuestionViewModel model);

        public QuestionList GetList(int usertaskId);

        public QuestionViewModel GetById(int id);
    }
}
