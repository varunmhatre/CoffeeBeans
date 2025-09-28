using UnityEngine;

namespace CoffeeBeans.MachineProcessors
{
    public interface IMachineProcessor
    {
        System.Collections.IEnumerator Process(GameObject input, System.Action<GameObject> onComplete);
    }
}