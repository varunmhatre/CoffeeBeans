using CoffeeBeans.Interactables;
using UnityEngine;

namespace CoffeeBeans.PlayerSystem
{
    public class InteractionHandler : MonoBehaviour
    {
        private IInteractable current;

        public void SetCurrentInteractable(IInteractable interactable)
        {
            current = interactable;
        }

        public void TryInteract(Player player)
        {
            if (current != null)
                current.Interact(player);
        }

        public bool HasInteractable => current != null;
    }
}