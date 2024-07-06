using UnityEngine;
using UnityEngine.UI;

public class LogCollected : MonoBehaviour
{
    /// <summary>
    /// Private reference to the shield log image button
    /// </summary>
    [SerializeField]
    private Image shieldLog;

    /// <summary>
    /// Private reference to the crew log image button
    /// </summary>
    [SerializeField]
    private Image crewLog;

    /// <summary>
    /// Private reference to the engine log image button
    /// </summary>
    [SerializeField]
    private Image engineLog;

    /// <summary>
    /// Private reference to the med log image button
    /// </summary>
    [SerializeField]
    private Image medLog;

    /// <summary>
    /// Runs when a log is collected and checks which log is collected and enables the corrosponding button
    /// </summary>
    /// <param name="logName"></param>
    public void CollectedLog(string logName)
    {
        //Checks the log name against all available logs
        switch (logName)
        {
            case "ShieldLog":
                ShieldLogUnlock();
                break;
            case "CrewLog":
                CrewLogUnlock();
                break;
            case "EngineLog":
                EngineLogUnlock();
                break;
            case "MedLog":
                MedLogUnlock();
                break;
        }
    }

    /// <summary>
    /// Unlocks the shield log button
    /// </summary>
    private void ShieldLogUnlock()
    {
        shieldLog.GetComponent<Button>().enabled = true;
    }

    /// <summary>
    /// Unlocks the engine log button
    /// </summary>
    private void EngineLogUnlock()
    {
        engineLog.GetComponent<Button>().enabled = true;
    }

    /// <summary>
    /// Unlocks the crew log button
    /// </summary>
    private void CrewLogUnlock()
    {
        crewLog.GetComponent<Button>().enabled = true;
    }

    /// <summary>
    /// Unlocks the med log button
    /// </summary>
    private void MedLogUnlock()
    {
        medLog.GetComponent<Button>().enabled = true;
    }
}
