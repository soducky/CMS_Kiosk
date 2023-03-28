using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmTimer : MonoBehaviour // 예약 모드 실행시 활성화되는 타이머
{
    public Text Timer_Text;
    float time_current;
    private bool isEnded;
    public GameObject timer;

    public GameObject DisabledMainBtn; // 활성화되면 씬 이동 하지않게 버튼 비활성화 
    public GameObject DisabledBackBtn;

    void Update()
    {
        if (isEnded) return; // 알람이 끝나면 리턴

        Check_Timer();
    }

    public void Check_Timer()
    {
        if (0 < time_current)
        {
            time_current -= Time.deltaTime; // 타이머 시간은 초마다 계속 줄어들게
            Timer_Text.text = $"예약모드 실행 중.. 타이머 : {time_current:N0}";
        }
        else if (!isEnded)
        {
            End_Timer();
        }
    }

    public void End_Timer() // 타이머 값 0으로 변하고, 기존 세팅들 복구
    {
        time_current = 0;
        Timer_Text.text = $"예약모드 실행 중.. 타이머 : {time_current:N0}";
        isEnded = true;

        timer.SetActive(false);
        DisabledBackBtn.SetActive(true);
        DisabledMainBtn.SetActive(true);
    }

    public void Reset_Timer() // 타이머가 시작되면 오류가 될 오브젝트 차단, 타이머 시간은 사용자가 정의한 시간으로 대입 
    {
        DisabledBackBtn.SetActive(false);
        DisabledMainBtn.SetActive(false);

        time_current = float.Parse(DataManager.Instance.data.Devel_Time);
        Timer_Text.text = $"예약모드 실행 중.. 타이머 : {time_current:N0}";
        isEnded = false;
    }
}
