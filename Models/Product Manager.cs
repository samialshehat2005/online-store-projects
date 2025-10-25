using System;
using System.Collections.Generic;

namespace IPG_OOP_Project.Core
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

        public void DisplayAllItems()
        {
            Console.WriteLine("--- All Managed Items ---");
            foreach (AbstractBase item in items)
            {
                // تطبيق تعدد الأشكال (Polymorphism)
                // يتم استدعاء DisplayDetails الخاص بالفئة المشتقة (Book, ElectronicDevice, ServiceSubscription)
                item.DisplayDetails(); 
                Console.WriteLine("-------------------------");
            }
        }
    }
}
