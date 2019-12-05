using Microsoft.AspNetCore.Mvc;
using Persistence.EFСore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Shared;

namespace Web.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {

        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [HttpGet]
        public ActionResult<QuestionList> GetQuestion(int usertaskId)
        {
            return Ok(_questionRepository.GetList(usertaskId));
        }


        [HttpPost]
        public ActionResult<QuestionViewModel> Create([FromBody]QuestionViewModel model)
        {
            _questionRepository.Create(model);
            return Ok(model);
        }

    }
}
