using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SurvivalIsland.Player
{
    public class Movement : MonoBehaviour
    {
        Rigidbody2D rb;
        public float moveSpeed = 10.0f;
        public Vector2 moveDirection = Vector2.zero;
        public Vector2 lastNonZeroMoveDirection = Vector2.down;

        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            rb.velocity = moveDirection * moveSpeed;
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            moveDirection = context.ReadValue<Vector2>();
            if(moveDirection != Vector2.zero)
            {
                lastNonZeroMoveDirection = moveDirection;
            }
        }
    }
}