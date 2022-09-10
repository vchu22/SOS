using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 10.0f;
    float horizontal = 0.0f;
    float vertical = 0.0f;
    float hunger = 100.0f;
    float thirst = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
        
    }
}
