using SynchronousSubway.Machines;
using SynchronousSubway.Models;

namespace SynchronousSubway.Workers;

public interface IWorker
{
    SubwayOrder MakeOrder(string sandwichName, bool toasted, string sauceName, string coffeeName);
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

    public SubwayOrder MakeOrder(string sandwichName, bool toasted, string sauceName,
        string coffeeName)
    {
        var sandwich = new Sandwich { Name = sandwichName, Sauce = sauceName, Toasted = toasted };

        var toastedSandwich = _toaster.Toast(sandwich);
        Console.WriteLine("Got toast");

        var coffee = _coffeeMachine.MakeCoffee(coffeeName);
        Console.WriteLine("Got coffee");

        sandwich = _sauceBot.SauceUp(toastedSandwich);
        Console.WriteLine("Got sauce");

        return new SubwayOrder(coffee, sandwich);
    }
    
}