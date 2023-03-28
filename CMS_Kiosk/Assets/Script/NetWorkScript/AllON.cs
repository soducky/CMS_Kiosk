using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;
using System.Net;
using UnityEngine;
using System.Net.Mail;
using PjlinkClient;
using UnityEngine.UI;

public class AllON : MonoBehaviour
{

    public Image StateLightImg;
    public Sprite GreenLight;

    void Update()
    {
        if (DataManager.Instance.data.ZoneLight[0] == true &&
       DataManager.Instance.data.ZoneLight[1] == true &&
       DataManager.Instance.data.ZoneLight[2] == true &&
       DataManager.Instance.data.ZoneLight[3] == true &&
       DataManager.Instance.data.ZoneLight[4] == true &&
       DataManager.Instance.data.ZoneLight[5] == true &&
       DataManager.Instance.data.ZoneLight[6] == true &&
       DataManager.Instance.data.ZoneLight[7] == true &&
       DataManager.Instance.data.ZoneLight[8] == true &&
       DataManager.Instance.data.ZoneLight[9] == true &&
       DataManager.Instance.data.ZoneLight[10] == true &&
       DataManager.Instance.data.ZoneLight[11] == true &&
       DataManager.Instance.data.ZoneLight[12] == true &&
       DataManager.Instance.data.ZoneLight[13] == true &&
       DataManager.Instance.data.ZoneLight[14] == true &&
       DataManager.Instance.data.ZoneLight[15] == true &&
       DataManager.Instance.data.ZoneLight[16] == true &&
       DataManager.Instance.data.ZoneLight[17] == true &&
       DataManager.Instance.data.ZoneLight[18] == true &&
       DataManager.Instance.data.ZoneLight[19] == true &&
       DataManager.Instance.data.ZoneLight[20] == true &&
       DataManager.Instance.data.ZoneLight[21] == true &&
       DataManager.Instance.data.ZoneLight[22] == true &&
       DataManager.Instance.data.ZoneLight[23] == true &&
       DataManager.Instance.data.ZoneLight[24] == true &&
       DataManager.Instance.data.ZoneLight[25] == true &&
       DataManager.Instance.data.ZoneLight[26] == true &&
       DataManager.Instance.data.ZoneLight[27] == true &&
       DataManager.Instance.data.ZoneLight[28] == true &&
       DataManager.Instance.data.ZoneLight[29] == true &&
       DataManager.Instance.data.ZoneLight[30] == true &&
       DataManager.Instance.data.ZoneLight[31] == true &&
       DataManager.Instance.data.ZoneLight[32] == true &&
       DataManager.Instance.data.ZoneLight[33] == true &&
       DataManager.Instance.data.ZoneLight[34] == true &&
       DataManager.Instance.data.ZoneLight[35] == true &&
       DataManager.Instance.data.ZoneLight[36] == true &&
       DataManager.Instance.data.ZoneLight[37] == true &&
       DataManager.Instance.data.ZoneLight[38] == true &&
       DataManager.Instance.data.ZoneLight[39] == true &&
       DataManager.Instance.data.ZoneLight[40] == true &&
       DataManager.Instance.data.ZoneLight[41] == true &&
       DataManager.Instance.data.ZoneLight[42] == true &&
       DataManager.Instance.data.ZoneLight[43] == true &&
       DataManager.Instance.data.ZoneLight[44] == true &&
       DataManager.Instance.data.ZoneLight[45] == true &&
       DataManager.Instance.data.ZoneLight[46] == true &&
       DataManager.Instance.data.ZoneLight[47] == true &&
       DataManager.Instance.data.ZoneLight[48] == true &&
       DataManager.Instance.data.ZoneLight[49] == true &&
       DataManager.Instance.data.ZoneLight[50] == true &&
       DataManager.Instance.data.ZoneLight[51] == true &&
       DataManager.Instance.data.ZoneLight[52] == true &&
       DataManager.Instance.data.ZoneLight[53] == true &&
       DataManager.Instance.data.ZoneLight[54] == true &&
       DataManager.Instance.data.ZoneLight[55] == true)
        {
            StateLightImg.sprite = GreenLight;
        } // zonelight가 모두 참일 경우에만 상태표시등을 녹색으로 바꿔줌
    }

    public void AllOnBtnClik() // on버튼 클릭시 키오스크를 제외한 모든 장비들 ON
    {
        GameObject.FindGameObjectWithTag("Server").GetComponent<Client>().NoKioskAllOn();
    }
}
