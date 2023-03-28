using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using PjlinkClient;
using Unity.VisualScripting;

public class AduinoOFF : MonoBehaviour // �Ƶ��̳� off ��Ű�� ��ũ��Ʈ
{    // ����
    //SerialPort serialPort = new SerialPort("COM"+DataManager.Instance.data.Devel_COM, 9600, Parity.None, 8, StopBits.One);
    private SerialPort serialPort; 

    private void Start()
    {
        try
        {
            serialPort = new SerialPort("COM" + DataManager.Instance.data.Devel_COM, 9600, Parity.None, 8, StopBits.One); // COM + ����ڰ� �Է��� ���� , ��żӵ�, �и�Ƽ �˻�, ������ ��Ʈ
            serialPort.Handshake = Handshake.None;
            serialPort.DtrEnable = false; // DtrEnable�� false�� ���� (�Ƶ��̳� �ڵ����� ����
            serialPort.ReadTimeout = 3; // readtimeout ���� ��� ���� (1~10)������ ����
            serialPort.Open();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to open serial port: " + e.Message);
        }
    }

    private void Update()
    {
        if (serialPort != null && serialPort.IsOpen && serialPort.BytesToRead > 0) // �ø�����Ʈ�� �����ְ�, ���� �� �ִ� ����Ʈ�� �ִٸ� ����
        {
            string line = serialPort.ReadLine();

            if (line == "1") // ���� �����Ͱ� "1"�̶�� 
            {
                this.gameObject.GetComponent<Server>().AllOff(); // AllOFF �޼��� ����
            }
        }
    }

    public void ArduinoOffCommand()
    {
            serialPort.WriteLine("c"); // off ��ɾ� close�� "c"
    }

    public void ArduinoOnCommand()
    {
            serialPort.WriteLine("s"); // on ��ɾ� open�� "s"
    }

    private void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}