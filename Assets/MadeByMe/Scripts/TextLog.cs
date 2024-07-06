using TMPro;
using UnityEngine;

public class TextLog : MonoBehaviour
{
    /// <summary>
    /// Private reference to the text box for the text log
    /// </summary>
    private TMP_Text displayText;

    /// <summary>
    /// Private reference to the text log canvas
    /// </summary>
    [SerializeField]
    private Canvas canvas;
    // Start is called before the first frame update
    void Awake()
    {
        displayText = GetComponent<TMP_Text>();
    }

    public void ImportTextLog(string logName)
    {
        //Reads the text for the data log from the text file
        //Using the resources folder was inspired by this post: https://stackoverflow.com/questions/70715187/unity-read-and-write-to-txt-file-after-build
        displayText.text = Resources.Load(logName).ToString();
        //Inspired code ends
        canvas.enabled = true;
    }
}
