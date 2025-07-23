using Cricut.Orders.Domain.Models;

namespace Cricut.Orders.Domain
{
    public interface IOrderDomain
    {
        Task<Order> CreateNewOrderAsync(Order order);
        Task<Order[]> GetAllOrdersForCustomer(int customerId);
    }

    public class OrderDomain : IOrderDomain
    {
        private readonly IOrderStore _orderStore;

        public OrderDomain(IOrderStore orderStore)
        {
            _orderStore = orderStore;
        }

        public async Task<Order> CreateNewOrderAsync(Order order)
        {
            var updatedOrder = await _orderStore.SaveOrderAsync(order);
            return updatedOrder;
        }
        public async Task<Order[]> GetAllOrdersForCustomer(int customerId)
        {
            var customerOrders = await _orderStore.GetAllOrdersForCustomerAsync(customerId);
            return customerOrders;
        }
    }
}
