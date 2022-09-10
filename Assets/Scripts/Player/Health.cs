using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivalIsland.Player
{
    public class Health : MonoBehaviour
    {
        Rigidbody2D rb;

        public float maxHunger = 100.0f;
        public float maxThirst = 100.0f;
        public float hunger = 100;
        public float thirst = 100;

        public float runHungerDepletionRate = 0.05f;
        public float runThirstDepletionRate = 0.05f;
        public float thirstDepletionRate = 0.05f;

        void Awake()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            hunger -= runHungerDepletionRate * rb.velocity.normalized.magnitude * Time.deltaTime;
            thirst -= (thirstDepletionRate + runThirstDepletionRate * rb.velocity.normalized.magnitude) * Time.deltaTime;
        }
    }
}