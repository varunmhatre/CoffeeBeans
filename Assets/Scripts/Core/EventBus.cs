using System;

namespace CoffeeBeans.Core
{
    public static class EventBus
    {
        public static event Action<int> OnCoinsChanged;
        public static event Action<int> OnCustomerServed;

        public static void CoinsChanged(int total)
        {
            OnCoinsChanged?.Invoke(total);
        }

        public static void CustomerServed(int totalServed)
        {
            OnCustomerServed?.Invoke(totalServed);
        }
    }
}