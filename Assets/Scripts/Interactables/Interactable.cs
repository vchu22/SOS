using UnityEngine;
using SurvivalIsland.Player;

namespace SurvivalIsland.Interactables
{
    public class Interactable : MonoBehaviour
    {
        public virtual void Interact(Interactor interactor) {}
    }
}