using PjlinkClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllOFF : MonoBehaviour
{
    public Image StateLightImg;
    public Sprite RedLight;


    private void Update()
    {
        for (int k = 0; k < DataManager.Instance.data.i; k++)
        {
            if (DataManager.Instance.data.ZoneLight[k] == false)
            {
                StateLightImg.sprite = RedLight; // i의 갯수만큼 반복해서 zoneLight가 한개라도 false이면 빨간표시등 출력
            }
        }
    }

    public void AllOFFBtnClik() // all off 버튼을 눌렀을때 kiosk 만 제외하고 all off 
    {
        GameObject.FindGameObjectWithTag("Server").GetComponent<Server>().NoKioskAllOff();
    }

}
