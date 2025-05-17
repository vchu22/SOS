using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public Button closeButton;
    void Awake()
    {
        closeButton.GetComponent<Button>().onClick.AddListener(ClosePopup);
    }
    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}
