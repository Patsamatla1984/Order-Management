using System;

namespace OrderManagementSystem.Models
{
    public class Customer // SRP violation: handles business logic, validation
    {
        public int id;
        public string name;
        public string email;
        public int type;
        public double balance;
        // ...missing documentation...
        public double CalculateDiscount() // OCP violation
        {
            switch (type)
            {
                case 1: return 0.05;
                case 2: return 0.10;
                default: return 0.0;
            }
        }
    }
}
