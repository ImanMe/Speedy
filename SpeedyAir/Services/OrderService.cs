using Newtonsoft.Json;
using SpeedyAir.Contracts;
using SpeedyAir.Models;

namespace SpeedyAir.Services;

public class OrderService : IOrderService
{
    /// <summary>
    ///     Load orders from JSON file. Map to order
    /// </summary>
    /// <param name="filename"></param>
    /// <returns>Orders</returns>
    public IList<Order> LoadOrders(string filename)
    {
        var jsonString = File.ReadAllText(filename);

        // Deserialize JSON object into a dictionary
        var orderDictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(jsonString);

        // Create a list of orders from the dictionary
        var orders = new List<Order>();

        if (orderDictionary == null) return orders;

        foreach (var (orderId, value) in orderDictionary)
        {
            var destination = value["destination"];
            orders.Add(new Order(orderId, destination));
        }

        return orders;
    }
}