using UnityEngine;
using SurvivalIsland.Player;

namespace SurvivalIsland.Interactables
{
    public class PickUp : Interactable
    {
        public override void Interact(Interactor interactor)
        {
            interactor.inventory.AddItem(gameObject);
        }
    }
}