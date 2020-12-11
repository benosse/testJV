﻿using UnityEngine;

/*bz
debug log dans la scene pour denug la vr
*/
public class Log : MonoBehaviour
{
    TextMesh textMesh;

 // Use this for initialization
 void Start ()
    {
        textMesh = gameObject.GetComponent<TextMesh>();
 }

    void OnEnable()
    {
        Application.logMessageReceived += LogMessage;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= LogMessage;
    }

    public void LogMessage(string message, string stackTrace, LogType type)
    {
        if (textMesh.text.Length > 300)
        {
            textMesh.text = message + "\n";
        }
        else
        {
            textMesh.text += message + "\n";
        }
    }
}