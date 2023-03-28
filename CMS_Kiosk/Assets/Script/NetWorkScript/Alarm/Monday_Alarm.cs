using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Monday_Alarm : MonoBehaviour // �����ϸ� �ּ� �޾Ƴ���
{                                                               // ����, ����, ���Ϻ��� ������ ���� ��, 2*7=14���� �˶� ������.
    private bool OpenAlarmSet; // ����˶� ����
    private bool CloseAlarmSet; //  ���� �˶� ����

    int toDay; // ����
    int goalDay; // ��ǥ ���� 

    TimeSpan ts;
    DateTime _alarmTime = DateTime.Today; // Open

    int Close_toDay;  // ����_�������
    int Close_goalDay; // ��ǥ ���� _ �������

    TimeSpan Close_ts;
    DateTime Close_alarmTime = DateTime.Today; //Close

    private IEnumerator coroutine; // �ڷ�ƾ
    private bool isCoroutine = false; // 60��¥�� �ڷ�ƾ update���� ��� 

    public GameObject AlarmMent; // �˶��� ������� ��Ʈ 

    void Start()
    {
        Mon_OpenSetAlarm(); // ���α׷������ϸ� ������ ������ �˶� �ڵ� ���� 
        Mon_CloseSetAlarm();
    }

    void Update()
    {                   // ������ �˶��� ����ڰ� true�� �����ϰ�, �˶��� ���õǾ���, ����ð��� �˶��ð����� ũ�� �˶� �︲
        if (DataManager.Instance.data.Alarm_weekday[1] == true && OpenAlarmSet && DateTime.Now > _alarmTime)
        {
            AlarmMent.SetActive(true); // �˶� ��Ʈ Ȱ��ȭ
            GameObject.FindGameObjectWithTag("AlarmTimer").GetComponent<AlarmTimer>().Reset_Timer(); // Ÿ�̸� ����(UI)

            GameObject.FindGameObjectWithTag("Server").GetComponent<Client>().NoKioskAllOn(); // ���� ��ȣ�� ����
            OpenAlarmSet = false; // �˶��� ��� ����Ǹ� �ȵǹǷ� �ѹ��� ���� 
        }

        if (DataManager.Instance.data.Alarm_weekday[1] == true && CloseAlarmSet && DateTime.Now > Close_alarmTime)
        {
            AlarmMent.SetActive(true);
            GameObject.FindGameObjectWithTag("AlarmTimer").GetComponent<AlarmTimer>().Reset_Timer();

            GameObject.FindGameObjectWithTag("Server").GetComponent<Server>().NoKioskAllOff();
            CloseAlarmSet = false; // ���� ����
        }

        if (!isCoroutine)
        {
            coroutine = countTime(3600f); // 3600�� , 60�и��� �˶� ������ �ڵ����� ���� (���α׷��� �����ִ� ��)
            StartCoroutine(coroutine);
        }
    }
    IEnumerator countTime(float delayTime) 
    {
        isCoroutine = true;
        yield return new WaitForSeconds(delayTime);

        Mon_OpenSetAlarm();  //  ������ ���� �˶� ����
        Mon_CloseSetAlarm(); // ������ ���� �˶� ����
        isCoroutine = false;
    }
    public void Mon_OpenSetAlarm()
    {
        if (DataManager.Instance.data.Alarm_weekday[1] == true)
        {
            _alarmTime = DateTime.Today; //���� �ð��� ����

            int hours;

            if (DataManager.Instance.data.Open_DropDown == 0)
            {
                hours = int.Parse(DataManager.Instance.data.Open_Hour); //������ ��� �״�� ����
            }
            else
            {
                hours = int.Parse(DataManager.Instance.data.Open_Hour) + 12; // ������ ��� 12�� ���ؼ� ����
            }

            ts = TimeSpan.Parse($"{hours}:{DataManager.Instance.data.Open_Minute}:{DataManager.Instance.data.Open_Second}");
            // ����ڰ� ������ �ð� �ʱ�ȭ
            toDay = Convert.ToInt32(_alarmTime.DayOfWeek); // ���� ����
            goalDay = Convert.ToInt32(DayOfWeek.Monday); // ��ǥ ����

            _alarmTime += ts; // ���� �ð�

            if (goalDay > toDay) // ��ǥ���Ϻ��� ��������� �۴ٸ� 
            {
                _alarmTime = _alarmTime.AddDays(goalDay - toDay);
                // ��ǥ��-������ ���� ���� x���� �����ָ� ������Ͽ��� x��ŭ ���� ��ǥ������ ��
            }

            else if (goalDay == toDay) // ������ϰ� ��ǥ������ ���� ��� (��, ����)
            {
                if(DateTime.Now > _alarmTime) // ���� �ð��� ���Ͽ� �̹� �˶� �ð��� ���� ���
                {
                    _alarmTime = _alarmTime.AddDays(7); // �������� ������

                }
            }

            else if (goalDay < toDay) // ������ �������ε� �Ͽ��� �˶��� �����ϰ� ������(���� ���� ���� �˶�)
            {
                _alarmTime = _alarmTime.AddDays(goalDay + 7 - toDay); // 7���� �����ְ� ��������� ���ָ� ������ ��
            }

            OpenAlarmSet = true; // �˶� ���� �Ϸ�� true��
        }
    }

    public void Mon_CloseSetAlarm() // ���� ����
    {
        if (DataManager.Instance.data.Alarm_weekday[1] == true)
        {
            Close_alarmTime = DateTime.Today;

            int hours;

            if (DataManager.Instance.data.Close_DropDown == 0)
            {
                hours = int.Parse(DataManager.Instance.data.Close_Hour);
            }
            else
            {
                hours = int.Parse(DataManager.Instance.data.Close_Hour) + 12;
            }

            Close_ts = TimeSpan.Parse($"{hours}:{DataManager.Instance.data.Close_Minute}:{DataManager.Instance.data.Close_Second}");

            Close_toDay = Convert.ToInt32(Close_alarmTime.DayOfWeek);
            Close_goalDay = Convert.ToInt32(DayOfWeek.Monday);

            Close_alarmTime += Close_ts;

            if (Close_goalDay > Close_toDay)
            {
                Close_alarmTime = Close_alarmTime.AddDays(Close_goalDay - Close_toDay);
            }

            else if (Close_goalDay == Close_toDay)
            {
                if (DateTime.Now > Close_alarmTime)
                {
                    Close_alarmTime = Close_alarmTime.AddDays(7);
                }
            }

            else if (Close_goalDay < Close_toDay)
            {
                Close_alarmTime = Close_alarmTime.AddDays(Close_goalDay + 7 - Close_toDay);
            }

            CloseAlarmSet = true;
        }
    }
}
