using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteComplete : MonoBehaviour // 삭제 완료 메세지 클래스 
{
    public GameObject DeleteCompleteText; //삭제완료메세지 

    public void EnterAddMode2()
    {
        GameObject.FindWithTag("BackGround").transform.GetChild(4).GetComponent<DeleteButton>().DeleteButtonClik();
        // 삭제완료 메세지 누르면 Deletebutton 누르는 것과 동일한 동작 -> 즉, 기본화면으로 돌아가게 됨.
    }

    public void DeleteCompleteMethod()
    {
        DeleteCompleteText.SetActive(false);
        //  기존모드로 돌아갔으면 안내메세지는 비활성화
    }
}
