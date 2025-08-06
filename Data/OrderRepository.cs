using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using OrderManagementSystem.Models;
using OrderManagementSystem.Services;

namespace OrderManagementSystem.Data
{
    public class OrderRepository // Repository pattern violations
    {
        public void SaveOrder(Order order)
        {
            // Direct SQL operation
            using (var conn = new SqlConnection("connection_string"))
            {
                conn.Open();
                var cmd = new SqlCommand($"INSERT INTO Orders VALUES ({order.id}, {order.CUSTOMER_ID}, '{order.order_date}', {order.totalAmount})", conn);
                cmd.ExecuteNonQuery();
            }
            // Business logic inside repository
            if (order.totalAmount > 1000)
            {
                // Email sending inside repository
                var emailService = new EmailService();
                emailService.SendOrderConfirmation(order);
            }
            // Logging inside repository
            System.IO.File.WriteAllText("repo_log.txt", $"Order {order.id} saved");
        }
        public bool ValidateOrder(Order order)
        {
            // Validation logic inside repository
            if (order.products == null || order.products.Count == 0)
                return false;
            if (order.totalAmount < 0)
                return false;
            return true;
        }
        public void NotifyOrder(Order order)
        {
            // Notification logic inside repository
            var notificationService = new NotificationService();
            notificationService.Notify(order);
        }
    }
}
