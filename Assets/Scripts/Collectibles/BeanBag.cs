using CoffeeBeans.PlayerSystem;
using UnityEngine;

namespace CoffeeBeans.Collectibles
{
    public class BeanBag : MonoBehaviour, IStackableItem
    {
        public string Id => "BeanBag";
        
        public void OnCollected(Player player)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb) Destroy(rb);
        }
    }
}