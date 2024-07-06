using UnityEngine;

public class ActivateTravel : MonoBehaviour
{
    //When the player enters the trigger collider the player can time travel
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<TimeTravel>().canTravel = true;
        }
    }

    //When the player leaves the tigger collider the player can no longer time travel
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<TimeTravel>().canTravel = false;
        }
    }
}
