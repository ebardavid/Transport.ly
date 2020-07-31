using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;



namespace Trasnport.ly
{
    partial class Program
    {
        class OrderRepo : IOrderRepo
        {
            public IEnumerable<Order> GetOrders()
            {
                IEnumerable<Order> orders = null;
                using (var r = new StreamReader(Path.GetFullPath("coding-assigment-orders.json"))) {
                    orders = JsonConvert.DeserializeObject<Dictionary<string, Order>>(r.ReadToEnd()).
                        Select(o => new Order { Id = o.Key, Destination = o.Value.Destination })
                        .ToArray();
                }
                return orders;
            }

        }
    }
}
