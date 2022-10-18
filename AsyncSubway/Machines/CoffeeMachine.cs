using AsyncSubway.Models;

namespace AsyncSubway.Machines;

public interface ICoffeeMachine
{
    Task<Coffee> MakeCoffeeAsync(string name);
}

public class CoffeeMachine : ICoffeeMachine
{
    public async Task<Coffee> MakeCoffeeAsync(string name)
    {
        Console.WriteLine("Brewing Coffee for 10s...");
        await Task.Delay(10000);
        Console.WriteLine("Finished brewing");
        return new Coffee
        {
            Name = name
        };
    }
}