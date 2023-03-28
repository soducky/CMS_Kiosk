using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStart : MonoBehaviour
{
   
    public GameObject LoadingImg; // 로딩할때 보여지는 화면
    void Start()
    {
        Application.runInBackground = true; // 백그라운드 설정

        DataManager.Instance.LoadGameData(); // 저장된 데이터 불러오기

        LoadingImg.SetActive(false); // 로딩창 비활성화 

    }

    private void Update()
    {
        if(DataManager.Instance.data.ChangeSceneAuto == false) // Change씬 값이 false일때만 로딩창 띄워줌 (프로그램 종료할때 change값이 비활성화됨)
        {
            LoadingImg.SetActive(true);
            Invoke("AutoMainButton", 3f);
        }
    }

    public void AutoMainButton()
    {
        DataManager.Instance.data.ChangeSceneAuto = true; // 로딩창이 끝났으면 true 바꿔주고, 종료전까지는 true값 유지
        DataManager.Instance.SaveGameData(); // 데이터 저장
        LoadingImg.SetActive(false);
        SceneManager.LoadScene("MainScene"); // 메인 씬으로 이동
    }

    private void OnApplicationQuit()
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
    } // change값 비활성화, 기존 pc 값들 false로 변경(혼동방지), 데이터 저장 
}
