using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AllDataDeleteButton : MonoBehaviour
{
    public GameObject AllClearMent; // 전체삭제 안내멘트 
    public GameObject DeleteButton; // 삭제버튼 잠시 비활성화 시키기 위해
    public GameObject AllDeleteButton; // 전체삭제버튼 잠시 비활성화 시키기 위해 

    public void AllDataDeleteBtn()
    {

       AllClearMent.SetActive(true);  // 전체삭제 안내멘트 활성화

        DeleteButton.SetActive(false);  // 삭제버튼 잠시 비활성화 
        AllDeleteButton.SetActive(false);  // 전체삭제버튼 잠시 비활성화 

    }

    public void DeleteOkayBtn()
    {
        AllClearMent.SetActive(false);  // 전체삭제 안내멘트 비활성화

        DeleteButton.SetActive(true);  // 삭제버튼 활성화 
        AllDeleteButton.SetActive(true);  // 전체삭제버튼 활성화 

        DataManager.Instance.data.i = 1; // i값 1로 바꿔주면 DB에 저장된 오브젝트가 하나가 됨.

        GameObject.Find("InputFieldPrefab").GetComponent<InputData>().Save();  // 저장하고
        SceneManager.LoadScene("SettingScene"); // 씬을 다시 로드하면 전체 삭제 되어 있음.
    }

    public void ReTurnBackBtn()
    {
        AllClearMent.SetActive(false);   // 전체삭제 안내멘트 비활성화

        DeleteButton.SetActive(true);  // 삭제버튼 활성화 
        AllDeleteButton.SetActive(true);  // 전체삭제버튼 활성화 
    }
}
