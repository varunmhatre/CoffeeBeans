using CoffeeBeans.Interactables;
using UnityEngine;

namespace CoffeeBeans.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 3.5f;
        CharacterController cc;
        
        IInteractable currentInteractable;
        public StackController stackController;
        
        private void Awake()
        {
            cc = GetComponent<CharacterController>();
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
            cc.SimpleMove(dir * moveSpeed);
        }

        public void SetCurrentInteractable(IInteractable interactable)
        {
            currentInteractable = interactable;
        }
        
        public StackController GetStack() => stackController;
    }
}