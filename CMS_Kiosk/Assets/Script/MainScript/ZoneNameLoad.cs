using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneNameLoad : MonoBehaviour
{
    public Text[] Zone1InfoText; // ������ ��ư�� ����� �� �̸� �ؽ�Ʈ-> Zone1InfoText�� ��

    void Start() // �����Ҷ� �� �̸� �ҷ����� 
    {
        if (49 <= DataManager.Instance.data.i) // i ������ 49������ Ŭ�� �� ǥ�� (8�� �����)
        {
            Zone1InfoText[0].text = DataManager.Instance.data.ZoneName[0];
            Zone1InfoText[1].text = DataManager.Instance.data.ZoneName[8];
            Zone1InfoText[2].text = DataManager.Instance.data.ZoneName[16];
            Zone1InfoText[3].text = DataManager.Instance.data.ZoneName[24];
            Zone1InfoText[4].text = DataManager.Instance.data.ZoneName[32];
            Zone1InfoText[5].text = DataManager.Instance.data.ZoneName[40];
            Zone1InfoText[6].text = DataManager.Instance.data.ZoneName[48];
        }
        else if (41 <= DataManager.Instance.data.i && DataManager.Instance.data.i < 49)
        {
            Zone1InfoText[0].text = DataManager.Instance.data.ZoneName[0];
            Zone1InfoText[1].text = DataManager.Instance.data.ZoneName[8];
            Zone1InfoText[2].text = DataManager.Instance.data.ZoneName[16];
            Zone1InfoText[3].text = DataManager.Instance.data.ZoneName[24];
            Zone1InfoText[4].text = DataManager.Instance.data.ZoneName[32];
            Zone1InfoText[5].text = DataManager.Instance.data.ZoneName[40];
        }

        else if (33 <= DataManager.Instance.data.i && DataManager.Instance.data.i < 41)
        {
            Zone1InfoText[0].text = DataManager.Instance.data.ZoneName[0];
            Zone1InfoText[1].text = DataManager.Instance.data.ZoneName[8];
            Zone1InfoText[2].text = DataManager.Instance.data.ZoneName[16];
            Zone1InfoText[3].text = DataManager.Instance.data.ZoneName[24];
            Zone1InfoText[4].text = DataManager.Instance.data.ZoneName[32];
        }

        else if (25 <= DataManager.Instance.data.i && DataManager.Instance.data.i < 33)
        {
            Zone1InfoText[0].text = DataManager.Instance.data.ZoneName[0];
            Zone1InfoText[1].text = DataManager.Instance.data.ZoneName[8];
            Zone1InfoText[2].text = DataManager.Instance.data.ZoneName[16];
            Zone1InfoText[3].text = DataManager.Instance.data.ZoneName[24];
        }

        else if (17 <= DataManager.Instance.data.i && DataManager.Instance.data.i < 25)
        {
            Zone1InfoText[0].text = DataManager.Instance.data.ZoneName[0];
            Zone1InfoText[1].text = DataManager.Instance.data.ZoneName[8];
            Zone1InfoText[2].text = DataManager.Instance.data.ZoneName[16];
        }

        else if (9 <= DataManager.Instance.data.i && DataManager.Instance.data.i < 17)
        {
            Zone1InfoText[0].text = DataManager.Instance.data.ZoneName[0];
            Zone1InfoText[1].text = DataManager.Instance.data.ZoneName[8];
        }


        else if (1 <= DataManager.Instance.data.i && DataManager.Instance.data.i < 9)
        {
            Zone1InfoText[0].text = DataManager.Instance.data.ZoneName[0];
        }
    }
}
