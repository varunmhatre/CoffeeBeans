using System;

namespace CoffeeBeans.Core
{
    public static class EventBus
    {
        public static event Action<int> OnCoinsChanged;
        public static event Action<int, int> OnCustomerServed;

        public static void CoinsChanged(int total)
        {
            OnCoinsChanged?.Invoke(total);
        }

        public static void CustomerServed(int totalServed, int coinsEarned)
        {
            OnCustomerServed?.Invoke(totalServed, coinsEarned);
        }
    }
}