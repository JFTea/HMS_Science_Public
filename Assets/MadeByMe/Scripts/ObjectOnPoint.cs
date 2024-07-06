using UnityEngine;
using UnityEngine.Events;

public class ObjectOnPoint : MonoBehaviour
{
    /// <summary>
    /// Private reference to the object needed for the solution to the puzzle
    /// </summary>
    [SerializeField]
    private GameObject solution;

    /// <summary>
    /// Private reference to the animation controller
    /// </summary>
    [SerializeField]
    private Animator animator;

    /// <summary>
    /// The event triggered when the puzzle is solved
    /// </summary>
    public UnityEvent solved = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == solution)
        {
            animator.SetTrigger("Go");
            // Changes the state of the object to solved
            solution.GetComponent<PickUpObject>().state = PickUpObject.PickupType.Solved;
            solution.SetActive(false);
            //Invokes the solved event
            solved.Invoke();
        }
    }
}
