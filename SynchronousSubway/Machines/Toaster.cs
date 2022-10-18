using SynchronousSubway.Models;

namespace SynchronousSubway.Machines;

public interface IToaster
{
    Sandwich Toast(Sandwich sandwich);
}

public class Toaster : IToaster
{
    public Sandwich Toast(Sandwich sandwich)
    {
        Console.WriteLine("Toasting for 15s...");
        Task.Delay(15000).Wait();
        Console.WriteLine("Toasted");
        return sandwich;
    }
}