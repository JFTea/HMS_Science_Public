using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckObjectPickup : MonoBehaviour
{
    //The Object that is being picked up
    [SerializeField]
    private GameObject pickup;

    //The event that is called when the object is picked up
    public UnityEvent Activate;

    // Update is called once per frame
    void Update()
    {
        //If the object is active and is picked up the activate event is invoked
        if (pickup.GetComponent<PickUpObject>().state == PickUpObject.PickupType.pickUP && pickup.activeInHierarchy)
        {
            Activate.Invoke();
        }
    }
}
