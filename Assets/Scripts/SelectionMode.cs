using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectionMode : MonoBehaviour
{
    public GameObject CameraChangePanel;
    public GameObject MainPanel;
    public GameObject Dial;
    public GameObject[] PanelButtons;
    public GameObject[] DialArrow;
    public GameObject WaterBucket;
    public Material[] mat = new Material[3];
    public Animator DialAimator;

    void Start()
    {
        MainPanel.SetActive(false);
        WaterBucket.SetActive(false);
        for (int i = 0; i < 4; i++)
        {
            DialArrow[i].SetActive(false);
        }
    }

    void Update()
    {
        // 세탁기 패널 클릭하는 부분
        if (WasherDoorClick.CheckNumber == 7)
        {
            CameraChangePanel.GetComponent<SpriteRenderer>().material = mat[0];
            DialArrow[0].SetActive(true);
            WasherDoorClick.CheckNumber++;  // 8
        }
        // 메인 패널 카메라 앞에 띄우고 다이얼 강조 부분
        if (WasherDoorClick.CheckNumber == 9)
        {
            Invoke("MainPanelOn", 1f);
            Dial.GetComponent<SpriteRenderer>().material = mat[0];
            DialArrow[1].SetActive(true);
            WasherDoorClick.CheckNumber++;  // 10            
        }
        // 물높이 버튼 강조 부분
        if(WasherDoorClick.CheckNumber == 11)
        {
            LocalizedComponent.MainTextNumber++;    // 7
            PanelButtons[0].GetComponent<SpriteRenderer>().material = mat[0];
            DialArrow[2].SetActive(true);
            WasherDoorClick.CheckNumber++;  //  12
        }
        // 시작 버튼 누르는 부분
        if (WasherDoorClick.CheckNumber == 13)
        {
            LocalizedComponent.MainTextNumber++;    // 8
            PanelButtons[1].GetComponent<SpriteRenderer>().material = mat[0];
            DialArrow[3].SetActive(true);
            WasherDoorClick.CheckNumber++;  // 14
        }
        // 카메라 화면 전환하는 부분
        if (WasherDoorClick.CheckNumber == 15)
        {
            LocalizedComponent.MainTextNumber = 10;    // 10
            PanelButtons[1].GetComponent<SpriteRenderer>().material = mat[2];
            MainCamera.FChange();
            MainPanelOff();
            WasherDoorClick.CheckNumber =16;
        }
    }

    void MainPanelOn()
    {
        MainPanel.SetActive(true);
    }

    void MainPanelOff()
    {
        MainPanel.SetActive(false);
    }

}
