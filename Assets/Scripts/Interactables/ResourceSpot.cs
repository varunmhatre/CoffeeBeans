using CoffeeBeans.PlayerSystem;
using UnityEngine;

namespace CoffeeBeans.Interactables
{
    [RequireComponent(typeof(Collider))]
    public class ResourceSpot : MonoBehaviour, IInteractable
    {
        [Header("Prefabs")]
        public GameObject beanBagPrefab;
        
        public void Interact(Player player)
        {
            StackController stack = player.GetStack();
            if (!stack.CanAdd) return;
            GameObject bean = Instantiate(beanBagPrefab, player.transform.position + Vector3.up * 0.5f, Quaternion.identity);
            stack.AddItem(bean);
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