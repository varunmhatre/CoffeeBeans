using UnityEngine;

namespace CoffeeBeans.Core
{
    public class EconomyService : MonoBehaviour
    {
        public int Coins { get; private set; }
        
        public void AddCoins(int amount)
        {
            Coins += amount;
            EventBus.CoinsChanged(Coins);
        }
        
        public void SpendCoins(int amount)
        {
            Coins = Mathf.Max(0, Coins - amount);
            EventBus.CoinsChanged(Coins);
        }
    }
}