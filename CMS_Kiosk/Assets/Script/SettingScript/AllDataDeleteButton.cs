using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AllDataDeleteButton : MonoBehaviour
{
    public GameObject AllClearMent; // ��ü���� �ȳ���Ʈ 
    public GameObject DeleteButton; // ������ư ��� ��Ȱ��ȭ ��Ű�� ����
    public GameObject AllDeleteButton; // ��ü������ư ��� ��Ȱ��ȭ ��Ű�� ���� 

    public void AllDataDeleteBtn()
    {

       AllClearMent.SetActive(true);  // ��ü���� �ȳ���Ʈ Ȱ��ȭ

        DeleteButton.SetActive(false);  // ������ư ��� ��Ȱ��ȭ 
        AllDeleteButton.SetActive(false);  // ��ü������ư ��� ��Ȱ��ȭ 

    }

    public void DeleteOkayBtn()
    {
        AllClearMent.SetActive(false);  // ��ü���� �ȳ���Ʈ ��Ȱ��ȭ

        DeleteButton.SetActive(true);  // ������ư Ȱ��ȭ 
        AllDeleteButton.SetActive(true);  // ��ü������ư Ȱ��ȭ 

        DataManager.Instance.data.i = 1; // i�� 1�� �ٲ��ָ� DB�� ����� ������Ʈ�� �ϳ��� ��.

        GameObject.Find("InputFieldPrefab").GetComponent<InputData>().Save();  // �����ϰ�
        SceneManager.LoadScene("SettingScene"); // ���� �ٽ� �ε��ϸ� ��ü ���� �Ǿ� ����.
    }

    public void ReTurnBackBtn()
    {
        AllClearMent.SetActive(false);   // ��ü���� �ȳ���Ʈ ��Ȱ��ȭ

        DeleteButton.SetActive(true);  // ������ư Ȱ��ȭ 
        AllDeleteButton.SetActive(true);  // ��ü������ư Ȱ��ȭ 
    }
}
