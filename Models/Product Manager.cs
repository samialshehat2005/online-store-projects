using System;
using IPG_OOP_Project.Core;
using System.Collections.Generic;

namespace IPG_OOP_Project.Models
{
    public class ProductManager
    {
        private List<AbstractBase> items;

        public ProductManager()
        {
            items = new List<AbstractBase>();
        }

        public void AddItem(AbstractBase item)
        {
            if (item != null)
            {
                items.Add(item);
                Console.WriteLine("Item added: " + item.GetType().Name);
            }
        }

        public void ShowAllItems()
        {
            Console.WriteLine("--- All Managed Items ---");
            foreach (AbstractBase item in items)
            {


                item.DisplayDetails(); 
                Console.WriteLine("-------------------------");
            }
        }
    }
}
