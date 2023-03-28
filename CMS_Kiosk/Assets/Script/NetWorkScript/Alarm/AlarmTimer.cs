using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmTimer : MonoBehaviour // ���� ��� ����� Ȱ��ȭ�Ǵ� Ÿ�̸�
{
    public Text Timer_Text;
    float time_current;
    private bool isEnded;
    public GameObject timer;

    public GameObject DisabledMainBtn; // Ȱ��ȭ�Ǹ� �� �̵� �����ʰ� ��ư ��Ȱ��ȭ 
    public GameObject DisabledBackBtn;

    void Update()
    {
        if (isEnded) return; // �˶��� ������ ����

        Check_Timer();
    }

    public void Check_Timer()
    {
        if (0 < time_current)
        {
            time_current -= Time.deltaTime; // Ÿ�̸� �ð��� �ʸ��� ��� �پ���
            Timer_Text.text = $"������ ���� ��.. Ÿ�̸� : {time_current:N0}";
        }
        else if (!isEnded)
        {
            End_Timer();
        }
    }

    public void End_Timer() // Ÿ�̸� �� 0���� ���ϰ�, ���� ���õ� ����
    {
        time_current = 0;
        Timer_Text.text = $"������ ���� ��.. Ÿ�̸� : {time_current:N0}";
        isEnded = true;

        timer.SetActive(false);
        DisabledBackBtn.SetActive(true);
        DisabledMainBtn.SetActive(true);
    }

    public void Reset_Timer() // Ÿ�̸Ӱ� ���۵Ǹ� ������ �� ������Ʈ ����, Ÿ�̸� �ð��� ����ڰ� ������ �ð����� ���� 
    {
        DisabledBackBtn.SetActive(false);
        DisabledMainBtn.SetActive(false);

        time_current = float.Parse(DataManager.Instance.data.Devel_Time);
        Timer_Text.text = $"������ ���� ��.. Ÿ�̸� : {time_current:N0}";
        isEnded = false;
    }
}
