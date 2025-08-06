using System;
using System.Collections.Generic;

namespace OrderManagementSystem.Models
{
    public class Order // SRP violation: handles business logic, validation, persistence
    {
        public int id; // naming violation
        public int CUSTOMER_ID; // naming violation
        public List<Product> products;
        public DateTime order_date; // naming violation
        public double totalAmount;
        public string status;
        public int discountType;
        public int paymentType;
        // ...missing documentation...
        public void CalculateTotal() // SRP violation
        {
            double sum = 0;
            foreach (var p in products)
            {
                sum += p.price;
            }
            totalAmount = sum;
        }
    }
}
