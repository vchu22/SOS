using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
// using SurvivalIsland.
namespace SurvivalIsland.Player
{
    public class PickUp : MonoBehaviour
    {
        public GameObject heldItem;
        [SerializeField] private Movement movement;
        [SerializeField] private float pickupRange;
        [SerializeField] private float placeRange;

        void Awake()
        {
            movement = GetComponent<Movement>();
        }

        void Start()
        {
            heldItem = null;
        }

        public void OnPickUp(InputAction.CallbackContext context)
        {
            if(!context.performed) return;
            if (heldItem == null && Physics2D.OverlapCircle(transform.position, pickupRange, LayerMask.GetMask("PickUp")))
            {
                heldItem = Physics2D.OverlapCircle(transform.position, pickupRange, LayerMask.GetMask("PickUp")).gameObject;
                heldItem.transform.parent = transform;
                heldItem.transform.position = transform.position;
                heldItem.SetActive(false);
            }
            else if (heldItem != null)
            {
                heldItem.SetActive(true);
                heldItem.transform.parent = null;
                heldItem.transform.position = transform.position + (Vector3)movement.lastNonZeroMoveDirection * placeRange;
                heldItem = null;
            }
        }
    }
}
