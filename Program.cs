using System;
using IPG_OOP_Project.Core;

class Program
{
    // دالة معالج الحدث (مطلوبة من الطالب الثالث)
    public static void HandleStatusChange(string deviceName, bool newStatus)
    {
        string status = newStatus ? "ON" : "OFF";
        Console.WriteLine($"[Event] {deviceName} is now {status}.");
    }

    static void Main(string[] args)
    {
        // تهيئة مدير المنتجات (الطالب الخامس)
        ProductManager manager = new ProductManager();

        // 1. إضافة كائنات من فئات مختلفة إلى المدير (لتطبيق تعدد الأشكال)
        
        // كائن من فئة Book (افتراضاً أنها موجودة - متطلب الطالب الثاني)
        // Book myBook = new Book("The OOP Guide", "978-1234567890", 50.0);
        // manager.AddItem(myBook);

        // كائن من فئة ElectronicDevice (متطلب الطالب الثالث)
        ElectronicDevice myTV = new ElectronicDevice("Smart TV", "LG-OLED-55", 150.5);
        manager.AddItem(myTV);
        
        // الاشتراك في الحدث (متطلب الطالب الثالث)
        myTV.OnStatusChanged += HandleStatusChange;

        // كائن من فئة ServiceSubscription (متطلب الطالب الرابع)
        ServiceSubscription netflix = new ServiceSubscription("Netflix Premium", DateTime.Now, 12, 15.99);
        manager.AddItem(netflix);
        
        // 2. استخدام تعدد الأشكال لعرض تفاصيل جميع الكائنات
        manager.DisplayAllItems();

        // 3. اختبار المفوضات والأحداث (متطلب الطالب الثالث)
        Console.WriteLine("\n--- Testing Events ---");
        myTV.TurnOn();
        myTV.TurnOff();
        Console.WriteLine("----------------------\n");

        // 4. اختبار الخاصية الثابتة (متطلب الطالب الرابع)
        Console.WriteLine($"Total Revenue from Subscriptions: {ServiceSubscription.TotalRevenue:C}");
    }
}
