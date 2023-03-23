using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CMS_Name : MonoBehaviour
{
    public Text[] cms_text_name; // 각 오브젝트 이름들 (1번 이름, 2번 이름 등)

    void Start() // 01_CMS_Text 에서 초기화
    {
        for (int i = 0; i < DataManager.Instance.data.i; i++) // i의 갯수만큼 이름 초기화시킴 
        {
            cms_text_name[i].text = DataManager.Instance.data.Name[i]; // i번째 의 이름 리스트를 가져와서 text에 대입
        }
    }
}
