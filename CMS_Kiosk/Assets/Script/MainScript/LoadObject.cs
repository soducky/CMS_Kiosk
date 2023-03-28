using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadObject : MonoBehaviour
{
    public GameObject[] CMSList; // CMS 배열 


    private void Awake()
    {
        Application.runInBackground = true; // 백그라운드 실행
    }

    void Start()
    {
        DataManager.Instance.LoadGameData(); // 저장된 데이터 불러오기

        for (int i = 0; i < 56; i++)
        {
            if (DataManager.Instance.data.s[i] == false) // i의 갯수만큼 반복하여 false 상태인거는 다 보이지 않도록 설정
            {
                CMSList[i].gameObject.SetActive(false);
            }
        }
 
    }

    private void OnApplicationQuit() // 종료할때 루틴 change값 false(로딩화면 초기화), 기존 pc 값들 false(혼동 방지), 데이터저장
    {
        DataManager.Instance.data.ChangeSceneAuto = false;

        for (int k = 0; k < DataManager.Instance.data.i; k++) 
        {
            if (DataManager.Instance.data.modeSelect[k] == true)
            {
                DataManager.Instance.data.ImageLight[k] = false;
            } 
        }

        DataManager.Instance.SaveGameData();
    }
}
