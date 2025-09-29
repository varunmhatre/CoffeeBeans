using CoffeeBeans.Core;
using CoffeeBeans.PlayerSystem;
using UnityEngine;

namespace CoffeeBeans.Customers
{
    public class DeliverySystem : MonoBehaviour
    {
        public void DeliverToCustomer(Player player, Customer customer)
        {
            StackController stack = player.GetStack();
            GameObject top = stack.PeekTopItem();
            if (top == null) return;
            if (customer.ReceiveOrder(top))
            {
                stack.RemoveTopItem();
                GameManager.Instance.economyService.AddCoins(0); // no-op to show pattern
            }
        }
    }
}