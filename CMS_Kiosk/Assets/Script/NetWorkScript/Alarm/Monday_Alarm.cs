using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Monday_Alarm : MonoBehaviour // 월요일만 주석 달아놓음
{                                                               // 개장, 폐장, 요일별로 나눠서 진행 즉, 2*7=14개의 알람 셋팅함.
    private bool OpenAlarmSet; // 개장알람 셋팅
    private bool CloseAlarmSet; //  폐장 알람 셋팅

    int toDay; // 오늘
    int goalDay; // 목표 요일 

    TimeSpan ts;
    DateTime _alarmTime = DateTime.Today; // Open

    int Close_toDay;  // 오늘_폐장버젼
    int Close_goalDay; // 목표 요일 _ 폐장버젼

    TimeSpan Close_ts;
    DateTime Close_alarmTime = DateTime.Today; //Close

    private IEnumerator coroutine; // 코루틴
    private bool isCoroutine = false; // 60분짜리 코루틴 update문에 사용 

    public GameObject AlarmMent; // 알람이 울렸을때 멘트 

    void Start()
    {
        Mon_OpenSetAlarm(); // 프로그램시작하면 기존에 설정한 알람 자동 셋팅 
        Mon_CloseSetAlarm();
    }

    void Update()
    {                   // 월요일 알람이 사용자가 true을 선택하고, 알람이 셋팅되었고, 현재시간이 알람시간보다 크면 알람 울림
        if (DataManager.Instance.data.Alarm_weekday[1] == true && OpenAlarmSet && DateTime.Now > _alarmTime)
        {
            AlarmMent.SetActive(true); // 알람 멘트 활성화
            GameObject.FindGameObjectWithTag("AlarmTimer").GetComponent<AlarmTimer>().Reset_Timer(); // 타이머 시작(UI)

            GameObject.FindGameObjectWithTag("Server").GetComponent<Client>().NoKioskAllOn(); // 켜짐 신호를 보냄
            OpenAlarmSet = false; // 알람이 계속 실행되면 안되므로 한번만 실행 
        }

        if (DataManager.Instance.data.Alarm_weekday[1] == true && CloseAlarmSet && DateTime.Now > Close_alarmTime)
        {
            AlarmMent.SetActive(true);
            GameObject.FindGameObjectWithTag("AlarmTimer").GetComponent<AlarmTimer>().Reset_Timer();

            GameObject.FindGameObjectWithTag("Server").GetComponent<Server>().NoKioskAllOff();
            CloseAlarmSet = false; // 위와 동일
        }

        if (!isCoroutine)
        {
            coroutine = countTime(3600f); // 3600초 , 60분마다 알람 셋팅을 자동으로 해줌 (프로그램이 켜져있는 한)
            StartCoroutine(coroutine);
        }
    }
    IEnumerator countTime(float delayTime) 
    {
        isCoroutine = true;
        yield return new WaitForSeconds(delayTime);

        Mon_OpenSetAlarm();  //  월요일 개장 알람 셋팅
        Mon_CloseSetAlarm(); // 월요일 폐장 알람 셋팅
        isCoroutine = false;
    }
    public void Mon_OpenSetAlarm()
    {
        if (DataManager.Instance.data.Alarm_weekday[1] == true)
        {
            _alarmTime = DateTime.Today; //현재 시간을 대입

            int hours;

            if (DataManager.Instance.data.Open_DropDown == 0)
            {
                hours = int.Parse(DataManager.Instance.data.Open_Hour); //오전일 경우 그대로 대입
            }
            else
            {
                hours = int.Parse(DataManager.Instance.data.Open_Hour) + 12; // 오후인 경우 12를 더해서 대입
            }

            ts = TimeSpan.Parse($"{hours}:{DataManager.Instance.data.Open_Minute}:{DataManager.Instance.data.Open_Second}");
            // 사용자가 설정한 시간 초기화
            toDay = Convert.ToInt32(_alarmTime.DayOfWeek); // 오늘 요일
            goalDay = Convert.ToInt32(DayOfWeek.Monday); // 목표 요일

            _alarmTime += ts; // 현재 시간

            if (goalDay > toDay) // 목표요일보다 현재요일이 작다면 
            {
                _alarmTime = _alarmTime.AddDays(goalDay - toDay);
                // 목표일-현재일 에서 나온 x값을 더해주면 현재요일에서 x만큼 지난 목표요일이 됨
            }

            else if (goalDay == toDay) // 현재요일과 목표요일이 같은 경우 (즉, 오늘)
            {
                if(DateTime.Now > _alarmTime) // 현재 시간과 비교하여 이미 알람 시간이 지난 경우
                {
                    _alarmTime = _alarmTime.AddDays(7); // 일주일을 더해줌

                }
            }

            else if (goalDay < toDay) // 지금이 월요일인데 일요일 알람을 설정하고 싶으면(지난 이전 요일 알람)
            {
                _alarmTime = _alarmTime.AddDays(goalDay + 7 - toDay); // 7일을 더해주고 현재요일을 빼주면 오늘이 됨
            }

            OpenAlarmSet = true; // 알람 셋팅 완료시 true값
        }
    }

    public void Mon_CloseSetAlarm() // 위와 동일
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
