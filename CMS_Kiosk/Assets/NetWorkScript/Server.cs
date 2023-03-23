
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using PjlinkClient;

public class Server : MonoBehaviour
{

    List<ServerClient> clients;
    List<ServerClient> disconnectList;

    TcpListener server;
    bool serverStarted;

    int h;
    string _hostName;
    int _port;

    private void Awake()
    {
        var obj = FindObjectsOfType<Server>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(obj[0]);
        }
        else
        {
            Destroy(obj[1]);
        }
    }
    private void Start()
    {
        ServerCreate();
    }

    public void ServerCreate()
    {
        clients = new List<ServerClient>();
        disconnectList = new List<ServerClient>();

        try
        {
            int port = int.Parse(DataManager.Instance.data.Devel_Port);
            server = new TcpListener(IPAddress.Any, port);
            server.Start();

            StartListening();
            serverStarted = true;

        }
        catch (Exception e)
        {
            Debug.Log("���Ͽ���" + e);
        }
    }

    void Update()
    {
        if (!serverStarted) return;

        foreach (ServerClient c in clients)
        {
            // Ŭ���̾�Ʈ�� ������ ����Ǿ� �ִ��� Ȯ��, ������ disconnectList�� �߰� 
            if (!IsConnected(c.tcp))
            {
                c.tcp.Close();
                disconnectList.Add(c);
                continue;
            }
            // ����Ǿ������� ������Ʈ���� ���鼭 Ŭ���̾�Ʈ�κ��� �޼����� �޴´�. 
            else
            {
                NetworkStream s = c.tcp.GetStream();
                if (s.DataAvailable)
                {
                    string data = new StreamReader(s, true).ReadLine();
                    if (data != null)
                        OnIncomingData(c, data);
                }
            }
        }

        for (int i = 0; i < disconnectList.Count - 1; i++)
        {
           // Broadcast($"{disconnectList[i].clientName}"+"0", clients); // ����������� �����ϰ� �Ϸ��� ����߰�

            clients.Remove(disconnectList[i]); // ���� �������� ����Ʈ���� �����
            disconnectList.RemoveAt(i);
        }
    }



    bool IsConnected(TcpClient c)
    {
        try
        {
            if (c != null && c.Client != null && c.Client.Connected)
            {
                if (c.Client.Poll(0, SelectMode.SelectRead))
                    return !(c.Client.Receive(new byte[1], SocketFlags.Peek) == 0); // Ŭ���̾�Ʈ�� ����Ǹ� �������� 1����Ʈ ������ ����

                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
    }

    void StartListening()
    {
        server.BeginAcceptTcpClient(AcceptTcpClient, server);  //�񵿱�� ��� ��� 
    }

    void AcceptTcpClient(IAsyncResult ar)
    {
        TcpListener listener = (TcpListener)ar.AsyncState;
        clients.Add(new ServerClient(listener.EndAcceptTcpClient(ar)));
        StartListening();


        Broadcast("%NAME", new List<ServerClient>() { clients[clients.Count - 1] });
        // �񵿱�� ��� �����鼭 Ŭ���̾�Ʈ���� ���� �޽����� ��ε�ĳ��Ʈ�� ���ؼ� ����� ��ο��� ����
    }


    void OnIncomingData(ServerClient c, string data)
    {
        if (data.Contains("&NAME"))
        {
            c.clientName = data.Split('|')[1];

            Broadcast(c.clientName+1, clients); // ����ȰŸ� Ŭ���̾�Ʈ�鿡�� ������ +1�� �������� ����

            return;             
        }

        Broadcast(data, clients); // �̸��� �ƴϸ� data �״�� ������
    }

    public void OffPC(string Mes)
    {
        Broadcast(Mes, clients);
    }

    public void AllOff()
    {
        for (h = 0; h < DataManager.Instance.data.i; h++)
        {
            if (DataManager.Instance.data.modeSelect[h] == true && DataManager.Instance.data.IPAddress[h] != "0")
            {
                string mes = DataManager.Instance.data.IPAddress[h];
                OffPC(mes);
            }

            else if (DataManager.Instance.data.modeSelect[h] == false && DataManager.Instance.data.IPAddress[h] != "0")
            {
                Invoke("AllOffLaterPJ", float.Parse(DataManager.Instance.data.Devel_Time));
            }
        }
    }

    public void AllOffLaterPJ()
    {
        for (h = 0; h < DataManager.Instance.data.i; h++)
        {
            _hostName = DataManager.Instance.data.IPAddress[h];
            _port = int.Parse(DataManager.Instance.data.Port[h]);

            if (_port == 4352)
            {
                PjlinkClient2 PJ = new PjlinkClient2(_hostName, _port, 2000);
                PJ.PowerOff();

                if (PJ.value == 2)
                {
                    DataManager.Instance.data.ImageLight[h] = false;
                    DataManager.Instance.data.ZoneLight[h] = false;
                }
            }
        }
    }

    public void NoKioskAllOff()
    {
        for (h = 4; h < DataManager.Instance.data.i; h++)
        {
            if (DataManager.Instance.data.modeSelect[h] == true && DataManager.Instance.data.IPAddress[h] != "0")
            {
                string mes = DataManager.Instance.data.IPAddress[h];
                OffPC(mes);
            }

            else if (DataManager.Instance.data.modeSelect[h] == false && DataManager.Instance.data.IPAddress[h] != "0")
            {
                Invoke("NoKioskAllOffLaterPJ", float.Parse(DataManager.Instance.data.Devel_Time));
            }
        }

        GameObject.FindGameObjectWithTag("Server").GetComponent<AduinoOFF>().ArduinoOffCommand();
    }

    public void NoKioskAllOffLaterPJ()
    {
        for (h = 4; h < DataManager.Instance.data.i; h++)
        {
            _hostName = DataManager.Instance.data.IPAddress[h];
            _port = int.Parse(DataManager.Instance.data.Port[h]);

            if (_port == 4352)
            {
                PjlinkClient2 PJ = new PjlinkClient2(_hostName, _port, 2000);
                PJ.PowerOff();

                if (PJ.value == 2)
                {
                    DataManager.Instance.data.ImageLight[h] = false;
                    DataManager.Instance.data.ZoneLight[h] = false;
                }
            }
        }
    }

    void Broadcast(string data, List<ServerClient> cl)
    {
        foreach (var c in cl)
        {
            try
            {
                StreamWriter writer = new StreamWriter(c.tcp.GetStream());
                writer.WriteLine(data);
                writer.Flush();
            }
            catch (Exception e)
            {
                print(e);
            }
        }
    }
}



public class ServerClient
{
    public TcpClient tcp;
    public string clientName;

    public ServerClient(TcpClient clientSocket)
    {
        clientName = "Guest";
        tcp = clientSocket;
    }
}