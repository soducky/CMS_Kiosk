using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AddButton : MonoBehaviour // �÷��� ��ư ������ �۵��ϴ� ��ũ��Ʈ
{
    public GameObject OriginalPrefab; // ���� ������ ( 1�� ������Ʈ�� �⺻��, �������� ����)
    public Transform Parent; // �θ� ��ġ
    public GameObject WaringMent; // ��� ��Ʈ( ������Ʈ ������ �ʰ��Ǹ� ������ â )
    public GameObject DeleteButton; // ���� ��ư

    public List<GameObject> clonelist = new List<GameObject>(); // �������� ���� ����Ʈ, ��, �߰���ư�� ������ �߰��Ǵ� ������Ʈ��
    public List<Text> numbertextlist = new List<Text>(); // �� ������Ʈ���� ������ üũ�ϴ� ��ȣ����Ʈ
    public List<int> Valuelist = new List<int>(); 

    bool Switch = true; // ������Ʈ�� 56������ ������ �� �ְ� �������� �߰���ư�� ������ Ƚ���� 56ȸ�� �����ϱ� ���� ����ġ
    int j = 1; // ù��° ������Ʈ 0���� �⺻������ 1������ ����

    private void Awake()
    {
        Application.runInBackground = true; // ��׶��忡�� �����ϴ� ���, PC������ ���� 
    }

    void Start()
    {
        for (int k=0; k < Valuelist.Count; k++)
        {
            Valuelist[k] = k+1; // 1~56������ �ʱ�ȭ
        }

        StartLoadData(); // ������ �����ߴ� ������ �ε�

    }

    private void Update()
    {
        if (clonelist.Count == 1)
        {
            DeleteButton.SetActive(false); // ������Ʈ�� 1�� �ۿ� ���� ��� ������ư ��Ȱ��ȭ
        }

        else
        {
            DeleteButton.SetActive(true); // ������Ʈ�� 2�� �̻��� ��� ������ư Ȱ��ȭ
        }
    }
    public void PrefabAddBtn()
    {
        if (Switch == true) // ����ġ (������Ʈ ������ 56�� �̸��϶��� ��) 
        {

            clonelist.Add(Instantiate(OriginalPrefab,Parent)); // ������Ʈ ���� 
            InputFiledNull(); // 126�� �ٿ� ���� ����
            clonelist[j].name = "Clone" + Valuelist[j].ToString(); // ������Ʈ �̸� ��������

            numbertextlist.Add(clonelist[j].transform.GetChild(6).GetComponent<Text>()); // �ѹ�����Ʈ�� �߰�
            numbertextlist[j].name = "Clone" + Valuelist[j].ToString();
            numbertextlist[j].text = Valuelist[j].ToString();

            clonelist[j].transform.GetChild(8).GetChild(0).name = "Toggle" + Valuelist[j].ToString(); // ���� ������Ʈ�� ����̸� �ٲٱ�
            clonelist[j].transform.GetChild(9).name = "ModeToggle" + Valuelist[j].ToString(); // ���� ������Ʈ�� ��� ��� �̸� �ٲٱ�
            j++;
            DataManager.Instance.data.i++; // �̱��� i�� ������ �ö�. json���Ϸ� �����ϱ� ���ؼ�( i�� ������Ʈ�� ����) 

            if (j == 56) // ������ 56���� ����ġ false 
            {
                Switch = false;
            }
        }

        else if(Switch == false) // ������ 56���� ����Ʈ ���
        {
            WaringMent.SetActive(true);
            Invoke("TimeDelay", 2f);
        }
    }
    void TimeDelay() // ����Ʈ�� 2�� �ڿ� �����
    {
        WaringMent.SetActive(false);
    }

    public void MinusI() // ������Ʈ ���� ��ư�� ������ �ռ� �����ߴ� i���� j���� ������ �پ����
    {                    //  -> ��, ������Ʈ �� ��������  
        j--;
        DataManager.Instance.data.i--;
        Switch = true;
    }

    public void StartLoadData() // start������ ȣ���, ������ �ҷ����� ���
    {
        DataManager.Instance.LoadGameData(); // �����ߴ� json ���� �ҷ����� 

        for (int m = 1; m < DataManager.Instance.data.i; m++)
        {
            CopyAddButton(); // �ҷ����� i ����ŭ ������Ʈ�� �ٽ� ���� -> �ٽ� ������ ������Ʈ�� ������ϱ� 
        }

        GameObject.FindWithTag("InputField").GetComponent<InputData>().WarmingUpLoad(); // �۾��� �ҷ��;��ϹǷ� playerprefs�� �ҷ���
    }

    public void CopyAddButton() // ������Ʈ �ٽ� ���� // �����ҋ� �ٽ� �����ؾ��ϹǷ� 
    {
        if (Switch == true)
        {
            clonelist.Add(Instantiate(OriginalPrefab, Parent));
            clonelist[j].name = "Clone" + Valuelist[j].ToString();

            numbertextlist.Add(clonelist[j].transform.GetChild(6).GetComponent<Text>());
            numbertextlist[j].name = "Clone" + Valuelist[j].ToString();
            numbertextlist[j].text = Valuelist[j].ToString();

            clonelist[j].transform.GetChild(8).GetChild(0).name= "Toggle" + Valuelist[j].ToString();
            clonelist[j].transform.GetChild(9).name = "ModeToggle" + Valuelist[j].ToString();

            j++;

            if (j == 56) // ��� ����ġ �۵�
            {
                Switch = false;
            }
        }

        else if (Switch == false) // ���� ���� ��� ��Ʈ ���
        {
            WaringMent.SetActive(true);
            Invoke("TimeDelay", 2f);
        }
    }

    void InputFiledNull() // ����Ȱ� �ٽ� �ҷ��ö� ������Ʈ 1���� �ؽ�Ʈ ���� �ٸ� ������Ʈ�� ���ԵǹǷ� �����ϱ� ���ؼ� null �� �߰�
    {
        clonelist[j].transform.GetChild(2).GetComponent<InputField>().text = null;
        clonelist[j].transform.GetChild(1).GetComponent<InputField>().text = null;
        clonelist[j].transform.GetChild(0).GetComponent<InputField>().text = "0";
        clonelist[j].transform.GetChild(3).GetComponent<InputField>().text = "0";
        clonelist[j].transform.GetChild(7).GetComponent<InputField>().text = null;
    }
}

