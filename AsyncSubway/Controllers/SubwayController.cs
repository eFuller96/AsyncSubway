using AsyncSubway.Models;
using AsyncSubway.Workers;
using Microsoft.AspNetCore.Mvc;

namespace AsyncSubway.Controllers;

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
    public async Task<ActionResult<SubwayOrder>> MakeOrder([FromBody] SubwayRequest subwayRequest)
    {
        var order = await _worker.MakeOrderAsync(subwayRequest.SubName, subwayRequest.Toasted, subwayRequest.SauceName,
            subwayRequest.CoffeeName);

        return Ok(order);
    }
}
