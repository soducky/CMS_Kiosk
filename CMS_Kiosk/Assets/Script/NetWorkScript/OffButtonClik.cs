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

    private IEnumerator coroutine; // �ڷ�ƾ(���� ������ ����) -> �º��� ���
    private bool isCoroutine = false; // 1��¥�� �ڷ�ƾ update���� ��� 

    void Start()
    {
        OffBtnTitleTransfer(); // ������Ʈ �������� ��ũ��Ʈ �����Ƿ� ������Ʈ �����ϱ� ���� ����slice
        StartReady(); // �ʱ� ����, false�� ���� ���������� �ٲپ���.

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

        if (DataManager.Instance.data.IPAddress[tmp - 1] == "0") // ip�� 0�̸� ���°��̹Ƿ� imagelight false�� �ٲٱ� 
        {
            DataManager.Instance.data.ImageLight[tmp - 1] = false;
        }

        if (DataManager.Instance.data.modeSelect[tmp-1] == false) // PJ��ũ ��� �϶� 
        {
            _port = int.Parse(DataManager.Instance.data.Port[tmp - 1]);
            _hostName = DataManager.Instance.data.IPAddress[tmp - 1];

            if (_port == 4352 && _hostName != "0")
            {
                if (!isCoroutine)
                {
                    coroutine = countTime(120f); // 120�� , 2�и��� �ݺ�
                    StartCoroutine(coroutine);
                }
            }
        }
    }
    IEnumerator countTime(float delayTime) // �ڷ�ƾ ���鼭 pjlink ���°� �ҷ����� 
    {
        isCoroutine = true;
        yield return new WaitForSeconds(delayTime);

        _hostName = DataManager.Instance.data.IPAddress[tmp - 1];
        _port = int.Parse(DataManager.Instance.data.Port[tmp - 1]);

        PjlinkClient2 PJ = new PjlinkClient2(_hostName, _port, 2000);

        PowerStatus Data = PJ.GetPowerStatus();

        string TransData = Data.ToString();

        if(TransData == "PoweredOn") // ���°� ��ȯ�� �Ŀ�on�̸� �̹��� ���� ���
        {
            DataManager.Instance.data.ImageLight[tmp - 1] = true;
            DataManager.Instance.data.ZoneLight[tmp - 1] = true;
        }

        else if (TransData == "PoweredOff") // ���°� ��ȯ�� �Ŀ�off�̸� �̹��� ���� ����
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

        if (DataManager.Instance.data.modeSelect[tmp - 1] == true) // PC ��� 
        {
            Message = DataManager.Instance.data.IPAddress[tmp - 1];
            GameObject.FindWithTag("Server").GetComponent<Client>().OnSendButton(Message);
        }

        else if (DataManager.Instance.data.modeSelect[tmp - 1] == false) // PJ ��� 
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
    public void OffBtnTitleTransfer() // ������Ʈ �̸� ������ ���� �ڸ���
    {
        slice = this.gameObject.name;
        String substring = slice.Substring(0, 2);
        tmp = int.Parse(substring);
    }
    public void ImageChange() //off�̹Ƿ� ���� ���µ����� ����
    {
        GreenLight.sprite = RedLight;
    }
}
