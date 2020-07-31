using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;


[AddComponentMenu("Imstk/Arduino/Multiple Sensors Example")]
public class ArduinoThreeSensors : MonoBehaviour
{

    public GameObject knotPusher;
    private float m_Speed; //Sets the speed.
    private float position = 0.0f;

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

        m_Speed = 2.0f; //Set the speed of the GameObject

    }

    void ReadSerial()
    {

        float lastVal = position;
        string dataString = stream.ReadLine();
        //var dataBlocks = dataString.Split(',');

        float.TryParse(dataString, out position);

        //Debug.Log("SENSOR 1 DATA: " + dataString);
        Debug.Log("SENSOR 1 DATA: " + position);
        if (lastVal != position)
        {
            if (lastVal < position)
            {
                knotPusher.transform.position += transform.right * Time.deltaTime * m_Speed;
            }
            if (lastVal > position)
            {
                knotPusher.transform.position += -transform.right * Time.deltaTime * m_Speed;
            }
            //Debug.Log("LAST VAL: " + lastVal + "POSITION: " + position);
        }

        //knotPusher.transform.position += transform.right * Time.deltaTime * m_Speed;
        //if (this.transform.localPosition.x <= 0.0f)
        //{
        //Rotate our Tank about the Y axis in the positive direction
        //  knotPusher.transform.position += transform.right * Time.deltaTime * position;
        //}


        /*
                while (position <= 410.0f)
                {
                    if (knotPusher.transform.localPosition.x <= -0.8f)
                    {
                        //Rotate our Tank about the Y axis in the positive direction
                        knotPusher.transform.position += transform.right * Time.deltaTime * m_Speed;
                    }
                }
        */
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
