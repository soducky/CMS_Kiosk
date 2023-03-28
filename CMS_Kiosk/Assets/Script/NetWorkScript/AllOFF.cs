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
                StateLightImg.sprite = RedLight; // i�� ������ŭ �ݺ��ؼ� zoneLight�� �Ѱ��� false�̸� ����ǥ�õ� ���
            }
        }
    }

    public void AllOFFBtnClik() // all off ��ư�� �������� kiosk �� �����ϰ� all off 
    {
        GameObject.FindGameObjectWithTag("Server").GetComponent<Server>().NoKioskAllOff();
    }

}
