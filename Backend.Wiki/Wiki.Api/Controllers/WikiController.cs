using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wiki.Application.Data.Queries.GetData;

namespace Wiki.Api.Controllers
{
    [Route("api/[controller]")]
    public class WikiController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IMediator mediator;

        public WikiController(IConfiguration configuration, IMediator mediator)
        {
            this.configuration = configuration;
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("GetData")]
        public async Task<ActionResult<IEnumerable<WikiResponse>>> GetData()
        {
            var result = await mediator.Send(new WikiRequest()
            {
                lastHours = configuration.GetValue<int>("Settings:lastHours"),
                directoryPath = configuration.GetValue<string>("Settings:DirectoryPath"),
                compressedFilePath = configuration.GetValue<string>("Settings:CompressedFilePath")
            });
            return Ok(result);
        }
    }
}
