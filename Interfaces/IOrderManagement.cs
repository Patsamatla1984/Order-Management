namespace OrderManagementSystem.Interfaces
{
    // Fat interface with ISP violation
    public interface IOrderManagement
    {
        void ProcessOrder();
        void SendEmail();
        void GenerateReport();
        void ProcessPayment();
        void ManageInventory();
        void ManageOrder();
    }

    // Classes forced to throw NotImplementedException
    public class EmailManager : IOrderManagement
    {
        public void ProcessOrder() { throw new NotImplementedException(); }
        public void SendEmail() { /* ... */ }
        public void GenerateReport() { throw new NotImplementedException(); }
        public void ProcessPayment() { throw new NotImplementedException(); }
        public void ManageInventory() { throw new NotImplementedException(); }
        public void ManageOrder() { throw new NotImplementedException(); }
    }
}
