using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SurvivalIsland.Player
{
    public class Interactor : MonoBehaviour
    {
        private Movement movement;
        public float interactRange = 1.0f;

        public void Awake()
        {
            movement = GetComponent<Movement>();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, movement.lastNonZeroMoveDirection, interactRange, LayerMask.GetMask("Interactable"));
                if (hit.collider != null)
                {
                    hit.collider.GetComponent<IInteractable>().Interact(this);
                }
            }
        }
    }
}