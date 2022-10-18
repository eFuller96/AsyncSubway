using SynchronousSubway.Models;

namespace SynchronousSubway.Machines;

public interface ISauceBot
{
    Sandwich SauceUp(Sandwich sandwich);
}

public class SauceBot : ISauceBot
{
    public Sandwich SauceUp(Sandwich sandwich)
    {
        Console.WriteLine("Adding sauce for 5s...");
        Task.Delay(5000).Wait();
        Console.WriteLine("Sandwich sauced");
        return sandwich;
    }
}