using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTimer : MonoBehaviour
{
    public Text Timer_Text; // 텍스트
    float time_current; // 현재 설정한 타이모 초
    private bool isEnded; // 끝나는 값
    public GameObject timer;

    public GameObject DisabledMainBtn; // 타이머 작동시(통신 중일때) 다른 씬으로 이동불가하게끔 btn 비활성화하게 하는 변수
    public GameObject DisabledBackBtn;

    void Update()
    {
        if(isEnded) return; // 타이머가 끝나면 리턴

        Check_Timer();
    }

    public void Check_Timer()
    {
        if (0 < time_current) // 타이머 시간이 0보다 클때동안 작동
        {
            time_current -= Time.deltaTime; // 현재 타이머는 계속 줄어드므로
            Timer_Text.text = $"{time_current:N0}";
        }
        else if (!isEnded)
        {
            End_Timer();
        }
    }

    public void End_Timer() // 타이머 끝내는 루틴, 0으로 만들고 기존값들 리셋
    {
        time_current = 0;
        Timer_Text.text = $"{time_current:N0}";
        isEnded = true;

        timer.SetActive(false);
        DisabledBackBtn.SetActive(true);
        DisabledMainBtn.SetActive(true);
    }

    public void Reset_Timer() // 타이머 시작하기
    {

        timer.SetActive(true); 
        DisabledBackBtn.SetActive(false);
        DisabledMainBtn.SetActive(false);

        time_current = float.Parse(DataManager.Instance.data.Devel_Time);
        Timer_Text.text = $"{time_current:N0}";
        isEnded= false;
    }
}
