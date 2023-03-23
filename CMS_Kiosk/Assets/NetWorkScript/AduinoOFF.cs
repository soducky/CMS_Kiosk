using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using PjlinkClient;
using Unity.VisualScripting;

public class AduinoOFF : MonoBehaviour
{
    //  SerialPort serialPort = new SerialPort(DataManager.Instance.data.Devel_COM, 9600, Parity.None, 8, StopBits.One);
    SerialPort serialPort;
    void Start()
    {
        serialPort = new SerialPort(DataManager.Instance.data.Devel_COM, 9600, Parity.None, 8, StopBits.One);
        serialPort.Open();
        serialPort.ReadTimeout = 1;
    }

    private void Update()
    {
        if(serialPort.IsOpen == true)
        {
            if(serialPort.ReadLine() == "1")
            {
                this.gameObject.GetComponent<Server>().AllOff();
            }
        }
    }

    public void ArduinoOffCommand()
    {
        serialPort.WriteLine("c");
    }

    public void ArduinoOnCommand()
    {
        serialPort.WriteLine("s");
    }
}


