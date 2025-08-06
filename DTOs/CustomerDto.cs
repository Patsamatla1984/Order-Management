namespace OrderManagementSystem.DTOs
{
    public class CustomerDto
    {
        public int id;
        public string name;
        public string email;
        public double balance;
        // Manual mapping method
        public static CustomerDto MapFromCustomer(Models.Customer customer)
        {
            var dto = new CustomerDto();
            dto.id = customer.id;
            dto.name = customer.name;
            dto.email = customer.email;
            dto.balance = customer.balance;
            return dto;
        }
    }
}
