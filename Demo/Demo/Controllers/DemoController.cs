using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

[ApiController]
[Route("[controller]")]
public class DemoController : ControllerBase
{
    private IMediator _mediator;
    public IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    public DemoController(ILogger<DemoController> logger) {

    }
    
    [HttpGet]
    public async Task<ActionResult> Get() {
        
        var demoCmd = new DemoCommand { Text = null };
        await Mediator.Send(demoCmd);

        return Ok();
    }
}