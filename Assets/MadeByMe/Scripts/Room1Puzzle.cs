using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Puzzle : MonoBehaviour
{
    /// <summary>
    /// Private reference to the present version of the room
    /// </summary>
    [SerializeField]
    private GameObject roomPresent;

    /// <summary>
    /// Private reference to the future version of the room
    /// </summary>
    [SerializeField]
    private GameObject roomFuture;

    private void OnTriggerEnter(Collider other)
    {
        //If the player enters the trigger collider for the room the present and future versions are assigned
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<TimeTravel>().present = roomPresent;
            other.GetComponent<TimeTravel>().future = roomFuture;
        }
    }
}
