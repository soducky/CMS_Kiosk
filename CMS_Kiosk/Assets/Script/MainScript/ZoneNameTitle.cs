using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ZoneNameTitle : MonoBehaviour
{
    public Text[] ZoneName_Title; // Zone Name 데이터 불러오기, Zone1Name에 들어감
    void Start()
    {
        if (49 <= DataManager.Instance.data.i)
        {
            ZoneName_Title[0].text = DataManager.Instance.data.ZoneName[0];
            ZoneName_Title[1].text = DataManager.Instance.data.ZoneName[8];
            ZoneName_Title[2].text = DataManager.Instance.data.ZoneName[16];
            ZoneName_Title[3].text = DataManager.Instance.data.ZoneName[24];
            ZoneName_Title[4].text = DataManager.Instance.data.ZoneName[32];
            ZoneName_Title[5].text = DataManager.Instance.data.ZoneName[40];
            ZoneName_Title[6].text = DataManager.Instance.data.ZoneName[48];
        }
        else if(41<= DataManager.Instance.data.i && DataManager.Instance.data.i < 49)
        {
            ZoneName_Title[0].text = DataManager.Instance.data.ZoneName[0];
            ZoneName_Title[1].text = DataManager.Instance.data.ZoneName[8];
            ZoneName_Title[2].text = DataManager.Instance.data.ZoneName[16];
            ZoneName_Title[3].text = DataManager.Instance.data.ZoneName[24];
            ZoneName_Title[4].text = DataManager.Instance.data.ZoneName[32];
            ZoneName_Title[5].text = DataManager.Instance.data.ZoneName[40];
        }

        else if (33 <= DataManager.Instance.data.i && DataManager.Instance.data.i < 41)
        {
            ZoneName_Title[0].text = DataManager.Instance.data.ZoneName[0];
            ZoneName_Title[1].text = DataManager.Instance.data.ZoneName[8];
            ZoneName_Title[2].text = DataManager.Instance.data.ZoneName[16];
            ZoneName_Title[3].text = DataManager.Instance.data.ZoneName[24];
            ZoneName_Title[4].text = DataManager.Instance.data.ZoneName[32];
        }

        else if (25 <= DataManager.Instance.data.i && DataManager.Instance.data.i < 33)
        {
            ZoneName_Title[0].text = DataManager.Instance.data.ZoneName[0];
            ZoneName_Title[1].text = DataManager.Instance.data.ZoneName[8];
            ZoneName_Title[2].text = DataManager.Instance.data.ZoneName[16];
            ZoneName_Title[3].text = DataManager.Instance.data.ZoneName[24];
        }

        else if (17 <= DataManager.Instance.data.i && DataManager.Instance.data.i < 25)
        {
            ZoneName_Title[0].text = DataManager.Instance.data.ZoneName[0];
            ZoneName_Title[1].text = DataManager.Instance.data.ZoneName[8];
            ZoneName_Title[2].text = DataManager.Instance.data.ZoneName[16];
        }

        else if (9 <= DataManager.Instance.data.i && DataManager.Instance.data.i < 17)
        {
            ZoneName_Title[0].text = DataManager.Instance.data.ZoneName[0];
            ZoneName_Title[1].text = DataManager.Instance.data.ZoneName[8];
        }


        else if (1 <= DataManager.Instance.data.i && DataManager.Instance.data.i < 9)
        {
            ZoneName_Title[0].text = DataManager.Instance.data.ZoneName[0];
        }

    }
}
