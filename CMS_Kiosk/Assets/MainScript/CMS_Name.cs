using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CMS_Name : MonoBehaviour
{
    public Text[] cms_text_name; // �� ������Ʈ �̸��� (1�� �̸�, 2�� �̸� ��)

    void Start() // 01_CMS_Text ���� �ʱ�ȭ
    {
        for (int i = 0; i < DataManager.Instance.data.i; i++) // i�� ������ŭ �̸� �ʱ�ȭ��Ŵ 
        {
            cms_text_name[i].text = DataManager.Instance.data.Name[i]; // i��° �� �̸� ����Ʈ�� �����ͼ� text�� ����
        }
    }
}
