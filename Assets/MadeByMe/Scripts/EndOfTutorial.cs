using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class EndOfTutorial : MonoBehaviour
{
    /// <summary>
    /// Private reference to the player gameobject
    /// </summary>
    [SerializeField]
    private GameObject player;

    /// <summary>
    /// Private reference to the animator for the end of the tutorial UI that fades to black
    /// </summary>
    [SerializeField]
    private Animator animator;

    /// <summary>
    /// Runs when the tutorial ends all the corrosponding animatons play
    /// </summary>
    public void OnTutorialEnd()
    {
        //Enables the first person controller
        player.GetComponent<FirstPersonController>().enabled = false;

        //Sets the players rotation towards the airlock door
        player.transform.rotation = Quaternion.Euler(-20f, 90f, 0f);
        //Adds the force sending the player into space
        player.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * 100);
        //The screen starts to fade to black
        animator.SetBool("Fade",true);

        //Start of code inspired by the Unity documentation here: https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
       //The program waits for 3 second
        yield return new WaitForSeconds(3);
        //The main game scene loads
        SceneManager.LoadScene(1);
        //Unloads the tutorial scene
        SceneManager.UnloadSceneAsync(0);
    }
    //End of code inspired by the Unity documentation here: https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
}
