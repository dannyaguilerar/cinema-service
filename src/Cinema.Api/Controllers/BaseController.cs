using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{        

    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

}
