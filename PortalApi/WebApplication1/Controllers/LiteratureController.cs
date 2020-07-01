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
    public class LiteratureController : ControllerBase
    {
        private readonly ILiteratureService service;

        public LiteratureController(ILiteratureService literatureService)
        {
            this.service = literatureService;
        }
        // GET: api/Literature/literature
        [HttpGet]
        public async Task<ActionResult<IList<Literature>>> GetLiterature()
        {
            return service.GetAll();
        }

        // GET: api/Literature/notapproved
        [HttpGet("notapproved")]
        public IActionResult GetNotApproved()
        {
            var literature = service.GetNotApproved();

            return Ok(literature);
        }
    }
}