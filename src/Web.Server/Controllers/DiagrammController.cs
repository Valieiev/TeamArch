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
    public class DiagrammController : ControllerBase
    {

        private readonly IDiagrammRepository _diagrammRepository;

        public DiagrammController(IDiagrammRepository diagrammRepository)
        {
            _diagrammRepository = diagrammRepository;
        }

        [HttpGet]
        public ActionResult<DiagrammViewModel> GetDiagramm(int id)
        {
            return Ok(_diagrammRepository.GetById(id));
        }

        [HttpGet]
        public ActionResult<DiagrammList> GetDiagrammList()
        {
            return Ok(_diagrammRepository.GetList());
        }


        [HttpPost]
        public ActionResult<DiagrammViewModel> Create([FromBody]DiagrammViewModel model)
        {
            _diagrammRepository.Create(model);
            return Ok(model);
        }

    }
}
