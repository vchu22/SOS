using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivalIsland.Player;

public class Health : MonoBehaviour
{
    Rigidbody2D rb;

    float hunger = 100;
    float thirst = 100;
    
    float runHungerDepletionRate = 0.05;
    float thirstDepletionRate = 0.05;

    void Update()
    {
        hunger -= runHungerDepletionRate * rb.velocity.magnitude * Time.deltaTime;
        thirst -= thirstDepletionRate * Time.deltaTime;
    }
}