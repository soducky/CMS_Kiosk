
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

    List<ServerClient> clients; // 클라이언트 목록
    List<ServerClient> disconnectList; // 종료된 클라이언트 목록

    TcpListener server;
    bool serverStarted;

    int h;
    string _hostName;
    int _port;

    private void Awake()
    {
        var obj = FindObjectsOfType<Server>(); // (씬이동시 파괴x)

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

    public void ServerCreate() // 서배생성
    {
        clients = new List<ServerClient>();
        disconnectList = new List<ServerClient>();

        try
        {
            int port = int.Parse(DataManager.Instance.data.Devel_Port);
            server = new TcpListener(IPAddress.Any, port);
            server.Start();

            StartListening();
            serverStarted = true; // 서버 듣기 시작

        }
        catch (Exception e)
        {
            Debug.Log("소켓에러" + e);
        }
    }

    void Update()
    {
        if (!serverStarted) return;

        foreach (ServerClient c in clients)
        {
            // 클라이언트가 여전히 연결되어 있는지 확인, 없으면 disconnectList에 추가 
            if (!IsConnected(c.tcp))
            {
                c.tcp.Close();
                disconnectList.Add(c);
                continue;
            }
            // 연결되어있으면 업데이트문을 돌면서 클라이언트로부터 메세지를 받는다. 
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
           // Broadcast($"{disconnectList[i].clientName}"+"0", clients); // 강제종료까지 포함하게 하려면 기능추가

            clients.Remove(disconnectList[i]); // 연결 끊어진거 리스트에서 지우기
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
                    return !(c.Client.Receive(new byte[1], SocketFlags.Peek) == 0); // 클라이언트랑 연결되면 서버기준 1바이트 데이터 받음

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
        server.BeginAcceptTcpClient(AcceptTcpClient, server);  //비동기로 계속 듣기 
    }

    void AcceptTcpClient(IAsyncResult ar)
    {
        TcpListener listener = (TcpListener)ar.AsyncState;
        clients.Add(new ServerClient(listener.EndAcceptTcpClient(ar)));
        StartListening();


        Broadcast("%NAME", new List<ServerClient>() { clients[clients.Count - 1] });
        // 비동기로 계속 들으면서 클라이언트에게 받은 메시지를 브로드캐스트를 통해서 연결된 모두에게 보냄
    }


    void OnIncomingData(ServerClient c, string data)
    {
        if (data.Contains("&NAME"))
        {
            c.clientName = data.Split('|')[1];

            Broadcast(c.clientName+1, clients); // 연결된거를 클라이언트들에게 보내줌 +1로 프로토콜 구분

            return;             
        }

        Broadcast(data, clients); // 이름이 아니면 data 그대로 내보냄
    }

    public void OffPC(string Mes) // PC종료하는 신호 
    {
        Broadcast(Mes, clients);
        Broadcast(Mes, clients);
    }

    public void AllOff()
    {
        for (h = 0; h < DataManager.Instance.data.i; h++) // alloff이므로 i만큼 반복
        {
            if (DataManager.Instance.data.modeSelect[h] == true && DataManager.Instance.data.IPAddress[h] != "0") //pc끄기
            {
                string mes = DataManager.Instance.data.IPAddress[h];
                OffPC(mes);
            }

            else if (DataManager.Instance.data.modeSelect[h] == false && DataManager.Instance.data.IPAddress[h] != "0") //프로젝터 끄기
            {
                Invoke("AllOffLaterPJ", float.Parse(DataManager.Instance.data.Devel_Time)); // 사용자가 설정한 시간이 지난 후 프로젝터 끄기 실행
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

    public void NoKioskAllOff() //  ** 키오스크로 인해 4부터 반복, 0~3은 고정으로 둠** 
    {
        try
        {
            GameObject.FindGameObjectWithTag("Server").GetComponent<AduinoOFF>().ArduinoOffCommand(); // 아두이노가 연결되었을때 try문 실행

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
        }

        catch  // 아두이노가 연결되지 않았을때 try문 실행
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
        }
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

    void Broadcast(string data, List<ServerClient> cl) // 브로드캐스트 메서드
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