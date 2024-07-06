using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnded : MonoBehaviour
{
    /// <summary>
    /// Method that runs when the game ends
    /// </summary>
    public void OnGameEnd()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        //Start of code inspired by the Unity documentation here: https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        //Makes the program wait for 3 seconds
        yield return new WaitForSeconds(3);
        //Loads the credits scene
        SceneManager.LoadScene(2);
        //Unloads the main game scene
        SceneManager.UnloadSceneAsync(1);
    }
    //End of code inspired by the Unity documentation here: https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
}
