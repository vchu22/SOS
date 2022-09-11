using SurvivalIsland.Player;
using UnityEngine;

namespace SurvivalIsland.Usables
{
    public class Consumable : MonoBehaviour, IUsable
    {
        public float hungerRegen = 0.0f;
        public float thirstRegen = 0.0f;
        public void Use(Interactor interactor)
        {
            interactor.inventory.RemoveItem();
            Destroy(gameObject);
        }
    }
}