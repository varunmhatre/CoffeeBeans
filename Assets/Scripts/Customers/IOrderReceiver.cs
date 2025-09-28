using UnityEngine;

namespace CoffeeBeans.Customers
{
    public interface IOrderReceiver
    {
        public bool ReceiveOrder(GameObject item);
    }
}