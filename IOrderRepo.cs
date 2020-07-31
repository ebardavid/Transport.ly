using System.Collections.Generic;

namespace Trasnport.ly
{
    public interface IOrderRepo
    {
        IEnumerable<Order> GetOrders();
    }
}