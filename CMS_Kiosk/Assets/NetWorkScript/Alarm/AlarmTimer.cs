using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmTimer : MonoBehaviour
{
    public Text Timer_Text;
    float time_current;
    private bool isEnded;
    public GameObject timer;

    public GameObject DisabledMainBtn;
    public GameObject DisabledBackBtn;

    void Update()
    {
        if (isEnded) return;

        Check_Timer();
    }

    public void Check_Timer()
    {
        if (0 < time_current)
        {
            time_current -= Time.deltaTime;
            Timer_Text.text = $"예약모드 실행 중.. 타이머 : {time_current:N0}";
        }
        else if (!isEnded)
        {
            End_Timer();
        }
    }

    public void End_Timer()
    {
        time_current = 0;
        Timer_Text.text = $"예약모드 실행 중.. 타이머 : {time_current:N0}";
        isEnded = true;

        timer.SetActive(false);
        DisabledBackBtn.SetActive(true);
        DisabledMainBtn.SetActive(true);
    }

    public void Reset_Timer()
    {
        DisabledBackBtn.SetActive(false);
        DisabledMainBtn.SetActive(false);

        time_current = float.Parse(DataManager.Instance.data.Devel_Time);
        Timer_Text.text = $"예약모드 실행 중.. 타이머 : {time_current:N0}";
        isEnded = false;
    }
}
