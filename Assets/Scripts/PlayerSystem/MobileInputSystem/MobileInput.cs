using UnityEngine;

namespace CoffeeBeans.PlayerSystem
{
    public class MobileInput : MonoBehaviour
    {
        public static MobileInput Instance { get; private set; }
        [SerializeField] private GameObject mobileUIButtons;
        private Vector2 moveInput;
        private bool interactPressed;

        private void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
            
#if UNITY_ANDROID || UNITY_IOS
            SetMobileUIEnabled(true);
#else
            SetMobileUIEnabled(false);
#endif
        }

        public void SetMoveInput(Vector2 dir)
        {
            moveInput = dir;
        }

        public Vector2 GetMoveInput()
        {
            return moveInput;
        }

        public void PressInteract()
        {
            interactPressed = true;
        }

        public bool ConsumeInteract()
        {
            if (interactPressed)
            {
                interactPressed = false;
                return true;
            }
            return false;
        }

        public void SetMobileUIEnabled(bool enable)
        {
            mobileUIButtons.SetActive(enable);
        }
    }
}