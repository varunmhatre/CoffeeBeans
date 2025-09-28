using UnityEngine;

namespace CoffeeBeans.Customers
{
    public interface IOrderReceiver
    {
        bool ReceiveOrder(GameObject item);
    }
}