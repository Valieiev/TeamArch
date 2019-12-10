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
    public class CodePartController : ControllerBase
    {

        private readonly ICodePartRepository _codePartRepository;

        public CodePartController(ICodePartRepository codePartRepository)
        {
            _codePartRepository = codePartRepository;
        }


        [HttpGet]
        public ActionResult<CodePartList> GetList(int usertaskId)
        {
            return Ok(_codePartRepository.GetList(usertaskId));
        }

        [HttpGet]
        public ActionResult<CodePartList> GetAll()
        {
            return Ok(_codePartRepository.GetAll());
        }


        [HttpPost]
        public ActionResult<CodePartViewModel> Create([FromBody]CodePartViewModel model)
        {
            _codePartRepository.Create(model);
            return Ok(model);
        }

    }
}
