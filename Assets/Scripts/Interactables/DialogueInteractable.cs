using UnityEngine;
using SurvivalIsland.Player;
using SurvivalIsland.UI;

namespace SurvivalIsland.Interactables
{
    public class DialogueInteractable : Interactable
    {
        public DialogueText dialogueText;
        public override void Interact(Interactor interactor)
        {
            interactor.dialogueManager.StartDialogue(dialogueText);
        }
    }
}