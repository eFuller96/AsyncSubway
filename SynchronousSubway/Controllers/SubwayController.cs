using Microsoft.AspNetCore.Mvc;
using SynchronousSubway.Models;
using SynchronousSubway.Workers;

namespace SynchronousSubway.Controllers;

[ApiController]
[Route("[controller]")]
public class SubwayController : ControllerBase
{
    private readonly IWorker _ellie;

    public SubwayController(IWorker ellie)
    {
        _ellie = ellie;
    }

    [HttpPost]
    public ActionResult<SubwayOrder> MakeOrder([FromBody] SubwayRequest sandwichRequest)
    {
        var order = _ellie.MakeOrder(sandwichRequest.SubName, sandwichRequest.Toasted, sandwichRequest.SauceName,
            sandwichRequest.CoffeeName);

        return Ok(order);
    }
}