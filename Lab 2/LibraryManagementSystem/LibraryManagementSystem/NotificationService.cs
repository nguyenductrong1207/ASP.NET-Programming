using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class NotificationService
    {
        // Method 1: Send notification without recipient
        public void SendNotification(string message)
        {
            Console.WriteLine($"Notification: {message}");
        }

        // Method 2: Send notification to a single recipient
        public void SendNotification(string message, string recipient)
        {
            Console.WriteLine($"Notification to {recipient}: {message}");
        }

        // Method 3: Send notification to a list of recipients
        public void SendNotification(string message, List<string> recipients)
        {
            foreach (var recipient in recipients)
            {
                Console.WriteLine($"Notification to {recipient}: {message}");
            }
        }

        public void OnBookBorrowed(Book book, Member member)
        {
            Console.WriteLine($"Notification: {member.Name} has borrowed '{book.Title}'.");
        }

        // Another method that can be registered to the event
        public void SendEmailNotification(Book book, Member member)
        {
            Console.WriteLine($"Sending email to {member.Email}: You've borrowed '{book.Title}'.");
        }
    }
}
