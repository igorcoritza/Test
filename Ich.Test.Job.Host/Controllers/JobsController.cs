using Hangfire;
using Ich.Test.Codere.Domain.ApplicationContratcs;
using Ich.Test.Core;
using Microsoft.AspNetCore.Mvc;

namespace Ich.Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiKeyAuth] 
    public class JobsController : ControllerBase
    {
        private readonly IBackgroundJobClient _backgroundJobClient;

        public JobsController(IBackgroundJobClient backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient;
        }
        
        [HttpPost("{id}")]
        public IActionResult AddJobExecution(int id, CancellationToken cancellationToken)
        {
            _backgroundJobClient.Enqueue<ISaveApiResponseService>(service => service.Execute(id, cancellationToken));
            return Ok();
        }
    }
}