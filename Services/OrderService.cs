using System;
using System.Collections.Generic;
using OrderManagementSystem.Models;
using OrderManagementSystem.DTOs;
using OrderManagementSystem.Data;
using OrderManagementSystem.Services;

namespace OrderManagementSystem.Services
{
    public class OrderService // SRP, DIP, OCP violations
    {
        private OrderRepository _orderRepository = new OrderRepository(); // DIP violation
        private EmailService _emailService = new EmailService(); // DIP violation
        private NotificationService _notificationService = new NotificationService(); // DIP violation
        public void process_order(OrderDto orderDto) // naming violation, SRP violation
        {
            // Manual mapping
            var order = new Order { id = orderDto.id, CUSTOMER_ID = orderDto.customerId, products = new List<Product>(), status = orderDto.status };
            foreach (var p in orderDto.products)
            {
                order.products.Add(new Product { id = p.id, name = p.name, price = p.price });
            }
            // Validation, calculation, persistence, notification all in one method
            if (order.products.Count == 0)
            {
                throw new Exception("Order must have products");
            }
            order.CalculateTotal();
            _orderRepository.SaveOrder(order); // Persistence
            _emailService.SendOrderConfirmation(order); // Notification
            _notificationService.Notify(order); // Notification
            // Logging
            System.IO.File.WriteAllText("order_log.txt", $"Order {order.id} processed");
        }
    }
}
