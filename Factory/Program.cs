using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var notificationServiceProvider = new NotificationServiceProvider();
            var shippingService = new ShippingService(notificationServiceProvider);
            shippingService.ShipItem();
        }
    }
    interface IUserNotifier
    {
        void NotifyUser(int id);
    }

    class EmailUserNotifier : IUserNotifier
    {
        public void NotifyUser(int id)
        {
            Console.WriteLine($"Notified User {id} By Email");
        }
    }

    class TestUserNotifier : IUserNotifier
    {
        public void NotifyUser(int id)
        {
            Console.WriteLine($"Pretending to notify User {id}");
        }
    }

    class NotificationServiceProvider
    {
        public IUserNotifier GetUserNotifier()
        {
#if DEBUG
            return new TestUserNotifier();
#else
            return new EmailUserNotifier();
#endif
        }
    }

    class ShippingService
    {
        NotificationServiceProvider _serviceProvider;
        public ShippingService(NotificationServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void ShipItem(){
            //code to ship the item
            _serviceProvider.GetUserNotifier().NotifyUser(1);
        }
    }
}
