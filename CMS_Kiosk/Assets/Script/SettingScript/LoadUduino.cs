using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUduino : MonoBehaviour // ����̳� ��� x (����)
{

    private void OnApplicationQuit()
    {
        DataManager.Instance.data.ChangeSceneAuto = false;  // ���α׷��� ����Ǹ� �ε����� �ٽ� false�ٲ㼭 ������� �ε��� ���۵ǰ� ��.

        for (int k = 0; k < DataManager.Instance.data.i; k++)
        {
            if (DataManager.Instance.data.modeSelect[k] == true)
            {
                DataManager.Instance.data.ImageLight[k] = false; // �����Ҷ� ������ �ִ� pc ������ �� false �ٲ���.(ȥ������)
            }
        }

        DataManager.Instance.SaveGameData(); // �����Ҷ� ������ ����
    }

}
