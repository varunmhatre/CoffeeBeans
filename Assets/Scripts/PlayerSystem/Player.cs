using CoffeeBeans.Interactables;
using UnityEngine;

namespace CoffeeBeans.PlayerSystem
{
    public class Player : MonoBehaviour
    {
        private IPlayerController controller;
        private StackController stack;
        private InteractionHandler interactionHandler;

        private void Awake()
        {
            stack = GetComponentInChildren<StackController>();
            interactionHandler = GetComponent<InteractionHandler>();

            controller = PlayerFactory.CreateController();
            controller.Initialize(this, stack, interactionHandler);
        }

        private void Update()
        {
            controller.Tick();
        }
        
        public StackController GetStack() => stack;
    }
}