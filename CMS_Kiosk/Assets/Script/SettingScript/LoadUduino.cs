using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUduino : MonoBehaviour // 우두이노 사용 x (수정)
{

    private void OnApplicationQuit()
    {
        DataManager.Instance.data.ChangeSceneAuto = false;  // 프로그램이 종료되면 로딩값을 다시 false바꿔서 재시작이 로딩이 시작되게 함.

        for (int k = 0; k < DataManager.Instance.data.i; k++)
        {
            if (DataManager.Instance.data.modeSelect[k] == true)
            {
                DataManager.Instance.data.ImageLight[k] = false; // 종료할때 기존에 있던 pc 값들을 다 false 바꿔줌.(혼동방지)
            }
        }

        DataManager.Instance.SaveGameData(); // 종료할때 데이터 저장
    }

}
