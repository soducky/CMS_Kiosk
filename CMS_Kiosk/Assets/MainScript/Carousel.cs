using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class Carousel : MonoBehaviour
{
    public GameObject scrollbar; // 스크롤바
    public GameObject selectButton; // 누르는 버튼
    float scroll_pos = 0; // 위치
    bool selectedBtn = false; 
    float[] pos;
    Scrollbar scroll; // 스크롤 
    int i = 0;
    int selectedValue;

    void Start()
    {
        scroll = scrollbar.GetComponent<Scrollbar>();
    }

    void Update()
    {
        pos = new float[transform.childCount];
        float distacne = 1f / (pos.Length - 1);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distacne * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scroll.value;
        }
        else
        {
            if (!selectedBtn)
            {
                for (int i = 0; i < pos.Length; i++)
                {
                    if (scroll_pos < pos[i] + (distacne / 2) && scroll_pos > pos[i] - (distacne / 2))
                    {
                        scroll.value = Mathf.Lerp(scroll.value, pos[i], 0.1f);
                    }
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distacne / 2) && scroll_pos > pos[i] - (distacne / 2))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }

                selectButton.transform.GetChild(i).localScale = Vector2.Lerp(selectButton.transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                for (int k = 0; k < selectButton.transform.childCount; k++)
                {
                    if (k != i)
                    selectButton.transform.GetChild(k).localScale = Vector2.Lerp(selectButton.transform.GetChild(k).localScale, new Vector2(0.7f, 0.7f), 0.1f);
                }
            }
        }
    }

    public void ContentsPosition()
    {
        float distacne = 1f / (pos.Length -1 );
        if (i>0)
        {
            if (selectedValue > int.Parse(EventSystem.current.currentSelectedGameObject.transform.GetComponentInChildren<Text>().text))
            {
                OnePlusOne();
            }

            else
            {
                int FianlEndValue = int.Parse(EventSystem.current.currentSelectedGameObject.transform.GetComponentInChildren<Text>().text);
                StartCoroutine(selectBtn(FianlEndValue * distacne));
            }
        }
        i = 0;
        selectedValue = int.Parse(EventSystem.current.currentSelectedGameObject.transform.GetComponentInChildren<Text>().text);
        i++;
        if (i == 0)
        {
            StartCoroutine(selectBtn(selectedValue * distacne));
        }
    }

    public void OnePlusOne() // 변형한것 갯수가 7면 오류가 발생하므로 한번 더 누르는 효과를 줌 
    {
        float distacne = 1f / (pos.Length - 1);
        int EndValue = int.Parse(EventSystem.current.currentSelectedGameObject.transform.GetComponentInChildren<Text>().text) - 2;
        StartCoroutine(selectBtn(EndValue * distacne));
    }
    IEnumerator selectBtn(float targetValue)
    {
        selectedBtn = true;
        while (true)
        {
            yield return null;
            scroll.value = Mathf.Lerp(scroll.value, targetValue, 0.1f);
            if (Mathf.Abs(scroll.value - targetValue) <= 0.1f)
            {
                scroll_pos = scroll.value;
                selectedBtn = false;
                break;
            }
        }
    }
    //  https://www.youtube.com/watch?v=3AxTpn1Csmk 참조 요망
}
