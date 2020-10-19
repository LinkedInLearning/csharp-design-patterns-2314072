using System;

namespace HPlusSports.Core {
public class TestUserNotifier : IUserNotifier
    {
        public void NotifyUser(int id)
        {
            Console.WriteLine($"\n\n\nPretending to Notify User {id}\n\n\n");
        }
    }
}