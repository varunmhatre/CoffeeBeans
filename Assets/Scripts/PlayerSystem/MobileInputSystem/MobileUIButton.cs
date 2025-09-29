using UnityEngine;
using UnityEngine.EventSystems;

namespace CoffeeBeans.PlayerSystem
{
    public class MobileUIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public Vector2 direction;

        public void OnPointerDown(PointerEventData eventData)
        {
            MobileInput.Instance.SetMoveInput(direction);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            MobileInput.Instance.SetMoveInput(Vector2.zero);
        }
    }
}