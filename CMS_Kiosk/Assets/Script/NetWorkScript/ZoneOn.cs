using PjlinkClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class ZoneOn : MonoBehaviour // 존on/off는 오브젝트 갯수를 특정할 수 없어 많이 난잡합니다.
{
    public Image[] ZoneImgChange;
    public Sprite GreenLight;

    int h;
    string _hostName;
    int _port;


    private void Update()
    {
        ZoneImgChangeMethod(); // 모두 참일때면 zone 상태등 녹색 

        for(int i=0; i<DataManager.Instance.data.i; i++)
        {
            if(DataManager.Instance.data.IPAddress[i] == "0")
            {
                DataManager.Instance.data.ZoneLight[i] = true; // ip가  0인것은 사용x이므로 zonelight는 true값으로 변경
            }
        }
    }

    void ZoneImgChangeMethod()
    {
        if (DataManager.Instance.data.ZoneLight[0] == true &&
            DataManager.Instance.data.ZoneLight[1] == true &&
            DataManager.Instance.data.ZoneLight[2] == true &&
            DataManager.Instance.data.ZoneLight[3] == true &&
            DataManager.Instance.data.ZoneLight[4] == true &&
            DataManager.Instance.data.ZoneLight[5] == true &&
            DataManager.Instance.data.ZoneLight[6] == true &&
            DataManager.Instance.data.ZoneLight[7] == true)
        {
            ZoneImgChange[0].sprite = GreenLight;
        }

        if (DataManager.Instance.data.ZoneLight[8] == true &&
            DataManager.Instance.data.ZoneLight[9] == true &&
            DataManager.Instance.data.ZoneLight[10] == true &&
            DataManager.Instance.data.ZoneLight[11] == true &&
            DataManager.Instance.data.ZoneLight[12] == true &&
            DataManager.Instance.data.ZoneLight[13] == true &&
            DataManager.Instance.data.ZoneLight[14] == true &&
            DataManager.Instance.data.ZoneLight[15] == true)
        {
            ZoneImgChange[1].sprite = GreenLight;
        }

        if (DataManager.Instance.data.ZoneLight[16] == true &&
            DataManager.Instance.data.ZoneLight[17] == true &&
            DataManager.Instance.data.ZoneLight[18] == true &&
            DataManager.Instance.data.ZoneLight[19] == true &&
            DataManager.Instance.data.ZoneLight[20] == true &&
            DataManager.Instance.data.ZoneLight[21] == true &&
            DataManager.Instance.data.ZoneLight[22] == true &&
            DataManager.Instance.data.ZoneLight[23] == true)
        {
            ZoneImgChange[2].sprite = GreenLight;
        }

        if (DataManager.Instance.data.ZoneLight[24] == true &&
            DataManager.Instance.data.ZoneLight[25] == true &&
            DataManager.Instance.data.ZoneLight[26] == true &&
            DataManager.Instance.data.ZoneLight[27] == true &&
            DataManager.Instance.data.ZoneLight[28] == true &&
            DataManager.Instance.data.ZoneLight[29] == true &&
            DataManager.Instance.data.ZoneLight[30] == true &&
            DataManager.Instance.data.ZoneLight[31] == true)
        {
            ZoneImgChange[3].sprite = GreenLight;
        }

        if (DataManager.Instance.data.ZoneLight[32] == true &&
            DataManager.Instance.data.ZoneLight[33] == true &&
            DataManager.Instance.data.ZoneLight[34] == true &&
            DataManager.Instance.data.ZoneLight[35] == true &&
            DataManager.Instance.data.ZoneLight[36] == true &&
            DataManager.Instance.data.ZoneLight[37] == true &&
            DataManager.Instance.data.ZoneLight[38] == true &&
            DataManager.Instance.data.ZoneLight[39] == true)
        {
            ZoneImgChange[4].sprite = GreenLight;
        }

        if (DataManager.Instance.data.ZoneLight[40] == true &&
            DataManager.Instance.data.ZoneLight[41] == true &&
            DataManager.Instance.data.ZoneLight[42] == true &&
            DataManager.Instance.data.ZoneLight[43] == true &&
            DataManager.Instance.data.ZoneLight[44] == true &&
            DataManager.Instance.data.ZoneLight[45] == true &&
            DataManager.Instance.data.ZoneLight[46] == true &&
            DataManager.Instance.data.ZoneLight[47] == true)
        {
            ZoneImgChange[5].sprite = GreenLight;
        }

        if (DataManager.Instance.data.ZoneLight[48] == true &&
            DataManager.Instance.data.ZoneLight[49] == true &&
            DataManager.Instance.data.ZoneLight[50] == true &&
            DataManager.Instance.data.ZoneLight[51] == true &&
            DataManager.Instance.data.ZoneLight[52] == true &&
            DataManager.Instance.data.ZoneLight[53] == true &&
            DataManager.Instance.data.ZoneLight[54] == true &&
            DataManager.Instance.data.ZoneLight[55] == true)
        {
            ZoneImgChange[6].sprite = GreenLight;
        }
    }
    public void Zone1OnBtnClik()
    {

        for (h = 4; h<= 7; h++) // 키오스크 0~3은 제외, 4부터 7까지 반복  프로젝터 킴 
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
                Invoke("LaterPCOnZone1", float.Parse(DataManager.Instance.data.Devel_Time)); // 사용자가 설정한 시간이 지나면 pc실행
            }
        }
    } // 밑에도 동일

    public void LaterPCOnZone1()
    {
        for (h = 4; h <= 7; h++)
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
    public void Zone2OnBtnClik()
    {
        for (h = 8; h <= 15; h++)
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
                Invoke("LaterPCOnZone2", float.Parse(DataManager.Instance.data.Devel_Time));
            }
        }
    }

    public void LaterPCOnZone2()
    {
        for (h = 8; h <= 15; h++)
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

    public void Zone3OnBtnClik()
    {
        for (h = 16; h <= 23; h++)
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
                Invoke("LaterPCOnZone3", float.Parse(DataManager.Instance.data.Devel_Time));
            }
        }
    }

    public void LaterPCOnZone3()
    {
        for (h = 16; h <= 23; h++)
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

    public void Zone4OnBtnClik()
    {
        for (h = 24; h <= 31; h++)
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
                Invoke("LaterPCOnZone4", float.Parse(DataManager.Instance.data.Devel_Time));
            }
        }
    }

    public void LaterPCOnZone4()
    {
        for (h = 24; h <= 31; h++)
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

    public void Zone5OnBtnClik()
    {
        for (h = 32; h <= 39; h++)
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
                Invoke("LaterPCOnZone5", float.Parse(DataManager.Instance.data.Devel_Time));
            }
        }
    }

    public void LaterPCOnZone5()
    {
        for (h = 32; h <= 39; h++)
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

    public void Zone6OnBtnClik()
    {
        for (h = 40; h <= 47; h++)
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
                Invoke("LaterPCOnZone6", float.Parse(DataManager.Instance.data.Devel_Time));
            }
        }
    }

    public void LaterPCOnZone6()
    {
        for (h = 40; h <= 47; h++)
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

    public void Zone7OnBtnClik()
    {
        for (h = 48; h <= 55; h++)
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
                Invoke("LaterPCOnZone7", float.Parse(DataManager.Instance.data.Devel_Time));
            }
        }
    }

    public void LaterPCOnZone7()
    {
        for (h = 48; h <= 55; h++)
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
}

