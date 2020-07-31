using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Trasnport.ly
{
    partial class Program
    {
        class OrderRepo : IOrderRepo
        {
            public IEnumerable<Order> GetOrders()
            {
                var jsonFile = File.ReadAllText("coding-assigment-orders.json");
                return JsonSerializer.Deserialize<Dictionary<string, Order>>(jsonFile)
                    .Select(o => new Order { Id = o.Key, Destination = o.Value.Destination })
                    .ToArray();
            }

        }
    }
}
