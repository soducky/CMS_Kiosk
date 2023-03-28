using PjlinkClient;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffButtonClik : MonoBehaviour
{
    string slice;
    int tmp;

    string _hostName;
    int _port;
    public string Message;

    Button OffBtn;
    public Image GreenLight;
    public Sprite RedLight;

    private IEnumerator coroutine; // 코루틴(문자 보내기 위해) -> 태블릿과 통신
    private bool isCoroutine = false; // 1분짜리 코루틴 update문에 사용 

    void Start()
    {
        OffBtnTitleTransfer(); // 오브젝트 여러개에 스크립트 넣으므로 오브젝트 구별하기 위해 숫자slice
        StartReady(); // 초기 셋팅, false인 값들 빨간색으로 바꾸어줌.

        OffBtn = GetComponent<Button>();
        OffBtn.onClick.AddListener(OffBtnClik);
    }

    public void StartReady()
    {
        if (DataManager.Instance.data.ImageLight[tmp - 1] == false)
        {
            ImageChange();
        }

    }

    private void Update()
    {
        if (DataManager.Instance.data.ImageLight[tmp - 1] == false)
        {
            ImageChange();
        }

        if (DataManager.Instance.data.IPAddress[tmp - 1] == "0") // ip가 0이면 없는거이므로 imagelight false로 바꾸기 
        {
            DataManager.Instance.data.ImageLight[tmp - 1] = false;
        }

        if (DataManager.Instance.data.modeSelect[tmp-1] == false) // PJ링크 모드 일때 
        {
            _port = int.Parse(DataManager.Instance.data.Port[tmp - 1]);
            _hostName = DataManager.Instance.data.IPAddress[tmp - 1];

            if (_port == 4352 && _hostName != "0")
            {
                if (!isCoroutine)
                {
                    coroutine = countTime(120f); // 120초 , 2분마다 반복
                    StartCoroutine(coroutine);
                }
            }
        }
    }
    IEnumerator countTime(float delayTime) // 코루틴 돌면서 pjlink 상태값 불러오기 
    {
        isCoroutine = true;
        yield return new WaitForSeconds(delayTime);

        _hostName = DataManager.Instance.data.IPAddress[tmp - 1];
        _port = int.Parse(DataManager.Instance.data.Port[tmp - 1]);

        PjlinkClient2 PJ = new PjlinkClient2(_hostName, _port, 2000);

        PowerStatus Data = PJ.GetPowerStatus();

        string TransData = Data.ToString();

        if(TransData == "PoweredOn") // 상태값 반환이 파워on이면 이미지 상태 녹색
        {
            DataManager.Instance.data.ImageLight[tmp - 1] = true;
            DataManager.Instance.data.ZoneLight[tmp - 1] = true;
        }

        else if (TransData == "PoweredOff") // 상태값 반환이 파워off이면 이미지 상태 빨강
        {
            DataManager.Instance.data.ImageLight[tmp-1] = false;
            DataManager.Instance.data.ZoneLight[tmp - 1] = false;
        }

        isCoroutine = false;
    }
    public void OffBtnClik()
    {
        OffBtnCapsule();
    }

    public void OffBtnCapsule()
    {

        if (DataManager.Instance.data.modeSelect[tmp - 1] == true) // PC 모드 
        {
            Message = DataManager.Instance.data.IPAddress[tmp - 1];
            GameObject.FindWithTag("Server").GetComponent<Client>().OnSendButton(Message);
        }

        else if (DataManager.Instance.data.modeSelect[tmp - 1] == false) // PJ 모드 
        {
            _hostName = DataManager.Instance.data.IPAddress[tmp - 1];
            _port = int.Parse(DataManager.Instance.data.Port[tmp - 1]);

            if (_port == 4352)
            {
                PjlinkClient2 PJ = new PjlinkClient2(_hostName, _port, 2000);
                PJ.PowerOff();

                if (PJ.value == 2)
                {
                    DataManager.Instance.data.ImageLight[tmp - 1] = false;
                    DataManager.Instance.data.ZoneLight[tmp - 1] = false;
                }
            }

            else
            {
                return;
            }
        }
    }
    public void OffBtnTitleTransfer() // 오브젝트 이름 끝에서 숫자 자르기
    {
        slice = this.gameObject.name;
        String substring = slice.Substring(0, 2);
        tmp = int.Parse(substring);
    }
    public void ImageChange() //off이므로 빨간 상태등으로 변경
    {
        GreenLight.sprite = RedLight;
    }
}
