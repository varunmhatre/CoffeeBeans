using System.Collections.Generic;
using CoffeeBeans.Collectibles;
using UnityEngine;

namespace CoffeeBeans.Player
{
    public class StackController : MonoBehaviour
    {
        public int capacity = 3;
        private readonly List<GameObject> items = new List<GameObject>();
        
        [Header("Visuals")]
        public Transform stackRoot;
        public Vector3 stackOffset = new Vector3(0, 0.25f, 0);
        
        public bool CanAdd => items.Count < capacity;
        public int Count => items.Count;
        
        public bool AddItem(GameObject item)
        {
            if (!CanAdd) return false;
            items.Add(item);
            item.transform.SetParent(stackRoot, true);
            item.transform.localPosition = stackOffset * items.Count;
            if (item.TryGetComponent<ICollectible>(out ICollectible collectible))
            {
                collectible.OnCollected(GetComponentInParent<PlayerController>());
            }
            return true;
        }
        
        public GameObject RemoveTopItem()
        {
            if (items.Count == 0) return null;
            GameObject top = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            top.transform.SetParent(null, true);
            return top;
        }
        
        public GameObject PeekTopItem()
        {
            if (items.Count == 0) return null;
            return items[items.Count - 1];
        }
    }
}