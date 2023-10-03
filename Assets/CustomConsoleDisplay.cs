using UnityEngine;
using TMPro;

public class GameConsoleDisplay : MonoBehaviour
{
    public TextMeshProUGUI consoleOutputText;

    private void Awake()
    {
        // Subscribe to Unity's log callback
        Application.logMessageReceived += HandleLog;
    }

    private void OnDestroy()
    {
        // Unsubscribe when this object is destroyed
        Application.logMessageReceived -= HandleLog;
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        // Update the in-game UI
        if (consoleOutputText != null)
        {
            consoleOutputText.text += logString + "\n";
        }
    }
}
