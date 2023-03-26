using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Sockets;
using System.IO;
using System;
using PjlinkClient;
using System.Globalization;
using System.Net;

public class Client : MonoBehaviour
{
    string clientName;

    bool socketReady;

    int h;
    string _hostName;
    int _port;

    TcpClient socket;
    NetworkStream stream;
    StreamWriter writer;
    StreamReader reader;

    private void Start()
    {
        ConnectToServer();
    }
    public void ConnectToServer()
    {
        // �̹� ����Ǿ��ٸ� �Լ� ����
        if (socketReady) return;

        // �⺻ ȣ��Ʈ/ ��Ʈ��ȣ
        string ip = DataManager.Instance.data.Devel_IP;
        int port = int.Parse(DataManager.Instance.data.Devel_Port);

        // ���� ����
        try
        {
            socket = new TcpClient(ip, port);
            stream = socket.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);
            socketReady = true;
        }
        catch (Exception e)
        {
            Debug.Log("���Ͽ���" + e);
        }
    }

    void Update()
    {
        if (socketReady && stream.DataAvailable)
        {
            string data = reader.ReadLine();
            if (data != null)
                OnIncomingData(data);
        }
    }

    void OnIncomingData(string data)
    {
        if (data == "%NAME")
        {
            clientName = DataManager.Instance.data.Devel_Name;
            Send($"&NAME|{clientName}"); // �̸� ������ 
            return;
        }

        for (int k = 0; k < DataManager.Instance.data.i; k++)
        {
            if (data == DataManager.Instance.data.IPAddress[k]+0)   // Ŭ���̾�Ʈ �����°� Ȯ��
            {
                DataManager.Instance.data.ImageLight[k] = false; // �̹�����ü
                DataManager.Instance.data.ZoneLight[k] = false;
            }
        }

        for (int k = 0; k < DataManager.Instance.data.i; k++)
        {
            if (data == DataManager.Instance.data.IPAddress[k]+1)
            {
                DataManager.Instance.data.ImageLight[k] = true;   // Ŭ���̾�Ʈ ���� Ȯ�� �� �̹��� ��ü
                DataManager.Instance.data.ZoneLight[k] = true;
            }
        }

        if(data == "192.168.5.241")
        {
            DataManager.Instance.data.ImageLight[16] = true;
            DataManager.Instance.data.ZoneLight[16] = true;
        }

        if (data == "192.168.5.240")
        {
            DataManager.Instance.data.ImageLight[16] = false;
            DataManager.Instance.data.ZoneLight[16] = false;
        }
    }

    void Send(string data)
    {
        if (!socketReady) return;

        writer.WriteLine(data);
        writer.Flush();
    }

    public void OnSendButton(string SendInput) // ���ڸ� ��� �����鼭 ������ ���ȴ��� Ȯ�� 
    {
        string message = SendInput;     // ����ɶ� �����ȣ ������

        Send(message);
    }

    public void AllOn()
    {
        for (h = 0; h < DataManager.Instance.data.i; h++)
        {
            if (DataManager.Instance.data.modeSelect[h] == false && DataManager.Instance.data.IPAddress[h] != "0")
            {
                _hostName = DataManager.Instance.data.IPAddress[h];
                _port = int.Parse(DataManager.Instance.data.Port[h]);

                if (_port == 4352)
                {
                    PjlinkClient2 PJ = new PjlinkClient2(_hostName, _port, 2000);
                    PJ.PowerOn();

                    if (PJ.value == 1)
                    {
                        DataManager.Instance.data.ImageLight[h] = true;
                        DataManager.Instance.data.ZoneLight[h] = true;
                    }
                }
            }

            else if (DataManager.Instance.data.modeSelect[h] == true && DataManager.Instance.data.IPAddress[h] != "0")
            {
                Invoke("AllOnLaterPC", float.Parse(DataManager.Instance.data.Devel_Time));
            }
        }
    }

    public void AllOnLaterPC()
    {
        for (h = 0; h < DataManager.Instance.data.i; h++)
        {
            if (DataManager.Instance.data.modeSelect[h] == true && DataManager.Instance.data.IPAddress[h] != "0")
            {
                UdpClient udpClient = new UdpClient();
                udpClient.EnableBroadcast = true;

                var dgram = new byte[1024];

                for (int i = 0; i < 6; i++)
                {
                    dgram[i] = 255;
                }

                byte[] address_bytes = new byte[6];

                for (int i = 0; i < 6; i++)
                {
                    address_bytes[i] = byte.Parse(DataManager.Instance.data.MacAddress[h].Substring(3 * i, 2), NumberStyles.HexNumber);
                }

                var macaddress_block = dgram.AsSpan(6, 16 * 6);

                for (int i = 0; i < 16; i++)
                {
                    address_bytes.CopyTo(macaddress_block.Slice(6 * i));
                }

                udpClient.Send(dgram, dgram.Length, new System.Net.IPEndPoint(IPAddress.Broadcast, int.Parse(DataManager.Instance.data.Port[h])));

                udpClient.Close();
            }
        }
    }


    public void NoKioskAllOn()
    {
        try
        {
            GameObject.FindGameObjectWithTag("Server").GetComponent<AduinoOFF>().ArduinoOnCommand();

            for (h = 4; h < DataManager.Instance.data.i; h++)
            {
                if (DataManager.Instance.data.modeSelect[h] == false && DataManager.Instance.data.IPAddress[h] != "0")
                {
                    _hostName = DataManager.Instance.data.IPAddress[h];
                    _port = int.Parse(DataManager.Instance.data.Port[h]);

                    if (_port == 4352)
                    {
                        PjlinkClient2 PJ = new PjlinkClient2(_hostName, _port, 2000);
                        PJ.PowerOn();

                        if (PJ.value == 1)
                        {
                            DataManager.Instance.data.ImageLight[h] = true;
                            DataManager.Instance.data.ZoneLight[h] = true;
                        }
                    }
                }

                else if (DataManager.Instance.data.modeSelect[h] == true && DataManager.Instance.data.IPAddress[h] != "0")
                {
                    Invoke("NoKioskAllOnLaterPC", float.Parse(DataManager.Instance.data.Devel_Time));
                }
            }
        }
        catch
        {

            for (h = 4; h < DataManager.Instance.data.i; h++)
            {
                if (DataManager.Instance.data.modeSelect[h] == false && DataManager.Instance.data.IPAddress[h] != "0")
                {
                    _hostName = DataManager.Instance.data.IPAddress[h];
                    _port = int.Parse(DataManager.Instance.data.Port[h]);

                    if (_port == 4352)
                    {
                        PjlinkClient2 PJ = new PjlinkClient2(_hostName, _port, 2000);
                        PJ.PowerOn();

                        if (PJ.value == 1)
                        {
                            DataManager.Instance.data.ImageLight[h] = true;
                            DataManager.Instance.data.ZoneLight[h] = true;
                        }
                    }
                }

                else if (DataManager.Instance.data.modeSelect[h] == true && DataManager.Instance.data.IPAddress[h] != "0")
                {
                    Invoke("NoKioskAllOnLaterPC", float.Parse(DataManager.Instance.data.Devel_Time));
                }
            }
        }
    }

    public void NoKioskAllOnLaterPC()
    {
        for (h = 4; h < DataManager.Instance.data.i; h++)
        {
            if (DataManager.Instance.data.modeSelect[h] == true && DataManager.Instance.data.IPAddress[h] != "0")
            {
                UdpClient udpClient = new UdpClient();
                udpClient.EnableBroadcast = true;

                var dgram = new byte[1024];

                for (int i = 0; i < 6; i++)
                {
                    dgram[i] = 255;
                }

                byte[] address_bytes = new byte[6];

                for (int i = 0; i < 6; i++)
                {
                    address_bytes[i] = byte.Parse(DataManager.Instance.data.MacAddress[h].Substring(3 * i, 2), NumberStyles.HexNumber);
                }

                var macaddress_block = dgram.AsSpan(6, 16 * 6);

                for (int i = 0; i < 16; i++)
                {
                    address_bytes.CopyTo(macaddress_block.Slice(6 * i));
                }

                udpClient.Send(dgram, dgram.Length, new System.Net.IPEndPoint(IPAddress.Broadcast, int.Parse(DataManager.Instance.data.Port[h])));

                udpClient.Close();
            }
        }
    }

    void OnApplicationQuit()
    {
        CloseSocket();
    }

    void CloseSocket()
    {
        if (!socketReady) return;

        writer.Close();
        reader.Close();
        socket.Close();
        socketReady = false;
    }
}
