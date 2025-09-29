using CoffeeBeans.Collectibles;
using CoffeeBeans.MachineProcessors;
using CoffeeBeans.PlayerSystem;
using UnityEngine;

namespace CoffeeBeans.Interactables
{
    public class CoffeeMachine : MonoBehaviour, IInteractable
    {
        public IMachineProcessor processor;
        public Transform outputPoint;
        public float processingTime = 2f;
        public GameObject coffeePrefab;
        
        private void Awake()
        {
            if (processor == null) processor = new CoffeeProcessor(processingTime, coffeePrefab, outputPoint);
        }
        
        public void Interact(Player player)
        {
            StackController stack = player.GetStack();
            GameObject top = stack.PeekTopItem();
            if (top == null) return;
            if (top.TryGetComponent<BeanBag>(out BeanBag bean))
            {
                GameObject taken = stack.RemoveTopItem();
                StartCoroutine(processor.Process(taken, (result) =>
                {
                }));
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