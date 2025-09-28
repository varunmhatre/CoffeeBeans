using CoffeeBeans.Player;
using UnityEngine;

namespace CoffeeBeans.Collectibles
{
    public class CoffeeCup : MonoBehaviour, IDeliveryItem
    {
        public int price => 5;
        public string Id => "CoffeeCup";
        
        public void OnCollected(PlayerController player)
        {
            Rigidbody rb = GetComponentInChildren<Rigidbody>();
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