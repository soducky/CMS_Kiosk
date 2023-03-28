using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class DeleteButton : MonoBehaviour
{
    public Image scrollView; // 삭제모드 일때는 스크롤 뷰 색상을 빨간색으로 변경하기 위해 
    public BoxCollider2D InputFieldPrefab; // 오브젝트 마다 똑같은 콜라이더를 추가하기 위해
    public GameObject addButton; // 삭제모드 일때 추가버튼 비활성화 시키기 위해
    public GameObject ScrollView; // 스크롤뷰 
    public GameObject BackBtn;
    public Button Deletebtn; // 삭제버튼
    public GameObject AllDeleteBtn; // 전체 삭제 버튼
    public GameObject DeleteWaringMent; // 삭제 안내 문구 출력 

    public List<BoxCollider2D> boxcolliderlist = new List<BoxCollider2D>(); // 콜라이더들을 리스트에 대입

    public bool count = false; // 삭제버튼을 딱 한번만 누르게 하기 위해 

    public void DeleteButtonClik() // 삭제 버튼 클릭시
    {
        if (count == false) // 처음 누르면 취소모드 
        {
            DeleteWaringMent.SetActive(true); // 삭제 안내 멘트 활성화

            Invoke("TimeDelay", 0.4f); // 타임 딜레이

            EnterDeleteMode();
        }

        else if (count == true) // 두번 누르면 기존모드로 재진입
        {
            EnterAddMode();
        }

    }

    void TimeDelay() // 경고멘트는 2초 뒤에 사라짐
    {
        DeleteWaringMent.SetActive(false); // 삭제 안내 문구 활성화 2초 invoke, 이후 비활성화
    }

    void ChangeColor()
    {
        if (count == false) // 취소모드일때 스크롤뷰 색상
        {
            scrollView.color = new Color(231f / 255f, 100f / 255f, 100f / 255f, 100f / 255f);
        }
        else if (count == true) // 추가모드일때 스크롤뷰 색상 
        {
            scrollView.color = new Color(0f / 255f, 0f / 255f, 0f / 255f, 100f / 255f);
        }
    }
    public void EnterDeleteMode() // 취소 모드 진입
    {

        List<GameObject> clonelist = GameObject.FindWithTag("AddButton").GetComponent<AddButton>().clonelist; // 클론리스트 불러오기

        BackBtn.SetActive(false);     // 뒤로가기 버튼 비활성화
        addButton.SetActive(false); // 취소모드에는 오류날 수 있는 버튼들 비활성화 

        AllDeleteBtn.SetActive(true); // 전체 삭제 버튼 활성화

        GameObject.Find("InputFieldPrefab").GetComponent<RemoveList>().CheckSignTrue(); // 취소 창을 뜨게하는 스위치 (1번 오브젝트)

        for (int j = 1; j < clonelist.Count; j++)
        {
            GameObject.Find(clonelist[j].name).GetComponent<RemoveList>().CheckSignTrue(); // 취소 창을 뜨게하는 스위치 (1번 이외의 오브젝트)
        } 

        ChangeColor(); // 색상 바꾸기 

        for (int k = 1; k <= clonelist.Count; k++) // clonelist의 길이 == 오브젝트의 갯수 
        {
            boxcolliderlist.Add(clonelist[k].GetComponent<BoxCollider2D>());
            boxcolliderlist[k].name = clonelist[k].name;

            if (boxcolliderlist.Count == clonelist.Count) // 두개가 같을시에는 완료된것이므로 중지 
            {
                break;
            }
        }

        count = true;
    }

    public void EnterAddMode() // 추가모드로 재진입 (추가모드 == 기존 모드)
    {
        ScrollView.SetActive(true); // 스크롤 활성화
        ChangeColor(); // 색상 변경
        addButton.SetActive(true); // 버튼들 활성화 
        BackBtn.SetActive(true);    // 뒤로가기 버튼 활성화

        AllDeleteBtn.SetActive(false); // 전체 삭제 버튼 비활성화

        GameObject.Find("InputFieldPrefab").GetComponent<RemoveList>().CheckSignFalse(); // 취소창 뜨게하는 스위치 false

        try
        {
            for (int j = 1; j < boxcolliderlist.Count; j++)
            {
                GameObject.Find(boxcolliderlist[j].name).GetComponent<RemoveList>().CheckSignFalse(); // 삭제버튼을 2번연속 눌렀을 경우 
            }
        }

        catch (Exception ex) // 예외 - 삭제버튼 누르고 삭제하고 다시 삭제버튼 눌렀을 경우 
        {
            Debug.Log(ex);
            
            List<GameObject> clonelist = GameObject.FindWithTag("AddButton").GetComponent<AddButton>().clonelist;
            List<Text> numbertextlist = GameObject.FindWithTag("AddButton").GetComponent<AddButton>().numbertextlist;
            List<int> Valuelist = GameObject.FindWithTag("AddButton").GetComponent<AddButton>().Valuelist;

            foreach (var i in clonelist)
            {
                if (i == null)
                {
                    clonelist.Remove(i); // 삭제 된 i 값 리스트에서 지우기 
                    break;
                }
            }

            foreach (var i in numbertextlist)
            {
                if (i == null)
                {
                    numbertextlist.Remove(i);
                    break;
                }
            }

            foreach (var i in boxcolliderlist)
            {
                if (i == null)
                {
                    boxcolliderlist.Remove(i);
                    break;
                }
            }

            for (int j = 1; j < clonelist.Count; j++)
            {
                 GameObject.Find(clonelist[j].name).GetComponent<RemoveList>().CheckSignFalse(); 
            } // 이거 안해주면 프리펩 오브젝트들은 추가모드(기존)일때도 취소선택창이 생성됨
            // 여기서 오류나면 삭제가 제대로 안된것. 삭제 오류  

            for (int i = 1; i < clonelist.Count; i++)
            {
                clonelist[i].name = "Clone" + Valuelist[i].ToString();
                numbertextlist[i].name = "Clone" + Valuelist[i].ToString();
                numbertextlist[i].text = Valuelist[i].ToString(); // 삭제한건 밀어내고 이름과, 번호 재정렬
            }
            GameObject.FindWithTag("AddButton").GetComponent<AddButton>().MinusI(); // 삭제되었으니 addbutton 스크립트에 있는 i 값 마이너스 1 
            GameObject.FindWithTag("DeleteComplete").GetComponent<DeleteComplete>().DeleteCompleteMethod(); // 삭제 안내 메세지 메서드 호출
        }

        count = false; // 취소버튼 누르는 횟수 초기화
        boxcolliderlist.Clear(); // 취소모드에서 나가므로 박스 콜라이더 리스트 전체 삭제 
        boxcolliderlist.Add(InputFieldPrefab);
        // 이후에 취소모드에 다시 들어올 수 있으므로 원본 프리펩 콜라이더만 가지고 있으면 됨
      
    }

}

