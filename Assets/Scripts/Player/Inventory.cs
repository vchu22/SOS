using UnityEngine;
using UnityEngine.UI;
using SurvivalIsland.Usables;
using UnityEngine.InputSystem;

namespace SurvivalIsland.Player
{
    public class Inventory : MonoBehaviour
    {
        private GameObject item;
        public Image itemImage;
        private Movement movement;
        private Interactor interactor;
        public float dropRange = 1.0f;

        public void Awake()
        {
            movement = GetComponent<Movement>();
            interactor = GetComponent<Interactor>();
        }

        public void AddItem(GameObject item)
        {
            if (this.item == null)
            {
                this.item = item;
                item.transform.parent = transform;
                item.transform.localPosition = Vector3.zero;
                item.SetActive(false);
                itemImage.color = Color.white;
                itemImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
            }
        }

        public void RemoveItem()
        {
            if (item != null)
            {
                item.transform.parent = null;
                item.transform.position = transform.position + (Vector3)movement.lastNonZeroMoveDirection * dropRange;
                item.SetActive(true);
                item = null;
                itemImage.color = Color.clear;
                itemImage.sprite = null;
            }
        }

        public void OnUse(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (item != null)
                {
                    IUsable usable = item.GetComponent<IUsable>();
                    if (usable != null)
                    {
                        usable.Use(interactor);
                    }
                }
            }
        }
    }
}