using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using SurvivalIsland.
namespace SurvivalIsland.PickUp
{
    public class PickUp : MonoBehaviour
    {
        [SerializeField]
        bool held = false;
        [SerializeField]
        bool inReach = false;
        [SerializeField]
        KeyCode pickUpKey = KeyCode.F;
        [SerializeField]
        GameObject player;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKey(pickUpKey) && inReach && !held)
            {
                Grab();
            }
            else if (Input.GetKey(pickUpKey) && held)
            {
                Place();
            }
        }
        void OnTriggerEnter()
        {
            inReach = true;
        }
        void OnTriggerExit()
        {
            inReach = false;
        }
        void Grab()
        {
            held = true;
            gameObject.transform.SetParent(player.transform);
        }
        void Place()
        {
            held = false;
            gameObject.transform.SetParent(null);
        }

    }
}
