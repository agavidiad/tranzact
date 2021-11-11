using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
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
        private readonly ILogger<WikiController> logger;

        public WikiController(IConfiguration configuration, IMediator mediator, ILogger<WikiController> logger)
        {
            this.configuration = configuration;
            this.mediator = mediator;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("GetData")]
        public async Task<ActionResult<IEnumerable<WikiResponse>>> GetData()
        {
            IEnumerable<WikiResponse> result = new List<WikiResponse>();

            try
            {
                result = await mediator.Send(new WikiRequest()
                {
                    lastHours = configuration.GetValue<int>("Settings:lastHours"),
                    directoryPath = configuration.GetValue<string>("Settings:DirectoryPath"),
                    compressedFilePath = configuration.GetValue<string>("Settings:CompressedFilePath")
                });
                logger.LogInformation($"Success {DateTime.UtcNow.ToLongTimeString()}");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new { esError=true, message = "Ocurrió un error, por favor intente nuevamente"});
            }
            return Ok(result);
        }
    }
}
