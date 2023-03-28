using PjlinkClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneOff : MonoBehaviour
{
    public Image[] ZoneImgReCh;
    public Sprite RedLight;

    int h;
    string _hostName;
    int _port;

    private void Update()
    {
        ZoneImgReChangeMethod(); // 1개라도 zone구역에 false값이 있으면 false반환(상태등 빨강 교체)
    }

    void ZoneImgReChangeMethod()
    {
        if (DataManager.Instance.data.ZoneLight[0] == false ||
            DataManager.Instance.data.ZoneLight[1] == false ||
            DataManager.Instance.data.ZoneLight[2] == false ||
            DataManager.Instance.data.ZoneLight[3] == false ||
            DataManager.Instance.data.ZoneLight[4] == false ||
            DataManager.Instance.data.ZoneLight[5] == false ||
            DataManager.Instance.data.ZoneLight[6] == false ||
            DataManager.Instance.data.ZoneLight[7] == false)
        {
            ZoneImgReCh[0].sprite = RedLight;
        }

        if (DataManager.Instance.data.ZoneLight[8] == false ||
            DataManager.Instance.data.ZoneLight[9] == false ||
            DataManager.Instance.data.ZoneLight[10] == false ||
            DataManager.Instance.data.ZoneLight[11] == false ||
            DataManager.Instance.data.ZoneLight[12] == false ||
            DataManager.Instance.data.ZoneLight[13] == false ||
            DataManager.Instance.data.ZoneLight[14] == false ||
            DataManager.Instance.data.ZoneLight[15] == false)
        {
            ZoneImgReCh[1].sprite = RedLight;
        }

        if (DataManager.Instance.data.ZoneLight[16] == false ||
            DataManager.Instance.data.ZoneLight[17] == false ||
            DataManager.Instance.data.ZoneLight[18] == false ||
            DataManager.Instance.data.ZoneLight[19] == false ||
            DataManager.Instance.data.ZoneLight[20] == false ||
            DataManager.Instance.data.ZoneLight[21] == false ||
            DataManager.Instance.data.ZoneLight[22] == false ||
            DataManager.Instance.data.ZoneLight[23] == false)
        {
            ZoneImgReCh[2].sprite = RedLight;
        }

        if (DataManager.Instance.data.ZoneLight[24] == false ||
            DataManager.Instance.data.ZoneLight[25] == false ||
            DataManager.Instance.data.ZoneLight[26] == false ||
            DataManager.Instance.data.ZoneLight[27] == false ||
            DataManager.Instance.data.ZoneLight[28] == false ||
            DataManager.Instance.data.ZoneLight[29] == false ||
            DataManager.Instance.data.ZoneLight[30] == false ||
            DataManager.Instance.data.ZoneLight[31] == false)
        {
            ZoneImgReCh[3].sprite = RedLight;
        }

        if (DataManager.Instance.data.ZoneLight[32] == false ||
            DataManager.Instance.data.ZoneLight[33] == false ||
            DataManager.Instance.data.ZoneLight[34] == false ||
            DataManager.Instance.data.ZoneLight[35] == false ||
            DataManager.Instance.data.ZoneLight[36] == false ||
            DataManager.Instance.data.ZoneLight[37] == false ||
            DataManager.Instance.data.ZoneLight[38] == false ||
            DataManager.Instance.data.ZoneLight[39] == false)
        {
            ZoneImgReCh[4].sprite = RedLight;
        }

        if (DataManager.Instance.data.ZoneLight[40] == false ||
            DataManager.Instance.data.ZoneLight[41] == false ||
            DataManager.Instance.data.ZoneLight[42] == false ||
            DataManager.Instance.data.ZoneLight[43] == false ||
            DataManager.Instance.data.ZoneLight[44] == false ||
            DataManager.Instance.data.ZoneLight[45] == false ||
            DataManager.Instance.data.ZoneLight[46] == false ||
            DataManager.Instance.data.ZoneLight[47] == false)
        {
            ZoneImgReCh[5].sprite = RedLight;
        }

        if (DataManager.Instance.data.ZoneLight[48] == false ||
            DataManager.Instance.data.ZoneLight[49] == false ||
            DataManager.Instance.data.ZoneLight[50] == false ||
            DataManager.Instance.data.ZoneLight[51] == false ||
            DataManager.Instance.data.ZoneLight[52] == false ||
            DataManager.Instance.data.ZoneLight[53] == false ||
            DataManager.Instance.data.ZoneLight[54] == false ||
            DataManager.Instance.data.ZoneLight[55] == false)
        {
            ZoneImgReCh[6].sprite = RedLight;
        }
    }

    public void Zone1OffBtnClik()
    {
        for (h = 4; h <= 7; h++) // 키오스크 0~3은 제외, 4부터 7까지 반복,  PC끔 
        {
            if (DataManager.Instance.data.modeSelect[h] == true && DataManager.Instance.data.IPAddress[h] != "0")
            {
                string mes = DataManager.Instance.data.IPAddress[h];
                GameObject.FindGameObjectWithTag("Server").GetComponent<Server>().OffPC(mes);
            }

            else if (DataManager.Instance.data.modeSelect[h] == false && DataManager.Instance.data.IPAddress[h] != "0")
            {
                Invoke("LaterPJOffZone1", float.Parse(DataManager.Instance.data.Devel_Time)); // 키오스크 0~3은 제외, 4부터 7까지 반복, 프로젝터 끔
            }
        }
    }

    public void LaterPJOffZone1()
    {
        for (h = 4; h <= 7; h++)
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

    public void Zone2OffBtnClik()
    {
        for (h= 8; h <= 15; h++)
        {
            if (DataManager.Instance.data.modeSelect[h] == true && DataManager.Instance.data.IPAddress[h] != "0")
            {
                string mes = DataManager.Instance.data.IPAddress[h];
                GameObject.FindGameObjectWithTag("Server").GetComponent<Server>().OffPC(mes);
            }

            else if (DataManager.Instance.data.modeSelect[h] == false && DataManager.Instance.data.IPAddress[h] != "0")
            {
                Invoke("LaterPJOffZone2", float.Parse(DataManager.Instance.data.Devel_Time));
            }
        }
    }

    public void LaterPJOffZone2()
    {
        for (h=8; h <= 15; h++)
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
    public void Zone3OffBtnClik()
    {
        for (h = 16; h <= 23; h++)
        {
            if (DataManager.Instance.data.modeSelect[h] == true && DataManager.Instance.data.IPAddress[h] != "0")
            {
                string mes = DataManager.Instance.data.IPAddress[h];
                GameObject.FindGameObjectWithTag("Server").GetComponent<Server>().OffPC(mes);
            }

            else if (DataManager.Instance.data.modeSelect[h] == false && DataManager.Instance.data.IPAddress[h] != "0")
            {
                Invoke("LaterPJOffZone3", float.Parse(DataManager.Instance.data.Devel_Time));
            }
        }
    }

    public void LaterPJOffZone3()
    {
        for (h = 16; h <= 23; h++)
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

    public void Zone4OffBtnClik()
    {
        for (h = 24; h <= 31; h++)
        {
            if (DataManager.Instance.data.modeSelect[h] == true && DataManager.Instance.data.IPAddress[h] != "0")
            {
                string mes = DataManager.Instance.data.IPAddress[h];
                GameObject.FindGameObjectWithTag("Server").GetComponent<Server>().OffPC(mes);
            }

            else if (DataManager.Instance.data.modeSelect[h] == false && DataManager.Instance.data.IPAddress[h] != "0")
            {
                Invoke("LaterPJOffZone4", float.Parse(DataManager.Instance.data.Devel_Time));
            }
        }
    }

    public void LaterPJOffZone4()
    {
        for (h = 24; h <= 31; h++)
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

    public void Zone5OffBtnClik()
    {
        for (h = 32; h <= 39; h++)
        {
            if (DataManager.Instance.data.modeSelect[h] == true && DataManager.Instance.data.IPAddress[h] != "0")
            {
                string mes = DataManager.Instance.data.IPAddress[h];
                GameObject.FindGameObjectWithTag("Server").GetComponent<Server>().OffPC(mes);
            }

            else if (DataManager.Instance.data.modeSelect[h] == false && DataManager.Instance.data.IPAddress[h] != "0")
            {
                Invoke("LaterPJOffZone5", float.Parse(DataManager.Instance.data.Devel_Time));
            }
        }
    }

    public void LaterPJOffZone5()
    {
        for (h = 32; h <= 39; h++)
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

    public void Zone6OffBtnClik()
    {
        for (h = 40; h <= 47; h++)
        {
            if (DataManager.Instance.data.modeSelect[h] == true && DataManager.Instance.data.IPAddress[h] != "0")
            {
                string mes = DataManager.Instance.data.IPAddress[h];
                GameObject.FindGameObjectWithTag("Server").GetComponent<Server>().OffPC(mes);
            }

            else if (DataManager.Instance.data.modeSelect[h] == false && DataManager.Instance.data.IPAddress[h] != "0")
            {
                Invoke("LaterPJOffZone6", float.Parse(DataManager.Instance.data.Devel_Time));
            }
        }
    }

    public void LaterPJOffZone6()
    {
        for (h = 40; h <= 47; h++)
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

    public void Zone7OffBtnClik()
    {
        for (h = 48; h <= 55; h++)
        {
            if (DataManager.Instance.data.modeSelect[h] == true && DataManager.Instance.data.IPAddress[h] != "0")
            {
                string mes = DataManager.Instance.data.IPAddress[h];
                GameObject.FindGameObjectWithTag("Server").GetComponent<Server>().OffPC(mes);
            }

            else if (DataManager.Instance.data.modeSelect[h] == false && DataManager.Instance.data.IPAddress[h] != "0")
            {
                Invoke("LaterPJOffZone7", float.Parse(DataManager.Instance.data.Devel_Time));
            }
        }
    }

    public void LaterPJOffZone7()
    {
        for (h = 48; h <= 55; h++)
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
}
