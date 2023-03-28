using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeveloperModeEnter : MonoBehaviour // 관리자모드 클래스 - 네트워크 스크립트 폴더 - DeveloperModeEnter 오브젝트
{
    //개발자 모드 정보들 저장하기 위해 
    public GameObject DeveloperMode;
    public InputField Devel_IP;
    public InputField Devel_Port;
    public InputField Devel_Name;
    public InputField Devel_Time;

    public InputField Open_Hour;
    public InputField Open_Minute;
    public Dropdown Open_dropdown;

    public InputField Close_Hour;
    public InputField Close_Minute;
    public Dropdown Close_dropdown;

    public InputField Devel_COM;

    private void Start()
    {
        LoadPlayerPrefs(); // 저장된 데이터 불러오기 
    }

    void LoadPlayerPrefs()  // PlayerPrefs에 저장된 데이터들 불러오기 
    {
        Devel_IP.text = PlayerPrefs.GetString("Devel_IP");
        Devel_Port.text = PlayerPrefs.GetInt("Devel_Port").ToString();
        Devel_Name.text = PlayerPrefs.GetString("Devel_Name");
        Devel_Time.text = PlayerPrefs.GetFloat("Devel_Time").ToString();

        Open_Hour.text = PlayerPrefs.GetString("Open_Hour").ToString();
        Open_Minute.text = PlayerPrefs.GetString("Open_Minute").ToString();
        Open_dropdown.value = PlayerPrefs.GetInt("Open_dropdown");
        Close_Hour.text = PlayerPrefs.GetString("Close_Hour").ToString();
        Close_Minute.text = PlayerPrefs.GetString("Close_Minute").ToString();
        Close_dropdown.value = PlayerPrefs.GetInt("Close_dropdown");

        Devel_COM.text = PlayerPrefs.GetString("Devel_COM").ToString();
    }

    public void ReadySave() // 세이브 할때 준비과정 
    {
        PlayerPrefs.DeleteKey("Devel_IP"); // 기존 데이터 삭제 후 저장 
        PlayerPrefs.DeleteKey("Devel_Port");
        PlayerPrefs.DeleteKey("Devel_Name");
        PlayerPrefs.DeleteKey("Devel_Time");

        PlayerPrefs.DeleteKey("Open_Hour");
        PlayerPrefs.DeleteKey("Open_Minute");
        PlayerPrefs.DeleteKey("Open_dropdown");
        PlayerPrefs.DeleteKey("Close_Hour");
        PlayerPrefs.DeleteKey("Close_Minute");
        PlayerPrefs.DeleteKey("Close_dropdown");

        PlayerPrefs.DeleteKey("Devel_COM");

        PlayerPrefs.SetString("Devel_IP", Devel_IP.text); // 인풋필드의 값을 PlayerPrefs 키에 저장 
        PlayerPrefs.SetInt("Devel_Port", int.Parse(Devel_Port.text));
        PlayerPrefs.SetString("Devel_Name", Devel_Name.text);
        PlayerPrefs.SetFloat("Devel_Time", float.Parse(Devel_Time.text));

        PlayerPrefs.SetString("Open_Hour", Open_Hour.text);
        PlayerPrefs.SetString("Open_Minute", Open_Minute.text);
        PlayerPrefs.SetInt("Open_dropdown", Open_dropdown.value);
        PlayerPrefs.SetString("Close_Hour", Close_Hour.text);
        PlayerPrefs.SetString("Close_Minute", Close_Minute.text);
        PlayerPrefs.SetInt("Close_dropdown", Close_dropdown.value);

        PlayerPrefs.SetString("Devel_COM", Devel_COM.text);
    }

    public void DBSave()
    {
        DataManager.Instance.data.Devel_IP = PlayerPrefs.GetString("Devel_IP"); // 싱글톤 안에 GetString을 넣어줌
        DataManager.Instance.data.Devel_Port = PlayerPrefs.GetInt("Devel_Port").ToString();
        DataManager.Instance.data.Devel_Name = PlayerPrefs.GetString("Devel_Name");
        DataManager.Instance.data.Devel_Time = PlayerPrefs.GetFloat("Devel_Time").ToString();

        DataManager.Instance.data.Open_Hour = PlayerPrefs.GetString("Open_Hour").ToString();
        DataManager.Instance.data.Open_Minute = PlayerPrefs.GetString("Open_Minute").ToString();
        DataManager.Instance.data.Open_DropDown = PlayerPrefs.GetInt("Open_dropdown");
        DataManager.Instance.data.Close_Hour = PlayerPrefs.GetString("Close_Hour").ToString();
        DataManager.Instance.data.Close_Minute = PlayerPrefs.GetString("Close_Minute").ToString();
        DataManager.Instance.data.Close_DropDown = PlayerPrefs.GetInt("Close_dropdown");

        DataManager.Instance.data.Devel_COM = PlayerPrefs.GetString("Devel_COM").ToString();
    }

    public void EnterDeveloperBtn() // 관리자 모드 들어가는 버튼 클릭
    {

          DeveloperMode.SetActive(true); // 관리자 모드 창 true

    }

    public void BackBtn() // 뒤로 가기 버튼 -> 저장 후 관리자모드 창 끄기
    {
        SaveBtn(); // 저장
        DeveloperMode.SetActive(false);  // 관리자 모드 창 false
    }

    public void SaveBtn()
    {
        ReadySave();
        DBSave();
        DataManager.Instance.SaveGameData();
    }
}
