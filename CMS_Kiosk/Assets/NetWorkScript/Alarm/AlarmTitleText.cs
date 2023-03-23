using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmTitleText : MonoBehaviour
{
    public Text OpenTitle;
    public Text CloseTitle;

    string openDropdown;
    string closeDropdown;   
    void Start()
    {
        if(DataManager.Instance.data.Open_DropDown == 0)
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

        OpenTitle.text = "∞≥¿Â  " + DataManager.Instance.data.Open_Hour + " : " + DataManager.Instance.data.Open_Minute + " " + openDropdown;
        CloseTitle.text = "∆Û¿Â  " + DataManager.Instance.data.Close_Hour + " : " + DataManager.Instance.data.Close_Minute + " " + closeDropdown;
    }
}
