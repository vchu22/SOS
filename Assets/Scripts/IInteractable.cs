using UnityEngine;
using SurvivalIsland.Player;

namespace SurvivalIsland
{
    public interface IInteractable
    {
        void Interact(Interactor interactor);
    }
}