using AsyncSubway.Models;

namespace AsyncSubway.Machines;

public interface IToaster
{
    Task<Sandwich> ToastAsync(Sandwich sandwich);
}

public class Toaster : IToaster
{
    public async Task<Sandwich> ToastAsync(Sandwich sandwich)
    {
        Console.WriteLine("Toasting for 15s...");
        await Task.Delay(15000);
        Console.WriteLine("Toasted");
        return sandwich;
    }
}