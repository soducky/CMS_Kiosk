using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using PjlinkClient;
using Unity.VisualScripting;

public class AduinoOFF : MonoBehaviour // 아두이노 off 시키는 스크립트
{    // 형식
    //SerialPort serialPort = new SerialPort("COM"+DataManager.Instance.data.Devel_COM, 9600, Parity.None, 8, StopBits.One);
    private SerialPort serialPort; 

    private void Start()
    {
        try
        {
            serialPort = new SerialPort("COM" + DataManager.Instance.data.Devel_COM, 9600, Parity.None, 8, StopBits.One); // COM + 사용자가 입력한 숫자 , 통신속도, 패리티 검사, 데이터 비트
            serialPort.Handshake = Handshake.None;
            serialPort.DtrEnable = false; // DtrEnable을 false로 설정 (아두이노 자동리셋 중지
            serialPort.ReadTimeout = 3; // readtimeout 수신 대기 설정 (1~10)범위로 설정
            serialPort.Open();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to open serial port: " + e.Message);
        }
    }

    private void Update()
    {
        if (serialPort != null && serialPort.IsOpen && serialPort.BytesToRead > 0) // 시리얼포트가 열려있고, 읽을 수 있는 바이트가 있다면 실행
        {
            string line = serialPort.ReadLine();

            if (line == "1") // 만약 데이터가 "1"이라면 
            {
                this.gameObject.GetComponent<Server>().AllOff(); // AllOFF 메서드 실행
            }
        }
    }

    public void ArduinoOffCommand()
    {
            serialPort.WriteLine("c"); // off 명령어 close의 "c"
    }

    public void ArduinoOnCommand()
    {
            serialPort.WriteLine("s"); // on 명령어 open의 "s"
    }

    private void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}