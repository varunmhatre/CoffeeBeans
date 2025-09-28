using CoffeeBeans.Player;
using UnityEngine;

namespace CoffeeBeans.Collectibles
{
    public class CoffeeCup : MonoBehaviour, IDeliveryItem
    {
        public string Id => "CoffeeCup";
        
        public void OnCollected(PlayerController player)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb) Destroy(rb);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerController>(out var player))
            {
                StackController stack = player.GetStack();
                if (stack.CanAdd)
                {
                    stack.AddItem(this.gameObject);
                }
            }
        }
    }
}