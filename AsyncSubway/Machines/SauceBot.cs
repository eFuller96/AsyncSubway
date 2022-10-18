using AsyncSubway.Models;

namespace AsyncSubway.Machines;

public interface ISauceBot
{
    Task<Sandwich> SauceUpAsync(Sandwich sandwich);
}

public class SauceBot : ISauceBot
{
    public async Task<Sandwich> SauceUpAsync(Sandwich sandwich)
    {
        Console.WriteLine("Adding sauce for 5s...");
        await Task.Delay(5000);
        Console.WriteLine("Finished Sauceing");
        return sandwich;
    }
}