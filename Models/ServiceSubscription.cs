using System;

namespace IPG_OOP_Project.Core
{
    public class ServiceSubscription : AbstractBase
    {
        private string serviceName;
        private DateTime startDate;
        private int durationMonths;
        private double monthlyCost;

        public static double TotalRevenue { get; private set; } = 0;

        public ServiceSubscription(string name, DateTime start, int duration, double cost)
        {
            if (!DataValidator.IsValidString(name) || !DataValidator.IsPositive(duration) || !DataValidator.IsPositive(cost))
            {
                throw new ArgumentException("Invalid subscription data.");
            }

            serviceName = name;
            startDate = start;
            durationMonths = duration;
            monthlyCost = cost;
            TotalRevenue += monthlyCost * durationMonths;
        }

        public string ServiceName
        {
            get { return serviceName; }
        }

        public DateTime EndDate
        {
            get { return startDate.AddMonths(durationMonths); }
        }

        public bool IsActive
        {
            get { return EndDate > DateTime.Now; }
        }

        public override void DisplayDetails()
        {
            Console.WriteLine("Subscription Details:");
            Console.WriteLine("Service: " + serviceName);
            Console.WriteLine("Start Date: " + startDate.ToShortDateString());
            Console.WriteLine("End Date: " + EndDate.ToShortDateString());
            Console.WriteLine("Cost: " + monthlyCost + " per month");
        }
    }
}

