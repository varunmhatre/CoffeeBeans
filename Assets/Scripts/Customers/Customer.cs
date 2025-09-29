using CoffeeBeans.Collectibles;
using CoffeeBeans.Core;
using CoffeeBeans.Interactables;
using CoffeeBeans.PlayerSystem;
using UnityEngine;

namespace CoffeeBeans.Customers
{
    public class Customer : MonoBehaviour, IOrderReceiver, IInteractable
    {
        public bool ReceiveOrder(GameObject item)
        {
            if (item == null) return false;
            if (item.TryGetComponent<CoffeeCup>(out CoffeeCup cup))
            {
                GameManager.Instance.economyService.AddCoins(cup.price);
                Destroy(item);
                EventBus.CustomerServed(1, cup.price);
                return true;
            }
            return false;
        }
        
        public void Interact(Player player)
        {
            StackController stack = player.GetStack();
            GameObject top = stack.PeekTopItem();
            if (top == null) return;
            if (ReceiveOrder(top))
            {
                stack.RemoveTopItem();
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<InteractionHandler>(out InteractionHandler handler))
            {
                handler.SetCurrentInteractable(this);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<InteractionHandler>(out InteractionHandler handler))
            {
                handler.SetCurrentInteractable(null);
            }
        }
    }
}