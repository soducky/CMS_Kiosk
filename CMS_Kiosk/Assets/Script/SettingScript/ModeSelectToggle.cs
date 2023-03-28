using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ModeSelectToggle : MonoBehaviour // ModeToggle ������Ʈ�� ����
{
    Toggle ModeSelect; // ��� ���

    string slice; // ������Ʈ �̸����� ���ڸ� ���ͼ� i������ �ֱ� ����
    int tmp;


    void Start()
    {
        TitleTransfer(); // �̸����� ���� ������ 
        ModeSelect = GetComponent<Toggle>();
        ModeSelect.onValueChanged.AddListener(OnToggleValueChanged); // �߰�
        ChangeUIToggle(); // �� �̵��ϰ� �ٽ� ���ƿË� ����� �����Ϳ� ���� ������Ʈ
    }

    private void Update()
    {
        ChangeUIToggle();
    }

    public void OnToggleValueChanged(bool boolean) // ��Ŭ Ŭ�� �̺�Ʈ
    {
        if (boolean == true) // ��
        {
            this.gameObject.transform.GetChild(1).GetComponent<Text>().text = "PC Mode"; // PC Mode ��� ����

            DataManager.Instance.data.modeSelect[tmp - 1] = true; // Data ���� true ������ ����
        }

        else if (boolean == false)
        {
            this.gameObject.transform.GetChild(1).GetComponent<Text>().text = "PJ Mode"; // PJ Mode ��� ����

            DataManager.Instance.data.modeSelect[tmp - 1] = false; // Data ���� false ������ ����
        }
    }

    public void ChangeUIToggle() // �� �̵��ϰ� �ٽ� ���ƿË� ����� �����Ϳ� ���� ������Ʈ
    {
        if (ModeSelect.isOn == false && DataManager.Instance.data.modeSelect[tmp-1] == false)
        {
            return; // �ΰ� �� ���̰ų� false �϶��� ����
        }

        else if (ModeSelect.isOn == false && DataManager.Instance.data.modeSelect[tmp - 1] == true)
        {

            ModeSelect.isOn = true; // �����Ͱ��� ���� ��۰� ����
        
        }

        else if (ModeSelect.isOn == true && DataManager.Instance.data.modeSelect[tmp - 1] == false)
        {
 
            ModeSelect.isOn = false; // �����Ͱ��� ���� ��۰� ����

        }

        else if (ModeSelect.isOn == true && DataManager.Instance.data.modeSelect[tmp - 1] == true)
        {
            return;
        }
    }

     void TitleTransfer()
    {
        slice = this.gameObject.name; 
        String substring = slice.Substring(10); //������Ʈ �̸����� 10��°���� ������ �߶�
        tmp = int.Parse(substring); // �� ���ڿ��� ���ڷ� ��ȯ 
    }

}
