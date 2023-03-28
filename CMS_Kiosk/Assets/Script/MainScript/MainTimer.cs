using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTimer : MonoBehaviour
{
    public Text Timer_Text; // �ؽ�Ʈ
    float time_current; // ���� ������ Ÿ�̸� ��
    private bool isEnded; // ������ ��
    public GameObject timer;

    public GameObject DisabledMainBtn; // Ÿ�̸� �۵���(��� ���϶�) �ٸ� ������ �̵��Ұ��ϰԲ� btn ��Ȱ��ȭ�ϰ� �ϴ� ����
    public GameObject DisabledBackBtn;

    void Update()
    {
        if(isEnded) return; // Ÿ�̸Ӱ� ������ ����

        Check_Timer();
    }

    public void Check_Timer()
    {
        if (0 < time_current) // Ÿ�̸� �ð��� 0���� Ŭ������ �۵�
        {
            time_current -= Time.deltaTime; // ���� Ÿ�̸Ӵ� ��� �پ��Ƿ�
            Timer_Text.text = $"{time_current:N0}";
        }
        else if (!isEnded)
        {
            End_Timer();
        }
    }

    public void End_Timer() // Ÿ�̸� ������ ��ƾ, 0���� ����� �������� ����
    {
        time_current = 0;
        Timer_Text.text = $"{time_current:N0}";
        isEnded = true;

        timer.SetActive(false);
        DisabledBackBtn.SetActive(true);
        DisabledMainBtn.SetActive(true);
    }

    public void Reset_Timer() // Ÿ�̸� �����ϱ�
    {

        timer.SetActive(true); 
        DisabledBackBtn.SetActive(false);
        DisabledMainBtn.SetActive(false);

        time_current = float.Parse(DataManager.Instance.data.Devel_Time);
        Timer_Text.text = $"{time_current:N0}";
        isEnded= false;
    }
}
