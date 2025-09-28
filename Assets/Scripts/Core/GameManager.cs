using CoffeeBeans.Customers;
using UnityEngine;

namespace CoffeeBeans.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        [Header("References")]
        public CustomerManager customerManager;
        public EconomyService economyService;
        
        private void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            if (economyService == null) economyService = FindFirstObjectByType<EconomyService>();
            if (customerManager == null) customerManager = FindFirstObjectByType<CustomerManager>();
        }
    }
}