namespace OrderManagementSystem.DTOs
{
    public class OrderDto
    {
        public int id;
        public int customerId;
        public List<ProductDto> products;
        public double totalAmount;
        public string status;
        // Manual mapping method
        public static OrderDto MapFromOrder(Models.Order order)
        {
            var dto = new OrderDto();
            dto.id = order.id;
            dto.customerId = order.CUSTOMER_ID;
            dto.products = new List<ProductDto>();
            foreach (var p in order.products)
            {
                dto.products.Add(new ProductDto { id = p.id, name = p.name, price = p.price });
            }
            dto.totalAmount = order.totalAmount;
            dto.status = order.status;
            return dto;
        }
    }

    public class ProductDto
    {
        public int id;
        public string name;
        public double price;
    }
}
