using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneHiden : MonoBehaviour
{
    public GameObject[] ZoneHidenImg; // 각각의 존 화면 
    public GameObject[] ZoneMoveButton; // 각각의 존 움직이는 버튼
    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.Instance.data.ZoneName[0] == "") // zone name에 아무것도 들어있지 않으면, 버튼과 화면 비활성화
        {
            ZoneHidenImg[0].gameObject.SetActive(true);
            ZoneMoveButton[0].gameObject.SetActive(false);
        }

        if (DataManager.Instance.data.ZoneName[8] == "")
        {
            ZoneHidenImg[1].gameObject.SetActive(true);
            ZoneMoveButton[1].gameObject.SetActive(false);
        }

        if (DataManager.Instance.data.ZoneName[16] == "")
        {
            ZoneHidenImg[2].gameObject.SetActive(true);
            ZoneMoveButton[2].gameObject.SetActive(false);
        }

        if (DataManager.Instance.data.ZoneName[24] == "")
        {
            ZoneHidenImg[3].gameObject.SetActive(true);
            ZoneMoveButton[3].gameObject.SetActive(false);
        }

        if (DataManager.Instance.data.ZoneName[32] == "")
        {
            ZoneHidenImg[4].gameObject.SetActive(true);
            ZoneMoveButton[4].gameObject.SetActive(false);
        }

        if (DataManager.Instance.data.ZoneName[40] == "")
        {
            ZoneHidenImg[5].gameObject.SetActive(true);
            ZoneMoveButton[5].gameObject.SetActive(false);
        }

        if (DataManager.Instance.data.ZoneName[48] == "")
        {
            ZoneHidenImg[6].gameObject.SetActive(true);
            ZoneMoveButton[6].gameObject.SetActive(false);
        }
    }

}
