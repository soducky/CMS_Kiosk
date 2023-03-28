using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;
using System.Net;
using UnityEngine;
using PjlinkClient;
using UnityEngine.UI;

public class OnButtonClik : MonoBehaviour // off버튼클릭과 반대
{
    string slice;
    int tmp;

    string _hostName;
    int _port;

    Button OnBtn;
    public Image RedLight;
    public Sprite GreenLight;

    private void Start()
    {
        TitleTransfer();
        ReadyStart();
        OnBtn = GetComponent<Button>();
        OnBtn.onClick.AddListener(OnBtnClik);
    }

    public void Update()
    {
        if (DataManager.Instance.data.ImageLight[tmp - 1] == true)
        {
            ImageChange();
        }
    }
    public void ReadyStart()
    {
        if (DataManager.Instance.data.ImageLight[tmp - 1] == true)
        {
            ImageChange();
        }
    }
    public void OnBtnClik()
    {
        OnBtnCapsule();
    }

    public void OnBtnCapsule()
    {

        if (DataManager.Instance.data.modeSelect[tmp - 1] == true) // PC 모드 
        {
            WakeOnLan(DataManager.Instance.data.MacAddress[tmp - 1]);
        }

        else if (DataManager.Instance.data.modeSelect[tmp - 1] == false) // PJ 모드 
        {
            _hostName = DataManager.Instance.data.IPAddress[tmp - 1];
            _port = int.Parse(DataManager.Instance.data.Port[tmp - 1]);

            if (_port == 4352)
            {
                PjlinkClient2 PJ = new PjlinkClient2(_hostName, _port, 2000);
                PJ.PowerOn();

                if (PJ.value == 1)
                {
                    DataManager.Instance.data.ImageLight[tmp - 1] = true;
                    DataManager.Instance.data.ZoneLight[tmp - 1] = true;
                }
            }

            else
            {
                return;
            }
        }
    }

    public void WakeOnLan(string macaddress)
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
            address_bytes[i] = byte.Parse(macaddress.Substring(3 * i, 2), NumberStyles.HexNumber);
        }

        var macaddress_block = dgram.AsSpan(6, 16 * 6);

        for (int i = 0; i < 16; i++)
        {
            address_bytes.CopyTo(macaddress_block.Slice(6 * i));
        }

        udpClient.Send(dgram, dgram.Length, new System.Net.IPEndPoint(IPAddress.Broadcast, int.Parse(DataManager.Instance.data.Port[tmp - 1])));

        udpClient.Close();
    }

    public void TitleTransfer()
    {
        slice = this.gameObject.name;
        String substring = slice.Substring(0, 2);
        tmp = int.Parse(substring);
    }

    public void ImageChange()
    {
        RedLight.sprite = GreenLight;
    }
}
