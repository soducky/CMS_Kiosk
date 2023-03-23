using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStart : MonoBehaviour
{
   
    public GameObject LoadingImg;
    void Start()
    {
        Application.runInBackground = true; // ��׶��� ����

        DataManager.Instance.LoadGameData(); // ����� ������ �ҷ�����

        LoadingImg.SetActive(false);

    }

    private void Update()
    {
        if(DataManager.Instance.data.ChangeSceneAuto == false)
        {
            LoadingImg.SetActive(true);
            Invoke("AutoMainButton", 3f);
        }
    }

    public void AutoMainButton()
    {
        DataManager.Instance.data.ChangeSceneAuto = true;
        DataManager.Instance.SaveGameData();
        LoadingImg.SetActive(false);
        SceneManager.LoadScene("MainScene"); // ���� ������ �̵�
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
    }
}
