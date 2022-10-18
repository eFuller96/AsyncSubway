using AsyncSubway.Models;
using AsyncSubway.Workers;
using Microsoft.AspNetCore.Mvc;

namespace AsyncSubway.Controllers;

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
    public async Task<ActionResult<SubwayOrder>> MakeOrder([FromBody] SubwayRequest subwayRequest)
    {
        var order = await _ellie.MakeOrderAsync(subwayRequest.SubName, subwayRequest.Toasted, subwayRequest.SauceName,
            subwayRequest.CoffeeName);

        return Ok(order);
    }
}
