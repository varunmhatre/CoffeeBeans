using CoffeeBeans.PlayerSystem;

namespace CoffeeBeans.Collectibles
{
    public interface ICollectible
    {
        public string Id { get; }
        public void OnCollected(Player player);
    }
}