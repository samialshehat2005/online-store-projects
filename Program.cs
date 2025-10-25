using System;
using IPG_OOP.Core;

class Program
{
    public static void HandleStatusChange(string deviceName, bool newStatus)
    {
        string status = newStatus ? "ON" : "OFF";
        Console.WriteLine($"{deviceName} is now {status}.");
    }

    static void Main(string[] args)
    {
        ProductManager manager = new ProductManager();

        ElectronicDevice myTV = new ElectronicDevice("Smart TV", "LG-OLED-55", 150.5);
        manager.AddItem(myTV);
        
        myTV.OnStatusChanged += HandleStatusChange;

        ServiceSubscription netflix = new ServiceSubscription("Netflix Premium", DateTime.Now, 12, 15.99);
        manager.AddItem(netflix);

        manager.DisplayAllItems();

        Console.WriteLine("\n--- Testing Events ---");
        myTV.TurnOn();
        myTV.TurnOff();
        Console.WriteLine("----------------------\n");

        Console.WriteLine($"Total Revenue from Subscriptions: {ServiceSubscription.TotalRevenue:C}");
    }
}
