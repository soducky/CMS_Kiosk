using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RemoveList : MonoBehaviour, IPointerClickHandler // 콜라이더 클릭 가능하게끔 ipointerclickhandler 추가
{
    public GameObject CancelMent; // 취소멘트 창 
    public Text CancelInfoText; // 취소 안내 텍스트
    public Button OkayButton; // 취소 확인버튼
    public GameObject ScrollView; // 스크롤뷰 
    public GameObject DeleteCompleteText; // 삭제안내 문구 

    public GameObject AllDeleteBtn; // 전체 삭제 버튼 -> 오류로 인해 비활성화 시키기 위해서 & 밑에 이유 
    public GameObject DeleteBtn; // 안내멘트 창이 뜨면 버튼들은 잠시 비활성화 시키기 위해 

    public GameObject ZoneName; // ZoneName 영역을 8의 배수 단위로 활성/비활성화 하기 위해

    bool CheckSign = false; // 취소멘트 스위치 (거짓이면 비활성)

    private void Start()
    {
        ZoneNameInput();
    }

    private void Update()
    {
        ZoneNameInput(); // 삭제할때 zoneName이 두개 생성되는 오류가 발생하므로 update문을 돌면서 체크 
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (CheckSign == true) // 취소멘트 활성화
        {
            if (this.gameObject.name == "InputFieldPrefab")
            {
                return; // inputfieldprefab은 첫번째 오브젝트이므로 아무일도 일어나지 않게 하기 위해 
            }

            CancelInfoText.text = this.gameObject.transform.GetChild(6).GetComponent<Text>().text + "번을 삭제하시겠습니까?";
            CancelMent.SetActive(true); // 안내 문구 

            AllDeleteBtn.SetActive(false); // 전체삭제버튼과 삭제버튼 안내 문구가 뜨면 잠시 비활성화
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
            } // 각 오브젝트에 이름을 기준으로 addlistener 활성화 
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

    public void ReturnButton() // 다시 기존 모드로 돌아가는 버튼 
    {
        CancelMent.SetActive(false);

        AllDeleteBtn.SetActive(true); // 전체삭제버튼과 삭제버튼 다시 활성화
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
        } // 오케이 버튼을 누르면 삭제가 됨

        Destroy(this.gameObject); // 오브젝트 파괴 

        CheckSignFalse(); // 오브젝트 삭제 후 취소창 닫음 

        ScrollView.SetActive(false); // 스크롤뷰 끄기 

        DeleteCompleteText.SetActive(true); // 오케이 버튼 누르면 삭제완료안내 메세지 출력

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
        } // 각 오브젝트에 이름을 기준으로 Zone영역 활성화 or 비활성화 => 활성화는 8의 배수 단위로 참 

    }

}

