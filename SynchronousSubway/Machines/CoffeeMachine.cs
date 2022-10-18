using SynchronousSubway.Models;

namespace SynchronousSubway.Machines;

public interface ICoffeeMachine
{
    Coffee MakeCoffee(string name);
}

public class CoffeeMachine : ICoffeeMachine
{
    public Coffee MakeCoffee(string name)
    {
        Console.WriteLine("Brewing Coffee for 10s...");
        Task.Delay(10000).Wait();
        Console.WriteLine("Finished brewing");
        return new Coffee
        {
            Name = name
        };
    }
}