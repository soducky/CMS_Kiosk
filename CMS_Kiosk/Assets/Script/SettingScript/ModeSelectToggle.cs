using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ModeSelectToggle : MonoBehaviour // ModeToggle 오브젝트에 대입
{
    Toggle ModeSelect; // 모드 토글

    string slice; // 오브젝트 이름에서 숫자를 따와서 i값으로 넣기 위해
    int tmp;


    void Start()
    {
        TitleTransfer(); // 이름에서 숫자 따오기 
        ModeSelect = GetComponent<Toggle>();
        ModeSelect.onValueChanged.AddListener(OnToggleValueChanged); // 추가
        ChangeUIToggle(); // 씬 이동하고 다시 돌아올떄 저장된 데이터에 맞춰 업데이트
    }

    private void Update()
    {
        ChangeUIToggle();
    }

    public void OnToggleValueChanged(bool boolean) // 토클 클릭 이벤트
    {
        if (boolean == true) // 참
        {
            this.gameObject.transform.GetChild(1).GetComponent<Text>().text = "PC Mode"; // PC Mode 라고 쓰기

            DataManager.Instance.data.modeSelect[tmp - 1] = true; // Data 값도 true 값으로 변경
        }

        else if (boolean == false)
        {
            this.gameObject.transform.GetChild(1).GetComponent<Text>().text = "PJ Mode"; // PJ Mode 라고 쓰기

            DataManager.Instance.data.modeSelect[tmp - 1] = false; // Data 값도 false 값으로 변경
        }
    }

    public void ChangeUIToggle() // 씬 이동하고 다시 돌아올떄 저장된 데이터에 맞춰 업데이트
    {
        if (ModeSelect.isOn == false && DataManager.Instance.data.modeSelect[tmp-1] == false)
        {
            return; // 두개 다 참이거나 false 일때는 리턴
        }

        else if (ModeSelect.isOn == false && DataManager.Instance.data.modeSelect[tmp - 1] == true)
        {

            ModeSelect.isOn = true; // 데이터값에 따라 토글값 맞춤
        
        }

        else if (ModeSelect.isOn == true && DataManager.Instance.data.modeSelect[tmp - 1] == false)
        {
 
            ModeSelect.isOn = false; // 데이터값에 따라 토글값 맞춤

        }

        else if (ModeSelect.isOn == true && DataManager.Instance.data.modeSelect[tmp - 1] == true)
        {
            return;
        }
    }

     void TitleTransfer()
    {
        slice = this.gameObject.name; 
        String substring = slice.Substring(10); //오브젝트 이름에서 10번째부터 끝까지 잘라냄
        tmp = int.Parse(substring); // 그 문자열을 숫자로 변환 
    }

}
