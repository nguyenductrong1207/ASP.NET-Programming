using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class AdvancedNotificationService : NotificationService
    {
        public virtual void SendNotification(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"[Timestamp: {timestamp}] Notification: {message}");
        }
    }
}
