using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeveloperModeEnter : MonoBehaviour // �����ڸ�� Ŭ���� - ��Ʈ��ũ ��ũ��Ʈ ���� - DeveloperModeEnter ������Ʈ
{
    //������ ��� ������ �����ϱ� ���� 
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
        LoadPlayerPrefs(); // ����� ������ �ҷ����� 
    }

    void LoadPlayerPrefs()  // PlayerPrefs�� ����� �����͵� �ҷ����� 
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

    public void ReadySave() // ���̺� �Ҷ� �غ���� 
    {
        PlayerPrefs.DeleteKey("Devel_IP"); // ���� ������ ���� �� ���� 
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

        PlayerPrefs.SetString("Devel_IP", Devel_IP.text); // ��ǲ�ʵ��� ���� PlayerPrefs Ű�� ���� 
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
        DataManager.Instance.data.Devel_IP = PlayerPrefs.GetString("Devel_IP"); // �̱��� �ȿ� GetString�� �־���
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

    public void EnterDeveloperBtn() // ������ ��� ���� ��ư Ŭ��
    {

          DeveloperMode.SetActive(true); // ������ ��� â true

    }

    public void BackBtn() // �ڷ� ���� ��ư -> ���� �� �����ڸ�� â ����
    {
        SaveBtn(); // ����
        DeveloperMode.SetActive(false);  // ������ ��� â false
    }

    public void SaveBtn()
    {
        ReadySave();
        DBSave();
        DataManager.Instance.SaveGameData();
    }
}
