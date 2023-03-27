using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using PjlinkClient;
using Unity.VisualScripting;

public class AduinoOFF : MonoBehaviour
{
    //SerialPort serialPort = new SerialPort("COM"+DataManager.Instance.data.Devel_COM, 9600, Parity.None, 8, StopBits.One);
    private SerialPort serialPort;

    private void Start()
    {
        try
        {
            serialPort = new SerialPort("COM" + DataManager.Instance.data.Devel_COM, 9600, Parity.None, 8, StopBits.One);
            serialPort.Handshake = Handshake.None;
            serialPort.DtrEnable = false; // DtrEnable을 false로 설정
            serialPort.ReadTimeout = 1;
            serialPort.Open();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to open serial port: " + e.Message);
        }
    }

    private void Update()
    {
        if (serialPort != null && serialPort.IsOpen && serialPort.BytesToRead > 0)
        {
            string line = serialPort.ReadLine();

            if (line == "1")
            {
                this.gameObject.GetComponent<Server>().AllOff();
            }
        }
    }

    public void ArduinoOffCommand()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.WriteLine("c");
        }
    }

    public void ArduinoOnCommand()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.WriteLine("s");
        }
    }

    private void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}