using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{

    /// <summary>
    /// Private reference to the door animator that controls the door states
    /// </summary>
    [SerializeField]
    private Animator animator;

    /// <summary>
    /// Private reference to the isOpen bool that defines if the door is open
    /// </summary>
    [SerializeField]
    private bool isOpen = false;

    /// <summary>
    /// Private reference to the isLocked bool that defines if the door is locked or not
    /// </summary>
    [SerializeField]
    private bool isLocked = true;

    /// <summary>
    /// Private reference to the bool that controls if the door is locked or not
    /// </summary>
    private bool justUnlocked = false;

    /// <summary>
    /// Private reference to the player gameobject
    /// </summary>
    private GameObject player;

    /// <summary>
    /// Private reference to the volume control gameobject
    /// </summary>
    private GameObject volumeControl;

    // Start is called before the first frame update
    void Start()
    {
        //Checks the current state of the door
        CheckState();
        //Finds the player gameobject
        player = GameObject.FindGameObjectWithTag("Player");

        //Adds a listener to the change time event in the time travel state, the method added is the check state method
        //This is so the door will be in the correct state after time travel has occured
        player.GetComponent<TimeTravel>().changeTime.AddListener(CheckState);

        //Finds the sound effects settings gameobject
        volumeControl = GameObject.FindGameObjectWithTag("SoundEffectSettings");
        //Adds the UpdateAudio method to the listeners for the onValueChanged event for the sound effects volume setting
        if(volumeControl != null )
        volumeControl.GetComponent<Slider>().onValueChanged.AddListener(UpdateAudio);
    }

    /// <summary>
    /// Sets the volume of the open door sound effect
    /// </summary>
    /// <param name="value"></param>
    void UpdateAudio(float value)
    {
        GetComponent<AudioSource>().volume = value;
    }

    /// <summary>
    /// Checks the current lock state of the door and plays the corrosponding animation
    /// </summary>
    void CheckState()
    {
        //If the door is locked the lock method will run
        if (isLocked)
        {
            Lock();
        }
        else //The unlock method will run
        {
            Unlock();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the colliding object is the player and the door is not locked or already open the door will open
        if (other.gameObject.tag == "Player")
        {
            if (!isOpen && !isLocked)
            {
                //Door sound effect plays
                GetComponent<AudioSource>().Play();
                //The Open door animation will play
                animator.SetTrigger("Open");
                isOpen = true;
                justUnlocked = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //If the colliding object is the player and the door is open the door will close
        if (other.gameObject.tag == "Player")
        {
            if (isOpen)
            {
                //Door sound effect plays
                GetComponent<AudioSource>().Play();

                //Close door animation plays
                animator.SetTrigger("Close");
                isOpen = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //If the colliding object is the player and the door is just unlocked the door will open
        if (other.gameObject.tag == "Player")
        {
            //If the player is in the door trigger and the door becomes unlocked it will open
            if (justUnlocked)
            {
                //Door sound effect plays
                GetComponent<AudioSource>().Play();
                //Open door animation plays
                animator.SetTrigger("Open");
                isOpen = true;
                justUnlocked = false;
            }
        }
    }

    /// <summary>
    /// Triggers the unlock animation for the door and unlocks the door
    /// </summary>
    public void Unlock()
    {
        animator.SetTrigger("Unlock");
        isLocked = false;
        justUnlocked = true;
    }

    /// <summary>
    /// Triggers the lock animation for the door and locks the door
    /// </summary>
    public void Lock()
    {
        if (isOpen)
        {
            animator.SetTrigger("Close");
        }
        animator.SetTrigger("Lock");
        isLocked = true;
    }

}
