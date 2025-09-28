using CoffeeBeans.Interactables;
using UnityEngine;

namespace CoffeeBeans.Player
{
    public class PlayerController : MonoBehaviour
    {
        private float moveSpeed = 0.1f;
        
        private IInteractable currentInteractable;
        public StackController stackController;
        
        private void Awake()
        {
            if (stackController == null) stackController = GetComponentInChildren<StackController>();
        }
        
        private void Update()
        {
            Move();
            
            if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
            {
                currentInteractable.Interact(this);
            }
        }
        
        void Move()
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Vector3 dir = new Vector3(h, 0, v).normalized;
            transform.position += dir * moveSpeed;
        }

        public void SetCurrentInteractable(IInteractable interactable)
        {
            currentInteractable = interactable;
        }
        
        public StackController GetStack() => stackController;
    }
}