using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RemoveList : MonoBehaviour, IPointerClickHandler // �ݶ��̴� Ŭ�� �����ϰԲ� ipointerclickhandler �߰�
{
    public GameObject CancelMent; // ��Ҹ�Ʈ â 
    public Text CancelInfoText; // ��� �ȳ� �ؽ�Ʈ
    public Button OkayButton; // ��� Ȯ�ι�ư
    public GameObject ScrollView; // ��ũ�Ѻ� 
    public GameObject DeleteCompleteText; // �����ȳ� ���� 

    public GameObject AllDeleteBtn; // ��ü ���� ��ư -> ������ ���� ��Ȱ��ȭ ��Ű�� ���ؼ� & �ؿ� ���� 
    public GameObject DeleteBtn; // �ȳ���Ʈ â�� �߸� ��ư���� ��� ��Ȱ��ȭ ��Ű�� ���� 

    public GameObject ZoneName; // ZoneName ������ 8�� ��� ������ Ȱ��/��Ȱ��ȭ �ϱ� ����

    bool CheckSign = false; // ��Ҹ�Ʈ ����ġ (�����̸� ��Ȱ��)

    private void Start()
    {
        ZoneNameInput();
    }

    private void Update()
    {
        ZoneNameInput(); // �����Ҷ� zoneName�� �ΰ� �����Ǵ� ������ �߻��ϹǷ� update���� ���鼭 üũ 
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (CheckSign == true) // ��Ҹ�Ʈ Ȱ��ȭ
        {
            if (this.gameObject.name == "InputFieldPrefab")
            {
                return; // inputfieldprefab�� ù��° ������Ʈ�̹Ƿ� �ƹ��ϵ� �Ͼ�� �ʰ� �ϱ� ���� 
            }

            CancelInfoText.text = this.gameObject.transform.GetChild(6).GetComponent<Text>().text + "���� �����Ͻðڽ��ϱ�?";
            CancelMent.SetActive(true); // �ȳ� ���� 

            AllDeleteBtn.SetActive(false); // ��ü������ư�� ������ư �ȳ� ������ �߸� ��� ��Ȱ��ȭ
            DeleteBtn.SetActive(false);

            switch (this.gameObject.name)
            {
                case "Clone2":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone3":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone4":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone5":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone6":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone7":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone8":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone9":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone10":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone11":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone12":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone13":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone14":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone15":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone16":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone17":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone18":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone19":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone20":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone21":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone22":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone23":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone24":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone25":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone26":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone27":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone28":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone29":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone30":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;
                case "Clone31":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone32":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone33":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone34":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone35":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone36":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone37":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone38":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone39":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone40":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone41":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone42":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone43":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone44":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone45":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone46":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone47":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone48":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone49":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone50":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone51":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone52":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone53":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone54":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone55":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;

                case "Clone56":
                    OkayButton.onClick.AddListener(Okaybutton);
                    break;
            } // �� ������Ʈ�� �̸��� �������� addlistener Ȱ��ȭ 
        }
    }

   // public void

    public void CheckSignTrue()
    {
        CheckSign = true;
    }

    public void CheckSignFalse()
    {
        CancelMent.SetActive(false);
        CheckSign = false;
    }

    public void ReturnButton() // �ٽ� ���� ���� ���ư��� ��ư 
    {
        CancelMent.SetActive(false);

        AllDeleteBtn.SetActive(true); // ��ü������ư�� ������ư �ٽ� Ȱ��ȭ
        DeleteBtn.SetActive(true);
    }

    public void Okaybutton()
    {
        switch (this.gameObject.name)
        {
            case "Clone2":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone3":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone4":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone5":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone6":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone7":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone8":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone9":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone10":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone11":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone12":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone13":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone14":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone15":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone16":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone17":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone18":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone19":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone20":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone21":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone22":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone23":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone24":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone25":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone26":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone27":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone28":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone29":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;

            case "Clone30":
                OkayButton.onClick.RemoveListener(Okaybutton);
                break;
        } // ������ ��ư�� ������ ������ ��

        Destroy(this.gameObject); // ������Ʈ �ı� 

        CheckSignFalse(); // ������Ʈ ���� �� ���â ���� 

        ScrollView.SetActive(false); // ��ũ�Ѻ� ���� 

        DeleteCompleteText.SetActive(true); // ������ ��ư ������ �����Ϸ�ȳ� �޼��� ���

    }

    public void ZoneNameInput()
    {
        switch (this.gameObject.name)
        {
            case "InputFieldPrefab":
                ZoneName.SetActive(true);
                break;

            case "Clone2":
                ZoneName.SetActive(false);
                break;

            case "Clone3":
                ZoneName.SetActive(false);
                break;

            case "Clone4":
                ZoneName.SetActive(false);
                break;

            case "Clone5":
                ZoneName.SetActive(false);
                break;

            case "Clone6":
                ZoneName.SetActive(false);
                break;

            case "Clone7":
                ZoneName.SetActive(false);
                break;

            case "Clone8":
                ZoneName.SetActive(false);
                break;

            case "Clone9":
                ZoneName.SetActive(true);
                break;

            case "Clone10":
                ZoneName.SetActive(false);
                break;

            case "Clone11":
                ZoneName.SetActive(false);
                break;

            case "Clone12":
                ZoneName.SetActive(false);
                break;

            case "Clone13":
                ZoneName.SetActive(false);
                break;

            case "Clone14":
                ZoneName.SetActive(false);
                break;

            case "Clone15":
                ZoneName.SetActive(false);
                break;

            case "Clone16":
                ZoneName.SetActive(false);
                break;

            case "Clone17":
                ZoneName.SetActive(true);
                break;

            case "Clone18":
                ZoneName.SetActive(false);
                break;

            case "Clone19":
                ZoneName.SetActive(false);
                break;

            case "Clone20":
                ZoneName.SetActive(false);
                break;

            case "Clone21":
                ZoneName.SetActive(false);
                break;

            case "Clone22":
                ZoneName.SetActive(false);
                break;

            case "Clone23":
                ZoneName.SetActive(false);
                break;

            case "Clone24":
                ZoneName.SetActive(false);
                break;

            case "Clone25":
                ZoneName.SetActive(true);
                break;

            case "Clone26":
                ZoneName.SetActive(false);
                break;

            case "Clone27":
                ZoneName.SetActive(false);
                break;

            case "Clone28":
                ZoneName.SetActive(false);
                break;

            case "Clone29":
                ZoneName.SetActive(false);
                break;

            case "Clone30":
                ZoneName.SetActive(false);
                break;
            case "Clone31":
                ZoneName.SetActive(false);
                break;

            case "Clone32":
                ZoneName.SetActive(false);
                break;

            case "Clone33":
                ZoneName.SetActive(true);
                break;

            case "Clone34":
                ZoneName.SetActive(false);
                break;

            case "Clone35":
                ZoneName.SetActive(false);
                break;

            case "Clone36":
                ZoneName.SetActive(false);
                break;

            case "Clone37":
                ZoneName.SetActive(false);
                break;

            case "Clone38":
                ZoneName.SetActive(false);
                break;

            case "Clone39":
                ZoneName.SetActive(false);
                break;

            case "Clone40":
                ZoneName.SetActive(false);
                break;

            case "Clone41":
                ZoneName.SetActive(true);
                break;

            case "Clone42":
                ZoneName.SetActive(false);
                break;

            case "Clone43":
                ZoneName.SetActive(false);
                break;

            case "Clone44":
                ZoneName.SetActive(false);
                break;

            case "Clone45":
                ZoneName.SetActive(false);
                break;

            case "Clone46":
                ZoneName.SetActive(false);
                break;

            case "Clone47":
                ZoneName.SetActive(false);
                break;

            case "Clone48":
                ZoneName.SetActive(false);
                break;

            case "Clone49":
                ZoneName.SetActive(true);
                break;

            case "Clone50":
                ZoneName.SetActive(false);
                break;

            case "Clone51":
                ZoneName.SetActive(false);
                break;

            case "Clone52":
                ZoneName.SetActive(false);
                break;

            case "Clone53":
                ZoneName.SetActive(false);
                break;

            case "Clone54":
                ZoneName.SetActive(false);
                break;

            case "Clone55":
                ZoneName.SetActive(false);
                break;

            case "Clone56":
                ZoneName.SetActive(false);
                break;
        } // �� ������Ʈ�� �̸��� �������� Zone���� Ȱ��ȭ or ��Ȱ��ȭ => Ȱ��ȭ�� 8�� ��� ������ �� 

    }

}

