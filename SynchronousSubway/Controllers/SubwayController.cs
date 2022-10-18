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
    public ActionResult<SubwayOrder> MakeOrder([FromBody] SubwayRequest subwayRequest)
    {
        var order = _worker.MakeOrder(subwayRequest.SubName, subwayRequest.Toasted, subwayRequest.SauceName,
            subwayRequest.CoffeeName);

        return Ok(order);
    }
}