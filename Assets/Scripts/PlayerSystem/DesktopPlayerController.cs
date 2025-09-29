using UnityEngine;

namespace CoffeeBeans.PlayerSystem
{
    public class DesktopPlayerController : IPlayerController
    {
        private Player player;
        private StackController stack;
        private InteractionHandler interactionHandler;
        private float moveSpeed = 0.05f;

        public void Initialize(Player player, StackController stackController, InteractionHandler interactionHandler)
        {
            this.player = player;
            stack = stackController;
            this.interactionHandler = interactionHandler;
        }

        public void Tick()
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Vector3 dir = new Vector3(h, 0, v).normalized;
            player.transform.position += dir * moveSpeed;
            if (Input.GetKeyDown(KeyCode.E))
                interactionHandler.TryInteract(GetPlayer());
        }

        private Player GetPlayer() => player;
    }
}