using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStart : MonoBehaviour
{
   
    public GameObject LoadingImg; // �ε��Ҷ� �������� ȭ��
    void Start()
    {
        Application.runInBackground = true; // ��׶��� ����

        DataManager.Instance.LoadGameData(); // ����� ������ �ҷ�����

        LoadingImg.SetActive(false); // �ε�â ��Ȱ��ȭ 

    }

    private void Update()
    {
        if(DataManager.Instance.data.ChangeSceneAuto == false) // Change�� ���� false�϶��� �ε�â ����� (���α׷� �����Ҷ� change���� ��Ȱ��ȭ��)
        {
            LoadingImg.SetActive(true);
            Invoke("AutoMainButton", 3f);
        }
    }

    public void AutoMainButton()
    {
        DataManager.Instance.data.ChangeSceneAuto = true; // �ε�â�� �������� true �ٲ��ְ�, ������������ true�� ����
        DataManager.Instance.SaveGameData(); // ������ ����
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
    } // change�� ��Ȱ��ȭ, ���� pc ���� false�� ����(ȥ������), ������ ���� 
}
