using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

[AddComponentMenu("Imstk/Arduino/Arduino Control Panel")]
public class ArduinoConnector : MonoBehaviour
{
    //Device 
    [Tooltip("SerialPort that the device is using (Example: COM4)")]
    public string portName = "COM3";
    [Tooltip("Baudrate of the communication (Example: 9600)")]
    public int baudRate = 9600;
    private SerialPort stream;

    public static bool readData;
    public static bool writeData;







    // Start is called before the first frame update
    void Start()
    {
        //Initialization of the Serial Communication
        stream = new SerialPort(portName, baudRate);
        stream.Open();
        stream.ReadTimeout = 1;
    }

    // Remove the update section if the communication is from Unity to Arduino. 
    void Update()
    {
        //Debug.Log("readData: " + readData);
        //Debug.Log("wireData: " + writeData);
    }

    void OnApplicationQuit()
    {
        stream.Close();
    }

    public void HardwareConnection()
    {
        stream = new SerialPort(portName, baudRate);
        if (!stream.IsOpen)
        {
            stream.Open();
        }


        if (stream.IsOpen)
        {
            try
            {
                Debug.Log("Serial Connection is successful on Port: " + portName);
                stream.Close();
            }
            catch (System.Exception)
            {
            }
        }

    }
}
