using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.Characters.FirstPerson;

public class PickUpLog : MonoBehaviour
{
    /// <summary>
    /// Private reference to the name of the text log
    /// </summary>
    [SerializeField]
    private string logName;

    /// <summary>
    /// Private reference to the gameobject of the text log
    /// </summary>
    [SerializeField]
    private GameObject textLogObject;

    /// <summary>
    /// Private reference to the player gameobject
    /// </summary>
    [SerializeField]
    private GameObject player;

    /// <summary>
    /// Private reference to the boolean that checks if the player is near
    /// </summary>
    private bool playerNear = false;

    /// <summary>
    /// Public event that is triggered when the log is picked up
    /// </summary>
    public UnityEvent logPickedUp;

    /// <summary>
    /// Private reference to the interaction prompt canvas
    /// </summary>
    [SerializeField]
    private Canvas promptCanvas;

    // Update is called once per frame
    void Update()
    {
        //If the player is near the log and presses 'E' the log will be collected
        if (Input.GetKeyDown(KeyCode.E) && playerNear)
        {
            CollectLog();
        }
    }

    /// <summary>
    /// Loads the text log window and calls the logPickedUp event
    /// </summary>
    private void CollectLog()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        player.GetComponent<FirstPersonController>().enabled = false;

        //Calls the logPickedUp event
        logPickedUp.Invoke();
        //Loads the text for the picked up text log
        textLogObject.GetComponent<TextLog>().ImportTextLog(logName);
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the player is in the trigger collider of the log then playerNear is true
        if (other.gameObject.tag == "Player")
        {
            playerNear = true;
            promptCanvas.GetComponent<Canvas>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //If the player moves out of the trigger collider of the log then playerNear is false
        if (other.gameObject.tag == "Player")
        {
            playerNear = false;
            promptCanvas.GetComponent<Canvas>().enabled = false;
        }
    }


}
