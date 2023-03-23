using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUduino : MonoBehaviour
{

    private void OnApplicationQuit()
    {
        DataManager.Instance.data.ChangeSceneAuto = false;

        for (int k = 0; k < DataManager.Instance.data.i; k++)
        {
            if (DataManager.Instance.data.modeSelect[k] == true)
            {
                DataManager.Instance.data.ImageLight[k] = false;
            }
        }

        DataManager.Instance.SaveGameData();
    }

}
