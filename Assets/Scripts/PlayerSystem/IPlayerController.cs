namespace CoffeeBeans.PlayerSystem
{
    public interface IPlayerController
    {
        void Initialize(Player player, StackController stackController, InteractionHandler interactionHandler);
        void Tick();
    }
}