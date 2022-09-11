using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SurvivalIsland.Player;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health health;

    [SerializeField] private Image hungerBar;
    [SerializeField] private Image thirstBar;
    [SerializeField] private GameObject failScreen;

    void Start()
    {
        hungerBar.fillAmount = health.hunger / health.maxHunger;
        thirstBar.fillAmount = health.thirst / health.maxThirst;
    }

    void Update()
    {
        hungerBar.fillAmount = health.hunger / health.maxHunger;
        thirstBar.fillAmount = health.thirst / health.maxThirst;
        if(health.hunger <= 0 || health.thirst <= 0)
        {
            failScreen.SetActive(true);
        }
    }
}
