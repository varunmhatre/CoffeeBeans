using System.Collections;
using UnityEngine;

namespace CoffeeBeans.MachineProcessors
{
    public class CoffeeProcessor : IMachineProcessor
    {
        private readonly float processingTime;
        private readonly GameObject coffeePrefab;
        private readonly Transform outputPoint;
        
        public CoffeeProcessor(float processingTime, GameObject coffeePrefab, Transform outputPoint)
        {
            this.processingTime = processingTime;
            this.coffeePrefab = coffeePrefab;
            this.outputPoint = outputPoint;
        }
        
        public IEnumerator Process(GameObject input, System.Action<GameObject> onComplete)
        {
            yield return new WaitForSeconds(processingTime);
            if (input != null) Object.Destroy(input);
            GameObject cup = null;
            if (coffeePrefab != null && outputPoint != null)
            {
                cup = Object.Instantiate(coffeePrefab, outputPoint.position, Quaternion.identity);
            }
            onComplete?.Invoke(cup);
        }
    }
}