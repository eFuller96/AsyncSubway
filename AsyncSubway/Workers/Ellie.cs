using AsyncSubway.Machines;
using AsyncSubway.Models;

namespace AsyncSubway.Workers;

public interface IWorker
{
    Task<SubwayOrder> MakeOrderAsync(string sandwichName, bool toasted, string sauceName, string coffeeName);
}

public class Ellie : IWorker
{
    private readonly ICoffeeMachine _coffeeMachine;
    private readonly IToaster _toaster;
    private readonly ISauceBot _sauceBot;

    public Ellie(ICoffeeMachine coffeeMachine, IToaster toaster, ISauceBot sauceBot)
    {
        _coffeeMachine = coffeeMachine;
        _toaster = toaster;
        _sauceBot = sauceBot;
    }

    public async Task<SubwayOrder> MakeOrderAsync(string sandwichName, bool toasted, string sauceName,
        string coffeeName)
    {
        var sandwich = new Sandwich { Name = sandwichName, Sauce = sauceName, Toasted = toasted };

        var toasterTask = _toaster.ToastAsync(sandwich);
        var coffeeTask = _coffeeMachine.MakeCoffeeAsync(coffeeName);

        var toastedSandwich = await toasterTask;
        Console.WriteLine("Got toast");

        var sauceTask = _sauceBot.SauceUpAsync(toastedSandwich);

        await Task.WhenAll(coffeeTask, sauceTask);

        var coffee = await coffeeTask;
        Console.WriteLine("Got coffee");

        sandwich = await sauceTask;
        Console.WriteLine("Got sauce");

        return new SubwayOrder(coffee, sandwich);
    }
}