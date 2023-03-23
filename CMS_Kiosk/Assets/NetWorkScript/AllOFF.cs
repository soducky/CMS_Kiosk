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
                StateLightImg.sprite = RedLight;
            }
        }
    }

    public void AllOFFBtnClik()
    {
        GameObject.FindGameObjectWithTag("Server").GetComponent<Server>().NoKioskAllOff();
    }

}
