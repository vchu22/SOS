using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

namespace SurvivalIsland.UI
{
    public class Dialogue : MonoBehaviour
    {
        public Queue<string> sentences;
        public Image dialogueBox;
        public TMP_Text dialogueText;
        public PlayerInput playerInput;

        void Awake()
        {
            dialogueBox = GetComponent<Image>();
            dialogueText = GetComponentInChildren<TMP_Text>();
            dialogueBox.enabled = false;
            dialogueText.enabled = false;
            sentences = new Queue<string>();
        }

        public void StartDialogue(DialogueText text)
        {
            dialogueBox.enabled = true;
            dialogueText.enabled = true;
            sentences.Clear();

            foreach (string sentence in text.sentences)
            {
                sentences.Enqueue(sentence);
            }

            playerInput.SwitchCurrentActionMap("UI");

            // Display first sentence
            string first = sentences.Dequeue();
            dialogueText.text = first;
        }

        public void DisplayNextSentence(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (sentences.Count == 0)
                {
                    EndDialogue();
                    return;
                }

                string sentence = sentences.Dequeue();
                dialogueText.text = sentence;
            }
        }

        void EndDialogue()
        {
            dialogueBox.enabled = false;
            dialogueText.enabled = false;
            playerInput.SwitchCurrentActionMap("Player");
        }
    }
}