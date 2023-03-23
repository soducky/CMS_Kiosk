using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    private void Awake()
    {
        Application.runInBackground = true; // ��׶��忡�� �����ϴ� ���, PC������ ���� 
    }

    public void SettingBtnClik()
    {
        DataManager.Instance.SaveGameData();
        SceneManager.LoadScene("SettingScene"); // ���� ������ �̵�
    }

    public void BackButton()
    {
        DataManager.Instance.SaveGameData();
        SceneManager.LoadScene("MainScene"); // ���� ������ �̵�
    }

    public void BackAndSaveButton() // �������������� ������������ �̵��� ������ ������ ���� 
    {

        List<GameObject> clonelist = GameObject.FindWithTag("AddButton").GetComponent<AddButton>().clonelist;

        for (int c = 0; c < clonelist.Count; c++)
        {
            if (clonelist[c].transform.GetChild(0).GetComponent<InputField>().text == "" ||
                clonelist[c].transform.GetChild(3).GetComponent<InputField>().text == "")
            {
                clonelist[c].transform.GetChild(0).GetComponent<InputField>().text = "0";
                clonelist[c].transform.GetChild(3).GetComponent<InputField>().text = "0";
            }
        }

        GameObject.Find("InputFieldPrefab").GetComponent<InputData>().Save();  // ���� �� ���� ������ �̵�
        SceneManager.LoadScene("MainScene");
    }

    public void BackStartButton()
    {
        DataManager.Instance.SaveGameData();
        SceneManager.LoadScene("StartScene"); // ��ŸƮ ������ �̵�
    }

}
