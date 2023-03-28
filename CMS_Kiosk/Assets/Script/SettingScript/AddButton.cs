using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AddButton : MonoBehaviour // 플러스 버튼 누를시 작동하는 스크립트
{
    public GameObject OriginalPrefab; // 원본 프리펩 ( 1번 오브젝트는 기본값, 지워지지 않음)
    public Transform Parent; // 부모 위치
    public GameObject WaringMent; // 경고 멘트( 오브젝트 갯수가 초과되면 나오는 창 )
    public GameObject DeleteButton; // 삭제 버튼

    public List<GameObject> clonelist = new List<GameObject>(); // 프리펩을 담을 리스트, 즉, 추가버튼을 누를때 추가되는 오브젝트들
    public List<Text> numbertextlist = new List<Text>(); // 각 오브젝트들의 개수를 체크하는 번호리스트
    public List<int> Valuelist = new List<int>(); 

    bool Switch = true; // 오브젝트가 56개까지 생성할 수 있게 만듬으로 추가버튼의 누르는 횟수를 56회로 제한하기 위한 스위치
    int j = 1; // 첫번째 오브젝트 0번은 기본값으로 1번부터 시작

    private void Awake()
    {
        Application.runInBackground = true; // 백그라운드에서 동작하는 기능, PC에서만 가능 
    }

    void Start()
    {
        for (int k=0; k < Valuelist.Count; k++)
        {
            Valuelist[k] = k+1; // 1~56번까지 초기화
        }

        StartLoadData(); // 이전에 저장했던 데이터 로드

    }

    private void Update()
    {
        if (clonelist.Count == 1)
        {
            DeleteButton.SetActive(false); // 오브젝트가 1개 밖에 없을 경우 삭제버튼 비활성화
        }

        else
        {
            DeleteButton.SetActive(true); // 오브젝트가 2개 이상일 경우 삭제버튼 활성화
        }
    }
    public void PrefabAddBtn()
    {
        if (Switch == true) // 스위치 (오브젝트 갯수가 56개 미만일때는 참) 
        {

            clonelist.Add(Instantiate(OriginalPrefab,Parent)); // 오브젝트 생성 
            InputFiledNull(); // 126번 줄에 설명 있음
            clonelist[j].name = "Clone" + Valuelist[j].ToString(); // 오브젝트 이름 변경해줌

            numbertextlist.Add(clonelist[j].transform.GetChild(6).GetComponent<Text>()); // 넘버리스트에 추가
            numbertextlist[j].name = "Clone" + Valuelist[j].ToString();
            numbertextlist[j].text = Valuelist[j].ToString();

            clonelist[j].transform.GetChild(8).GetChild(0).name = "Toggle" + Valuelist[j].ToString(); // 하위 오브젝트인 토글이름 바꾸기
            clonelist[j].transform.GetChild(9).name = "ModeToggle" + Valuelist[j].ToString(); // 하위 오브젝트인 토글 모드 이름 바꾸기
            j++;
            DataManager.Instance.data.i++; // 싱글톤 i의 갯수가 올라감. json파일로 저장하기 위해서( i는 오브젝트의 갯수) 

            if (j == 56) // 갯수가 56개면 스위치 false 
            {
                Switch = false;
            }
        }

        else if(Switch == false) // 갯수가 56개면 경고멘트 출력
        {
            WaringMent.SetActive(true);
            Invoke("TimeDelay", 2f);
        }
    }
    void TimeDelay() // 경고멘트는 2초 뒤에 사라짐
    {
        WaringMent.SetActive(false);
    }

    public void MinusI() // 오브젝트 삭제 버튼을 누르면 앞서 선언했던 i값과 j값의 갯수가 줄어들음
    {                    //  -> 즉, 오브젝트 더 생성가능  
        j--;
        DataManager.Instance.data.i--;
        Switch = true;
    }

    public void StartLoadData() // start문에서 호출됨, 데이터 불러오기 기능
    {
        DataManager.Instance.LoadGameData(); // 저장했던 json 파일 불러오기 

        for (int m = 1; m < DataManager.Instance.data.i; m++)
        {
            CopyAddButton(); // 불러오면 i 값만큼 오브젝트를 다시 생성 -> 다시 들어오면 오브젝트는 사라지니까 
        }

        GameObject.FindWithTag("InputField").GetComponent<InputData>().WarmingUpLoad(); // 글씨도 불러와야하므로 playerprefs도 불러옴
    }

    public void CopyAddButton() // 오브젝트 다시 생성 // 시작할떄 다시 생성해야하므로 
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

            if (j == 56) // 경고문 스위치 작동
            {
                Switch = false;
            }
        }

        else if (Switch == false) // 갯수 제한 경고 멘트 출력
        {
            WaringMent.SetActive(true);
            Invoke("TimeDelay", 2f);
        }
    }

    void InputFiledNull() // 저장된걸 다시 불러올때 오브젝트 1번의 텍스트 값이 다른 오브젝트에 대입되므로 방지하기 위해서 null 값 추가
    {
        clonelist[j].transform.GetChild(2).GetComponent<InputField>().text = null;
        clonelist[j].transform.GetChild(1).GetComponent<InputField>().text = null;
        clonelist[j].transform.GetChild(0).GetComponent<InputField>().text = "0";
        clonelist[j].transform.GetChild(3).GetComponent<InputField>().text = "0";
        clonelist[j].transform.GetChild(7).GetComponent<InputField>().text = null;
    }
}

