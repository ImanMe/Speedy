using SpeedyAir.Models;

namespace SpeedyAir.Contracts;

public interface IOrderService
{
    IList<Order> LoadOrders(string filename);
}