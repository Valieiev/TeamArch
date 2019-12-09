using Persistence.EFСore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class TaskFactory // Патерн фабрика, вертає об'єкт готовий до роботи з бізнес процесом.
    {
        public QuestionRepository QuestionRepository { get; private set; }
        public DiagrammRepository DiagrammRepository { get; private set; }
        public CodePartRepository CodePartRepository { get; set; }

        public TaskFactory(QuestionRepository questionRepository, DiagrammRepository diagrammRepository, CodePartRepository codePartRepository  )

        {
            QuestionRepository = questionRepository;
            DiagrammRepository = diagrammRepository;
            CodePartRepository = codePartRepository;
        }


        public UserTaskBusiness Create(string title, string description, int level)
        {
            return new UserTaskBusiness() { Title = title, Description = description,Level = level, CodePartRepository = CodePartRepository, DiagrammRepository = DiagrammRepository, QuestionRepository = QuestionRepository };
        }
        public UserTaskBusiness Create(int id,string title, string description, int level)
        {
            return new UserTaskBusiness() {Id = id, Title = title, Description = description, Level = level, CodePartRepository = CodePartRepository, DiagrammRepository = DiagrammRepository, QuestionRepository = QuestionRepository };
        }
    }

    public interface ITaskFactory
    {
        public UserTaskBusiness Create(string title, string description, int level);
        public UserTaskBusiness Create(int id, string title, string description, int level);
        
    }
}
