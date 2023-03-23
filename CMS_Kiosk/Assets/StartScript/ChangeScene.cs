using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    private void Awake()
    {
        Application.runInBackground = true; // 백그라운드에서 동작하는 기능, PC에서만 가능 
    }

    public void SettingBtnClik()
    {
        DataManager.Instance.SaveGameData();
        SceneManager.LoadScene("SettingScene"); // 설정 씬으로 이동
    }

    public void BackButton()
    {
        DataManager.Instance.SaveGameData();
        SceneManager.LoadScene("MainScene"); // 메인 씬으로 이동
    }

    public void BackAndSaveButton() // 설정페이지에서 메인페이지로 이동시 데이터 저장을 위해 
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

        GameObject.Find("InputFieldPrefab").GetComponent<InputData>().Save();  // 저장 후 메인 씬으로 이동
        SceneManager.LoadScene("MainScene");
    }

    public void BackStartButton()
    {
        DataManager.Instance.SaveGameData();
        SceneManager.LoadScene("StartScene"); // 스타트 씬으로 이동
    }

}
