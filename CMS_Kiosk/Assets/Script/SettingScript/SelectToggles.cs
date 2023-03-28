using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class SelectToggles : MonoBehaviour
{
    Toggle Toggle_solo; // �� ��۵�

    string slice; // ���ڿ� ����
    int tmp; // ������ ����  

    private void Start()
    {
        TitleTransfer();  // �̸����� ���� ������ 
        Toggle_solo = GetComponent<Toggle>();
        Togglestart(); // �̺�Ʈ �߰� start�� 
        LoadToggleData(); // �� �̵��ϰ� �ٽ� ���ƿË� ����� �����Ϳ� ���� ������Ʈ
    }

    private void Update()
    {
        LoadToggleData(); // ��� updata�� ���鼭 ��� �ٲ��ֱ� 
    }
   // ��� �������� ��� 
    public void Togglestart()
    {
        Toggle_solo.onValueChanged.AddListener(OnToggleValueChanged); // �̺�Ʈ �߰� start�� 
    }

    public void OnToggleValueChanged(bool boolean)  // ��Ŭ Ŭ�� �̺�Ʈ
    {

        if (boolean == true) // ���̸� ������ �� true�� ����
        {
            DataManager.Instance.data.s[tmp - 1] = true;
        }


        else if (boolean == false)
        {
            DataManager.Instance.data.s[tmp - 1] = false;
        }
    }

    public void LoadToggleData()
    { // �� �̵��ϰ� �ٽ� ���ƿË� ����� �����Ϳ� ���� ������Ʈ

        if (Toggle_solo.isOn == false && DataManager.Instance.data.s[tmp - 1] == false)
        {
            return; // �ΰ� �� ���̰ų� false �϶��� ����
        }

        else if (Toggle_solo.isOn == false && DataManager.Instance.data.s[tmp - 1] == true)
        {
            Toggle_solo.isOn = true; // �����Ͱ��� ���� ��۰� ����
        } 

        else if (Toggle_solo.isOn == true && DataManager.Instance.data.s[tmp - 1] == false)
        {
            Toggle_solo.isOn = false; // �����Ͱ��� ���� ��۰� ����
        }

        else if (Toggle_solo.isOn == true && DataManager.Instance.data.s[tmp - 1] == true)
        {
            return;
        }
    }

    void TitleTransfer()
    {
        slice = this.gameObject.name;
        String substring = slice.Substring(6); //������Ʈ �̸����� 10��°���� ������ �߶�
        tmp = int.Parse(substring);  // �� ���ڿ��� ���ڷ� ��ȯ 
    }
}

