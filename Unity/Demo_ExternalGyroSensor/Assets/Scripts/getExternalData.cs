using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class getExternalData : MonoBehaviour
{
    public int comPort;
    public int bautRate;
    
    private SerialPort sp;
    private char delimiter = ',';
    private float offsetX, offsetY, offsetZ;

    // Use this for initialization
    void Start()
    {
        sp = new SerialPort("COM" + comPort.ToString(), bautRate);
        sp.Open();
        sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                string extData = sp.ReadLine();
                string[] substrings = extData.Split(delimiter);

                // reset
                if (Input.GetKeyUp("space"))
                {
                    offsetX = float.Parse(substrings[0]);
                    offsetY = float.Parse(substrings[2]);
                    offsetZ = float.Parse(substrings[1]);
                }
                
                transform.eulerAngles = new Vector3(
                    float.Parse(substrings[0]) + offsetX,
                    float.Parse(substrings[2]) + offsetY,
                    float.Parse(substrings[1]) - offsetZ
                );
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    }
}
