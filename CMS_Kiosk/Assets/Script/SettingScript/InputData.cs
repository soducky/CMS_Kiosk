using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Cache;
using UnityEngine;
using UnityEngine.UI;

public class InputData : MonoBehaviour // 데이터 입력 클래스 
{

    public void WarmingUpLoad() // 불러오기 전 준비단계
    {
        List<GameObject> clonelist = GameObject.FindWithTag("AddButton").GetComponent<AddButton>().clonelist; // 클론리스트 값 가져오기

        for (int k = 0; k < DataManager.Instance.data.i; k++)
        {
            clonelist[k].transform.GetChild(2).GetComponent<InputField>().text = PlayerPrefs.GetString("Name" + k.ToString());
            clonelist[k].transform.GetChild(1).GetComponent<InputField>().text = PlayerPrefs.GetString("MacAddress" + k.ToString());
            clonelist[k].transform.GetChild(0).GetComponent<InputField>().text = PlayerPrefs.GetString("IPAddress" + k.ToString());
            clonelist[k].transform.GetChild(3).GetComponent<InputField>().text = PlayerPrefs.GetInt("Port" + k.ToString()).ToString();
            clonelist[k].transform.GetChild(7).GetComponent<InputField>().text = PlayerPrefs.GetString("ZoneName" + k.ToString());
        } // PlayerPrefs로 저장한 값들을 clone에 하나씩 대입해서 값 불러오기 
    }

    public void WarmingUpSave() // 저장하기전 준비단계
    {
        for (int k = 0; k < DataManager.Instance.data.i; k++)
        {
            PlayerPrefs.DeleteKey("Name" + k.ToString());
            PlayerPrefs.DeleteKey("MacAddress" + k.ToString());
            PlayerPrefs.DeleteKey("IPAddress" + k.ToString());
            PlayerPrefs.DeleteKey("Port" + k.ToString());
            PlayerPrefs.DeleteKey("ZoneName" + k.ToString());
        }  // 기존에 있던 데이터들 삭제

        List<GameObject> clonelist = GameObject.FindWithTag("BackGround").transform.GetChild(2).GetComponent<AddButton>().clonelist;

        for (int k = 0; k < DataManager.Instance.data.i; k++)
        {
 
            PlayerPrefs.SetString("Name" + k.ToString(), clonelist[k].transform.GetChild(2).GetComponent<InputField>().text);
            PlayerPrefs.SetString("MacAddress" + k.ToString(), clonelist[k].transform.GetChild(1).GetComponent<InputField>().text);
            PlayerPrefs.SetString("IPAddress" + k.ToString(), clonelist[k].transform.GetChild(0).GetComponent<InputField>().text);
            PlayerPrefs.SetInt("Port" + k.ToString(), Int32.Parse(clonelist[k].transform.GetChild(3).GetComponent<InputField>().text));
            PlayerPrefs.SetString("ZoneName" + k.ToString(), clonelist[k].transform.GetChild(7).GetComponent<InputField>().text);
        } // PlayperPrefs 값으로 저장하기, 오브젝트 이름에 숫자를 붙여서 접근하기 쉽게 만들었음
    }

    public void GameDataSaveKey()  // 데이터를 key 값으로 변환 
    {
        DataManager.Instance.data.Name.Clear();
        DataManager.Instance.data.MacAddress.Clear();
        DataManager.Instance.data.IPAddress.Clear();
        DataManager.Instance.data.Port.Clear();
        DataManager.Instance.data.ZoneName.Clear();
        // 기존에 있던 데이터 초기화
        for (int k = 0; k < DataManager.Instance.data.i; k++)
        {
            DataManager.Instance.data.Name.Add(PlayerPrefs.GetString("Name" + k.ToString()));
            DataManager.Instance.data.MacAddress.Add(PlayerPrefs.GetString("MacAddress" + k.ToString()));
            DataManager.Instance.data.IPAddress.Add(PlayerPrefs.GetString("IPAddress" + k.ToString()));
            DataManager.Instance.data.Port.Add(PlayerPrefs.GetInt("Port" + k.ToString()).ToString());
            DataManager.Instance.data.ZoneName.Add(PlayerPrefs.GetString("ZoneName" + k.ToString()));
        } // 데이터들을 PlayerPrefs 값으로 변환시켜서 저장하여 불러오기를 쉽게 하기 위해
    }

    public void Save() // 저장 메서드
    {
        WarmingUpSave();
        GameDataSaveKey();
        DataManager.Instance.SaveGameData();
    }

}
