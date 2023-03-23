using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Cache;
using UnityEngine;
using UnityEngine.UI;

public class InputData : MonoBehaviour // ������ �Է� Ŭ���� 
{

    public void WarmingUpLoad() // �ҷ����� �� �غ�ܰ�
    {
        List<GameObject> clonelist = GameObject.FindWithTag("AddButton").GetComponent<AddButton>().clonelist; // Ŭ�и���Ʈ �� ��������

        for (int k = 0; k < DataManager.Instance.data.i; k++)
        {
            clonelist[k].transform.GetChild(2).GetComponent<InputField>().text = PlayerPrefs.GetString("Name" + k.ToString());
            clonelist[k].transform.GetChild(1).GetComponent<InputField>().text = PlayerPrefs.GetString("MacAddress" + k.ToString());
            clonelist[k].transform.GetChild(0).GetComponent<InputField>().text = PlayerPrefs.GetString("IPAddress" + k.ToString());
            clonelist[k].transform.GetChild(3).GetComponent<InputField>().text = PlayerPrefs.GetInt("Port" + k.ToString()).ToString();
            clonelist[k].transform.GetChild(7).GetComponent<InputField>().text = PlayerPrefs.GetString("ZoneName" + k.ToString());
        } // PlayerPrefs�� ������ ������ clone�� �ϳ��� �����ؼ� �� �ҷ����� 
    }

    public void WarmingUpSave() // �����ϱ��� �غ�ܰ�
    {
        for (int k = 0; k < DataManager.Instance.data.i; k++)
        {
            PlayerPrefs.DeleteKey("Name" + k.ToString());
            PlayerPrefs.DeleteKey("MacAddress" + k.ToString());
            PlayerPrefs.DeleteKey("IPAddress" + k.ToString());
            PlayerPrefs.DeleteKey("Port" + k.ToString());
            PlayerPrefs.DeleteKey("ZoneName" + k.ToString());
        }  // ������ �ִ� �����͵� ����

        List<GameObject> clonelist = GameObject.FindWithTag("BackGround").transform.GetChild(2).GetComponent<AddButton>().clonelist;

        for (int k = 0; k < DataManager.Instance.data.i; k++)
        {
 
            PlayerPrefs.SetString("Name" + k.ToString(), clonelist[k].transform.GetChild(2).GetComponent<InputField>().text);
            PlayerPrefs.SetString("MacAddress" + k.ToString(), clonelist[k].transform.GetChild(1).GetComponent<InputField>().text);
            PlayerPrefs.SetString("IPAddress" + k.ToString(), clonelist[k].transform.GetChild(0).GetComponent<InputField>().text);
            PlayerPrefs.SetInt("Port" + k.ToString(), Int32.Parse(clonelist[k].transform.GetChild(3).GetComponent<InputField>().text));
            PlayerPrefs.SetString("ZoneName" + k.ToString(), clonelist[k].transform.GetChild(7).GetComponent<InputField>().text);
        } // PlayperPrefs ������ �����ϱ�, ������Ʈ �̸��� ���ڸ� �ٿ��� �����ϱ� ���� �������
    }

    public void GameDataSaveKey()  // �����͸� key ������ ��ȯ 
    {
        DataManager.Instance.data.Name.Clear();
        DataManager.Instance.data.MacAddress.Clear();
        DataManager.Instance.data.IPAddress.Clear();
        DataManager.Instance.data.Port.Clear();
        DataManager.Instance.data.ZoneName.Clear();
        // ������ �ִ� ������ �ʱ�ȭ
        for (int k = 0; k < DataManager.Instance.data.i; k++)
        {
            DataManager.Instance.data.Name.Add(PlayerPrefs.GetString("Name" + k.ToString()));
            DataManager.Instance.data.MacAddress.Add(PlayerPrefs.GetString("MacAddress" + k.ToString()));
            DataManager.Instance.data.IPAddress.Add(PlayerPrefs.GetString("IPAddress" + k.ToString()));
            DataManager.Instance.data.Port.Add(PlayerPrefs.GetInt("Port" + k.ToString()).ToString());
            DataManager.Instance.data.ZoneName.Add(PlayerPrefs.GetString("ZoneName" + k.ToString()));
        } // �����͵��� PlayerPrefs ������ ��ȯ���Ѽ� �����Ͽ� �ҷ����⸦ ���� �ϱ� ����
    }

    public void Save() // ���� �޼���
    {
        WarmingUpSave();
        GameDataSaveKey();
        DataManager.Instance.SaveGameData();
    }

}
