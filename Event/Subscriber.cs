namespace Event;

internal class Subscriber
{
    public static void Run()
    {
        laptop laptop = new laptop();

        //subscribing to the 3 events
        laptop.AddClickMethod(HandleClick);
        laptop.AddAlertLowBatteryMethod(HandleLowBattery);
        laptop.AddShutDownMethod(HandleShutDown);

        laptop.Start("ASDFGIOASDFG");
    }


    //create methods that matches the events
    static void HandleClick(string key)
    {
        Console.WriteLine($"The key: {key} was clicked!");
    }

    static void HandleLowBattery(string message)
    {
        Console.WriteLine(message);
    }

    static void HandleShutDown(string message)
    {
        Console.WriteLine(message);
    }
}

