using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmTitleText : MonoBehaviour // StartScene�� �ش�
{
    public Text OpenTitle; // ����ð� Ÿ��Ʋ �۾�
    public Text CloseTitle; // ����ð� Ÿ��Ʋ �۾�

    string openDropdown;
    string closeDropdown;   
    void Start()
    {
        if(DataManager.Instance.data.Open_DropDown == 0) // ��Ӵٿ� ���� 0�̸� am , �� �ܴ̿� pm  
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
        // ����ð�, ����ð� �����ֱ�
        OpenTitle.text = "����  " + DataManager.Instance.data.Open_Hour + " : " + DataManager.Instance.data.Open_Minute + " " + openDropdown;
        CloseTitle.text = "����  " + DataManager.Instance.data.Close_Hour + " : " + DataManager.Instance.data.Close_Minute + " " + closeDropdown;
    }
}
