using UnityEngine;
using UnityEngine.Events;

public class Room4Puzzle : MonoBehaviour
{
    [SerializeField]
    private GameObject roomPresent;

    [SerializeField]
    private GameObject roomFuture;

    private int switchCount = 1;

    public UnityEvent resetSwitches;

    public void SwitchPressed()
    {
        if (switchCount > 2)
        {
            switchCount = 1;
            resetSwitches.Invoke();
        }
        else
        {
            switchCount++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<TimeTravel>().present = roomPresent;
            other.GetComponent<TimeTravel>().future = roomFuture;
        }
    }
}
