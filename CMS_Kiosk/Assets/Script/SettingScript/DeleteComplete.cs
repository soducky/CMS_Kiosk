using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteComplete : MonoBehaviour // ���� �Ϸ� �޼��� Ŭ���� 
{
    public GameObject DeleteCompleteText; //�����Ϸ�޼��� 

    public void EnterAddMode2()
    {
        GameObject.FindWithTag("BackGround").transform.GetChild(4).GetComponent<DeleteButton>().DeleteButtonClik();
        // �����Ϸ� �޼��� ������ Deletebutton ������ �Ͱ� ������ ���� -> ��, �⺻ȭ������ ���ư��� ��.
    }

    public void DeleteCompleteMethod()
    {
        DeleteCompleteText.SetActive(false);
        //  �������� ���ư����� �ȳ��޼����� ��Ȱ��ȭ
    }
}
