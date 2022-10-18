namespace SynchronousSubway.Models;

public class SubwayOrder
{
    public Coffee Coffee { get; }
    public Sandwich Sandwich { get; }

    public SubwayOrder(Coffee coffee, Sandwich sandwich)
    {
        Coffee = coffee;
        Sandwich = sandwich;
    }
}