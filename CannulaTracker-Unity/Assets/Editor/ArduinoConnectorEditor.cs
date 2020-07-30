using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO.Ports;

[CustomEditor(typeof(ArduinoConnector))]
public class ArduinoConnectorEditor : Editor
{
    Color headerColor = new Color(0.65f, 0.65f, 0.65f, 1);
    public override void OnInspectorGUI()
    {
        GUILayout.Box("iMSTK/Arduino");
        bool defaultPanel = true;
        DrawHeaderTitle("Serial Communmication Settings", defaultPanel, headerColor);


        DrawDefaultInspector();
        ArduinoConnector arduinoConnector = (ArduinoConnector)target;

        SetGUIBackgroundColor("#4FC3F7");
        if (GUILayout.Button("Check Hardware Connection")) {
            arduinoConnector.HardwareConnection();
         }

        GUI.backgroundColor = Color.white;

        GUILayout.Label("Communication Type", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        ArduinoConnector.readData = EditorGUILayout.Toggle("Read Data", ArduinoConnector.readData);
        ArduinoConnector.writeData = EditorGUILayout.Toggle("Write Data", ArduinoConnector.writeData);


    }
    void SetGUIBackgroundColor(string hex)
    {
        Color color = new Color();
        ColorUtility.TryParseHtmlString(hex, out color);
        GUI.backgroundColor = color;
    }

    public bool DrawHeaderTitle(string title, bool foldoutProperty, Color backgroundColor)
    {
        GUILayout.Space(0);
        Rect lastRect = GUILayoutUtility.GetLastRect();
        GUI.Box(new Rect(1, lastRect.y + 4, Screen.width, 27), "");
        lastRect = GUILayoutUtility.GetLastRect();
        EditorGUI.DrawRect(new Rect(lastRect.x - 15, lastRect.y + 5f, Screen.width + 1, 25f), headerColor);
        GUI.Label(new Rect(lastRect.x, lastRect.y + 10, Screen.width, 25), title);
        GUI.color = Color.clear;
        if (GUI.Button(new Rect(0, lastRect.y + 4, Screen.width, 27), ""))
        {
            foldoutProperty = !foldoutProperty;
        }
        GUI.color = Color.white;
        GUILayout.Space(30);
        if (foldoutProperty) { GUILayout.Space(5); }
        return foldoutProperty;
    }


    }
