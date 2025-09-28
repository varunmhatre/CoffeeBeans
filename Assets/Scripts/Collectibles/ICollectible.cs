using CoffeeBeans.Player;

namespace CoffeeBeans.Collectibles
{
    public interface ICollectible
    {
        string Id { get; }
        void OnCollected(PlayerController player);
    }
}