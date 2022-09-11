using UnityEngine;

namespace SurvivalIsland.UI
{
    [System.Serializable]
    public class DialogueText
    {
        [TextArea(3, 10)]
        public string[] sentences;
    }
}