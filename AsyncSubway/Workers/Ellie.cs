using AsyncSubway.Machines;
using AsyncSubway.Models;

namespace AsyncSubway.Workers;

public interface IWorker
{
    Task<SubwayOrder> MakeOrderAsync(string sandwichName, bool toasted, string sauceName, string coffeeName);
}

public class Ellie : IWorker
{
    private readonly ICoffeeMachine coffeeMachine;
    private readonly IToaster toaster;
    private readonly ISauceBot sauceBot;

    public Ellie(ICoffeeMachine coffeeMachine, IToaster toaster, ISauceBot sauceBot)
    {
        this.coffeeMachine = coffeeMachine;
        this.toaster = toaster;
        this.sauceBot = sauceBot;
    }

    public async Task<SubwayOrder> MakeOrderAsync(string sandwichName, bool toasted, string sauceName,
        string coffeeName)
    {
        var sandwich = new Sandwich { Name = sandwichName, Sauce = sauceName, Toasted = toasted };

        var toasterTask = toaster.ToastAsync(sandwich);
        var coffeeTask = coffeeMachine.MakeCoffeeAsync(coffeeName);
        var toastedSandwich = await toasterTask;
        Console.WriteLine("Got toast");
        var sauceTask = sauceBot.SauceUpAsync(toastedSandwich);

        await Task.WhenAll(coffeeTask, sauceTask);

        var coffee = await coffeeTask;
        Console.WriteLine("Got coffee");
        sandwich = await sauceTask;
        Console.WriteLine("Got sauce");

        var order = new SubwayOrder(coffee, sandwich);

        return order;
    }
    
}