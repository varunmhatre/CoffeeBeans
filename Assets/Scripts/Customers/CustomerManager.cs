using System.Collections;
using System.Collections.Generic;
using CoffeeBeans.Core;
using UnityEngine;

namespace CoffeeBeans.Customers
{
    public class CustomerManager : MonoBehaviour
    {
        public float customerSpawnDelay = 3f;
        public GameObject customerPrefab;
        public Transform spawnPoint;
        
        private readonly Queue<GameObject> active = new Queue<GameObject>();
        
        private void Start()
        {
            StartCoroutine(SpawnCustomer());
            EventBus.OnCustomerServed += OnCustomerServed;
        }
        
        private void OnDestroy()
        {
            EventBus.OnCustomerServed -= OnCustomerServed;
        }
        
        public IEnumerator SpawnCustomer()
        {
            if (customerPrefab == null || spawnPoint == null) yield break;
            
            yield return new WaitForSeconds(customerSpawnDelay);
            GameObject c = Instantiate(customerPrefab, spawnPoint.position, spawnPoint.rotation);
            active.Enqueue(c);
        }
        
        private void OnCustomerServed(int _, int __)
        {
            if (active.Count > 0)
            {
                GameObject old = active.Dequeue();
                Destroy(old);
            }
            StartCoroutine(SpawnCustomer());
        }
    }
}