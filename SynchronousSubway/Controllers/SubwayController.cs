using Microsoft.AspNetCore.Mvc;
using SynchronousSubway.Models;
using SynchronousSubway.Workers;

namespace SynchronousSubway.Controllers;

[ApiController]
[Route("[controller]")]
public class SubwayController : ControllerBase
{
    private readonly IWorker _worker;

    public SubwayController(IWorker worker)
    {
        _worker = worker;
    }

    [HttpPost]
    public ActionResult<SubwayOrder> MakeOrder([FromBody] SubwayRequest sandwichRequest)
    {
        var order = _worker.MakeOrder(sandwichRequest.SubName, sandwichRequest.Toasted, sandwichRequest.SauceName,
            sandwichRequest.CoffeeName);

        return Ok(order);
    }
}