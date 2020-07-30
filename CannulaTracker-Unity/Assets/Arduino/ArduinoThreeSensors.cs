using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;


[AddComponentMenu("Imstk/Arduino/Multiple Sensors Example")]
public class ArduinoThreeSensors : MonoBehaviour
{

    //Device 
    [Tooltip("SerialPort that the device is using (Example: COM4)")]
    public string portName = "COM3";
    [Tooltip("Baudrate of the communication (Example: 9600)")]
    public int baudRate = 9600;
    private SerialPort stream;

    //public GameObject ObjectToScale;
    public GameObject ControlObject;

    private bool serialOK = false;



    // Start is called before the first frame update
    void Start()
    {
        //Initialization of the Serial Communication
        stream = new SerialPort(portName, baudRate);
        stream.Open();
        stream.ReadTimeout = 1;

    }

    void ReadSerial()
    {
        string dataString = stream.ReadLine();
        //var dataBlocks = dataString.Split(',');


        Debug.Log("SENSOR 1 DATA: " + dataString);
    }



    // Update is called once per frame
    void Update()
    {
        if (stream.IsOpen)
        {
            try
            {
                ReadSerial();
            }
            catch (Exception)
            {
                Debug.LogWarning("Serial Failed");
            }
        }
    }
}
