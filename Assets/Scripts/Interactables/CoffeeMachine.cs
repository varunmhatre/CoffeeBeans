using CoffeeBeans.Collectibles;
using CoffeeBeans.MachineProcessors;
using CoffeeBeans.Player;
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
        
        public void Interact(PlayerController player)
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