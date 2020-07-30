using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    private float m_Speed; //Sets the speed.
    //private char m_driveMode; //Used to decide if drive or reverse gears are used. 


    // Use this for initialization
    void Start()
    {
        m_Speed = 2.0f; //Set the speed of the GameObject
        //m_driveMode = 'D'; //Set the drivemode to forward. 
    }

    // Update is called once per frame
    void Update()
    {


        //TURRET:

        //Turn Right.
        if (Input.GetKey("a")) //If user right mouse click
        {
            if (this.transform.localPosition.x <= 0.0f)
            {
                //Rotate our Tank about the Y axis in the positive direction
                this.transform.position += transform.right * Time.deltaTime * m_Speed;
            }
        }

        //Turn Left.
        if (Input.GetKey("d")) //If user left mouse click
        {
            if (this.transform.localPosition.x >= -1.0f)
            {
                //Rotate our Tank about the Y axis in the negative direction
                this.transform.position -= transform.right * Time.deltaTime * m_Speed;
            }

        }
    }

}