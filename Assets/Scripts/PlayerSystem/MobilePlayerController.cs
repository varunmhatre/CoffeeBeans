using UnityEngine;

namespace CoffeeBeans.PlayerSystem
{
    public class MobilePlayerController : IPlayerController
    {
        private Player player;
        private StackController stack;
        private InteractionHandler interactionHandler;
        private float moveSpeed = 0.1f;

        public void Initialize(Player player, StackController stackController, InteractionHandler interactionHandler)
        {
            this.player = player;
            this.stack = stackController;
            this.interactionHandler = interactionHandler;
        }

        public void Tick()
        {
            if (MobileInput.Instance == null) return;

            Vector2 moveDir = MobileInput.Instance.GetMoveInput();
            Vector3 dir = new Vector3(moveDir.x, 0, moveDir.y).normalized;
            player.transform.position += dir * moveSpeed;

            if (MobileInput.Instance.ConsumeInteract())
                interactionHandler.TryInteract(GetPlayer());
        }

        private Player GetPlayer() => player;
    }
}