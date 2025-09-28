using System.Collections.Generic;
using CoffeeBeans.Core;
using UnityEngine;

namespace CoffeeBeans.Customers
{
    public class CustomerManager : MonoBehaviour
    {
        public GameObject customerPrefab;
        public Transform spawnPoint;
        
        private readonly Queue<GameObject> active = new Queue<GameObject>();
        
        private void Start()
        {
            SpawnCustomer();
            EventBus.OnCustomerServed += OnCustomerServed;
        }
        
        private void OnDestroy()
        {
            EventBus.OnCustomerServed -= OnCustomerServed;
        }
        
        public void SpawnCustomer()
        {
            if (customerPrefab == null || spawnPoint == null) return;
            GameObject c = Instantiate(customerPrefab, spawnPoint.position, spawnPoint.rotation);
            active.Enqueue(c);
        }
        
        private void OnCustomerServed(int _)
        {
            if (active.Count > 0)
            {
                GameObject old = active.Dequeue();
                Destroy(old);
            }
            SpawnCustomer();
        }
    }
}