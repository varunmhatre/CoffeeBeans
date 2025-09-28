using CoffeeBeans.Collectibles;
using CoffeeBeans.Core;
using CoffeeBeans.Interactables;
using CoffeeBeans.Player;
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
        
        public void Interact(PlayerController player)
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
            if (other.TryGetComponent<PlayerController>(out PlayerController player))
            {
                player.SetCurrentInteractable(this);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<PlayerController>(out PlayerController player))
            {
                player.SetCurrentInteractable(null);
            }
        }
    }
}