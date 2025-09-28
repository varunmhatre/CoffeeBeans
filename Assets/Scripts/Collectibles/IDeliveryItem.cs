namespace CoffeeBeans.Collectibles
{
    public interface IDeliveryItem : ICollectible
    {
        public int price { get; }
    }
}