using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public class EmailService // SRP violation
    {
        public void SendOrderConfirmation(Order order)
        {
            // Email sending logic
            // ...no validation, no abstraction...
        }
    }
}
