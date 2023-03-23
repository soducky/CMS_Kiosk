using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class SelectToggles : MonoBehaviour
{
    Toggle Toggle_solo; // 각 토글들

    string slice; // 문자열 공간
    int tmp; // 제목의 숫자  

    private void Start()
    {
        TitleTransfer();  // 이름에서 숫자 따오기 
        Toggle_solo = GetComponent<Toggle>();
        Togglestart(); // 이벤트 추가 start문 
        LoadToggleData(); // 씬 이동하고 다시 돌아올떄 저장된 데이터에 맞춰 업데이트
    }

    private void Update()
    {
        LoadToggleData(); // 토글 updata문 돌면서 계속 바꿔주기 
    }
   // 토글 오류나면 사용 
    public void Togglestart()
    {
        Toggle_solo.onValueChanged.AddListener(OnToggleValueChanged); // 이벤트 추가 start문 
    }

    public void OnToggleValueChanged(bool boolean)  // 토클 클릭 이벤트
    {

        if (boolean == true) // 참이면 데이터 값 true로 변경
        {
            DataManager.Instance.data.s[tmp - 1] = true;
        }


        else if (boolean == false)
        {
            DataManager.Instance.data.s[tmp - 1] = false;
        }
    }

    public void LoadToggleData()
    { // 씬 이동하고 다시 돌아올떄 저장된 데이터에 맞춰 업데이트

        if (Toggle_solo.isOn == false && DataManager.Instance.data.s[tmp - 1] == false)
        {
            return; // 두개 다 참이거나 false 일때는 리턴
        }

        else if (Toggle_solo.isOn == false && DataManager.Instance.data.s[tmp - 1] == true)
        {
            Toggle_solo.isOn = true; // 데이터값에 따라 토글값 맞춤
        } 

        else if (Toggle_solo.isOn == true && DataManager.Instance.data.s[tmp - 1] == false)
        {
            Toggle_solo.isOn = false; // 데이터값에 따라 토글값 맞춤
        }

        else if (Toggle_solo.isOn == true && DataManager.Instance.data.s[tmp - 1] == true)
        {
            return;
        }
    }

    void TitleTransfer()
    {
        slice = this.gameObject.name;
        String substring = slice.Substring(6); //오브젝트 이름에서 10번째부터 끝까지 잘라냄
        tmp = int.Parse(substring);  // 그 문자열을 숫자로 변환 
    }
}

