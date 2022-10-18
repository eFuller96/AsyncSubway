using SynchronousSubway.Machines;
using SynchronousSubway.Models;

namespace SynchronousSubway.Workers;

public interface IWorker
{
    SubwayOrder MakeOrder(string sandwichName, bool toasted, string sauceName, string coffeeName);
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

    public SubwayOrder MakeOrder(string sandwichName, bool toasted, string sauceName,
        string coffeeName)
    {
        var sandwich = new Sandwich { Name = sandwichName, Sauce = sauceName, Toasted = toasted };

        var toastedSandwich = toaster.Toast(sandwich);
        Console.WriteLine("Got toast");

        var coffee = coffeeMachine.MakeCoffee(coffeeName);
        Console.WriteLine("Got coffee");

        sandwich = sauceBot.SauceUp(toastedSandwich);
        Console.WriteLine("Got sauce");

        var order = new SubwayOrder(coffee, sandwich);

        return order;
    }
    
}