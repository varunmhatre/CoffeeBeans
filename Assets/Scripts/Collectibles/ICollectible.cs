using CoffeeBeans.Player;

namespace CoffeeBeans.Collectibles
{
    public interface ICollectible
    {
        public string Id { get; }
        public void OnCollected(PlayerController player);
    }
}