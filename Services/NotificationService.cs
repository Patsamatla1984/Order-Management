using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public class NotificationService // SRP violation
    {
        public void Notify(Order order)
        {
            // Notification logic
            // ...no abstraction, no async...
        }
    }
}
