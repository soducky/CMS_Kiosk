using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class DayToggle : MonoBehaviour
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
            DataManager.Instance.data.Alarm_weekday[tmp] = true;
        }


        else if (boolean == false)
        {
            DataManager.Instance.data.Alarm_weekday[tmp] = false;
        }
    }

    public void LoadToggleData()
    { // �� �̵��ϰ� �ٽ� ���ƿË� ����� �����Ϳ� ���� ������Ʈ

        if (Toggle_solo.isOn == false && DataManager.Instance.data.Alarm_weekday[tmp] == false)
        {
            return; // �ΰ� �� ���̰ų� false �϶��� ����
        }

        else if (Toggle_solo.isOn == false && DataManager.Instance.data.Alarm_weekday[tmp] == true)
        {
            Toggle_solo.isOn = true; // �����Ͱ��� ���� ��۰� ����
        }

        else if (Toggle_solo.isOn == true && DataManager.Instance.data.Alarm_weekday[tmp] == false)
        {
            Toggle_solo.isOn = false; // �����Ͱ��� ���� ��۰� ����
        }

        else if (Toggle_solo.isOn == true && DataManager.Instance.data.Alarm_weekday[tmp] == true)
        {
            return;
        }
    }

    void TitleTransfer()
    {
        slice = this.gameObject.name;
        String substring = slice.Substring(6); //������Ʈ �̸����� 6��°���� ������ �߶�
        tmp = int.Parse(substring);  // �� ���ڿ��� ���ڷ� ��ȯ 
    }
}


