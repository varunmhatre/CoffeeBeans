using CoffeeBeans.Player;
using UnityEngine;

namespace CoffeeBeans.Collectibles
{
    public class BeanBag : MonoBehaviour, IStackableItem
    {
        public string Id => "BeanBag";
        
        public void OnCollected(PlayerController player)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb) Destroy(rb);
        }
    }
}