using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class CustomConsole : EditorWindow
{
    private List<string> logs = new List<string>();
    private Vector2 scrollPosition;
    private string userInput = "";

    [MenuItem("Window/Custom Console")]
    public static void ShowWindow()
    {
        GetWindow<CustomConsole>("Custom Console");
    }

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    private void OnGUI()
    {
        // Scroll view for logs
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.Width(position.width), GUILayout.Height(position.height - 50)); // Adjusted height
        foreach (string log in logs)
        {
            EditorGUILayout.LabelField(log);
        }
        EditorGUILayout.EndScrollView();

        // Text field for user input
        userInput = EditorGUILayout.TextField(userInput, GUILayout.Height(20)); // Explicit height for clarity

        // Button to submit user input
        if (GUILayout.Button("Submit", GUILayout.Height(20))) // Explicit height for clarity
        {
            if (!string.IsNullOrEmpty(userInput))
            {
                HandleCommand(userInput);
                userInput = "";
            }
        }
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        logs.Add(logString); // Store the logs in a list
        Repaint(); // Refresh the editor window
    }

    void HandleCommand(string command)
    {
        // Handle the user's command input
        if (command.StartsWith("/")) // Assuming commands start with '/'
        {
            // Parse and execute the command
            ExecuteCommand(command);
        }
        else
        {
            logs.Add("User: " + command); // Just add to logs if not a command
        }
    }

    void ExecuteCommand(string command)
    {
        if (command.Equals("/clear"))
        {
            logs.Clear();
        }
        // Add more commands as needed
        else
        {
            logs.Add("Unknown command: " + command);
        }
    }
}
