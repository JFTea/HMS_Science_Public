using UnityEngine;
using TMPro;

public class Room2Puzzle : MonoBehaviour
{
    /// <summary>
    /// Private reference to the first lock switch gameobject
    /// </summary>
    [SerializeField]
    private GameObject switch1;
    /// <summary>
    /// Private reference to the first switch screen
    /// </summary>
    [SerializeField]
    private TMP_Text switch1Text;

    /// <summary>
    /// Private reference to the second lock switch gameobject
    /// </summary>
    [SerializeField]
    private GameObject switch2;
    /// <summary>
    /// Private reference to the second switch screen
    /// </summary>
    [SerializeField]
    private TMP_Text switch2Text;

    /// <summary>
    /// Private reference to the second switch light
    /// </summary>
    [SerializeField]
    private Light switch2Light;

    /// <summary>
    /// Private reference to the third lock switch gameobject
    /// </summary>
    [SerializeField]
    private GameObject switch3;
    /// <summary>
    /// Private reference to the second switch light
    /// </summary>
    [SerializeField]
    private Light switch3Light;
    /// <summary>
    /// Private reference to the third switch screen
    /// </summary>
    [SerializeField]
    private TMP_Text switch3Text;

    /// <summary>
    /// Private reference to the bool that tracks when the first switch is active
    /// </summary>
    private bool switch1Active = false;

    /// <summary>
    /// Private reference to the bool that tracks when the second switch is active
    /// </summary>
    private bool switch2Active = false;

    /// <summary>
    /// Private reference to the bool that tracks when the third switch is active
    /// </summary>
    private bool switch3Active = false;

    /// <summary>
    /// Private reference to the present version of this room
    /// </summary>
    [SerializeField]
    private GameObject roomPresent;

    /// <summary>
    /// Private reference to the future version of this room
    /// </summary>
    [SerializeField]
    private GameObject roomFuture;

    /// <summary>
    /// Sets the first lock switch to active and enabled the second switch
    /// </summary>
    public void Switch1Activate()
    {
        if (switch1Active)
        {
            switch1Active = false;
        }
        else
        {
            switch1Active = true;
            switch2Light.GetComponent<Light>().enabled = true;
            switch1Text.text = "Lock 1 Status: UnLocked";
        }

    }

    /// <summary>
    /// Sets the second lock switch to active and enables the third switch, if the first switch is not activated then the switches are reset
    /// </summary>
    public void Switch2Activate()
    {
        if (switch1Active)
        {
            switch2Active = true;
            switch2.GetComponent<Switch>().canSwitch = false;

            switch3Light.GetComponent<Light>().enabled = true;
            switch2Text.text = "Lock 2 Status: UnLocked";
        }
        else
        {
            ResetSwitches();
        }
    }

    /// <summary>
    /// Sets the second lock switch to active and unlocks the door, if the second switch is not activated then the switches are reset
    /// </summary>
    public void Switch3Activate()
    {
        if (switch2Active)
        {
            switch3Active = true;
            switch2.GetComponent<Switch>().canSwitch = false;
            switch3Text.text = "Lock 3 Status: UnLocked";
        }
        else
        {
            ResetSwitches();
        }
    }

    /// <summary>
    /// Resets the puzzle back the beginning
    /// </summary>
    public void ResetSwitches()
    {
        //Turns the switches off
        switch1.GetComponent<Switch>().TurnOff();
        switch2.GetComponent<Switch>().TurnOff();
        switch3.GetComponent<Switch>().TurnOff();

        //Disables the switch lights
        switch3Light.GetComponent<Light>().enabled = false;
        switch2Light.GetComponent<Light>().enabled = false;

        //Sets the switch trackers to false
        switch1Active = false;
        switch2Active = false;
        switch3Active = false;

        //Resets switch text
        switch1Text.text = "Lock 1 Status: Locked";
        switch2Text.text = "Lock 2 Status: Locked";
        switch3Text.text = "Lock 3 Status: Locked";
    }

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
