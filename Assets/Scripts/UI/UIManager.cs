using CoffeeBeans.Core;
using TMPro;
using UnityEngine;

namespace CoffeeBeans.UI
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI coinsText;
        
        private void Start()
        {
            EventBus.OnCoinsChanged += UpdateCoins;
            if (GameManager.Instance != null && GameManager.Instance.economyService != null)
            {
                UpdateCoins(GameManager.Instance.economyService.Coins);
            }
        }
        
        private void OnDestroy()
        {
            EventBus.OnCoinsChanged -= UpdateCoins;
        }
        
        void UpdateCoins(int amount)
        {
            if (coinsText != null) coinsText.text = amount.ToString();
        }
    }
}