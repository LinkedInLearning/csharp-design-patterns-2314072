using System;

namespace HPlusSports.Core {
public class EmailUserNotifier : IUserNotifier
    {
        public void NotifyUser(int id)
        {
            Console.WriteLine($"\n\n\nNotified User {id} By Email\n\n\n");
        }
    }
}