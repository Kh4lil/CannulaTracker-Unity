using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



[CustomEditor(typeof(ArduinoThreeSensors))]
public class ArduinoThreeSensorsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GUILayout.Box("iMSTK/Arduino");

        DrawDefaultInspector();
    }


}














