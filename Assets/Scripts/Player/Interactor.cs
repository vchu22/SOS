using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using SurvivalIsland.Interactables;

namespace SurvivalIsland.Player
{
    public class Interactor : MonoBehaviour
    {
        private Movement movement;
        [HideInInspector] public Health health;
        [HideInInspector] public Inventory inventory;
        public float interactRange = 1.0f;

        public void Awake()
        {
            movement = GetComponent<Movement>();
            health = GetComponent<Health>();
            inventory = GetComponent<Inventory>();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, movement.lastNonZeroMoveDirection, interactRange, LayerMask.GetMask("Interactable"));
                if (hit.collider != null)
                {
                    Debug.Log("Interact");
                    hit.collider.GetComponent<Interactable>().Interact(this);
                }
                else
                {
                    inventory.RemoveItem();
                }
            }
        }
    }
}