using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmTitleText : MonoBehaviour // StartScene에 해당
{
    public Text OpenTitle; // 개장시간 타이틀 글씨
    public Text CloseTitle; // 폐장시간 타이틀 글씨

    string openDropdown;
    string closeDropdown;   
    void Start()
    {
        if(DataManager.Instance.data.Open_DropDown == 0) // 드롭다운 값이 0이면 am , 그 이외는 pm  
        {
            openDropdown = "AM";
        }

        else
        {
            openDropdown = "PM";
        }

        if (DataManager.Instance.data.Close_DropDown == 0)
        {
            closeDropdown = "AM";
        }

        else
        {
            closeDropdown = "PM";
        }
        // 개장시간, 폐장시간 적어주기
        OpenTitle.text = "개장  " + DataManager.Instance.data.Open_Hour + " : " + DataManager.Instance.data.Open_Minute + " " + openDropdown;
        CloseTitle.text = "폐장  " + DataManager.Instance.data.Close_Hour + " : " + DataManager.Instance.data.Close_Minute + " " + closeDropdown;
    }
}
