using UnityEngine;

namespace CoffeeBeans.PlayerSystem
{
    public static class PlayerFactory
    {
        public static IPlayerController CreateController()
        {
#if UNITY_ANDROID || UNITY_IOS
            Debug.Log("Mobile player controller created.");
            return new MobilePlayerController();
#else
            Debug.Log("Desktop player controller created.");
            return new DesktopPlayerController();
#endif
        }
    }
}