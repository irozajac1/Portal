using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentationController : ControllerBase
    {
        private readonly IPortalService _service;

        public DocumentationController(IPortalService service)
        {
            _service = service;
        }

        //Get: api/Documentation/documentation
        [HttpGet("documentation")]
        public List<Documentation> getDocumentation()
        {
            return _service.GetAllDocumentation();
        }

        //Get: api/Documentation/documentationById
        [HttpGet("documentationById/{id}")]
        public Documentation getDocumentationById(Guid id)
        {
            return _service.getById(id);
        }

        //Get: api/Documentation/documentationByGroup
        [HttpGet("documentationByGroup")]
        public List<Documentation> getByGroupName(string group)
        {
            return _service.getByGroupName(group);
        }

        // POST: api/Documentation/sendDocumentation
        [HttpPost("sendDocumentation")]
        public void postDocumentation(Documentation documentation)
        {
            _service.addDocumentation(documentation);
        }

        //DELETE: api/Documentation/deleteDocumentation
        [HttpDelete("deleteDocumentation")]
        public void deleteDocumentation(Documentation documentation)
        {
            _service.deleteDocumentation(documentation);
        }
    }
}