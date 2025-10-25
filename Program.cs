using System;
using IPG_OOP_Project.Core;
using IPG_OOP_Project.Models;

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

        ElectronicDevice myTV = new ElectronicDevice("ED001", "Smart TV", 150.5m, "LG-OLED-55", 150.5);
        manager.AddItem(myTV);
        
        myTV.OnStatusChanged += HandleStatusChange;

        ServiceSubscription netflix = new ServiceSubscription("SS001", "Netflix Premium", 15.99m, DateTime.Now, 12, 15.99);
        manager.AddItem(netflix);

        manager.ShowAllItems();

        Console.WriteLine("\n--- Testing Events ---");
        myTV.TurnOn();
        myTV.TurnOff();
        Console.WriteLine("----------------------\n");

        Console.WriteLine($"Total Revenue from Subscriptions: {ServiceSubscription.TotalRevenue:C}");
    }
}

