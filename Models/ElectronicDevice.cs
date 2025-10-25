using System;
using IPG_OOP_Project.Core;

namespace IPG_OOP_Project.Models
{
    public delegate void StatusChangeHandler(string deviceName, bool newStatus);

    public class ElectronicDevice : AbstractBase
    {
        private string model;
        private bool ison;
        private double power;

        public event StatusChangeHandler OnStatusChanged;

        public ElectronicDevice(string id, string name, decimal price, string modelNumber, double powerConsumptionWatts) : base(id, name, price)
        {
            this.model = modelNumber;
            this.power = powerConsumptionWatts;
            this.ison = false;
        }

        public override string BriefDescription
        {
            get { return $"Electronic Device: {NameOfProduct}"; }
        }

        public bool IsPoweredOn
        {
            get { return ison; }
        }

        public void TurnOn()
        {
            if (!ison)
            {
                ison = true;
                Console.WriteLine(NameOfProduct + " is turning ON.");
                OnStatusChanged?.Invoke(NameOfProduct, ison);
            }
            else
            {
                Console.WriteLine(NameOfProduct + " is already ON.");
            }
        }

        public void TurnOff()
        {
            if (ison)
            {
                ison = false;
                Console.WriteLine(NameOfProduct + " is turning OFF.");
                OnStatusChanged?.Invoke(NameOfProduct, ison);
            }
            else
            {
                Console.WriteLine(NameOfProduct + " is already OFF.");
            }
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine("Model: " + model);
            Console.WriteLine("Power: " + power + "W");
            Console.WriteLine("Status: " + (ison ? "ON" : "OFF"));
        }
    }
}
