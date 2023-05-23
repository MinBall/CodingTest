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
        // 세탁기 패널 클릭 강조 부분
        if (WasherDoorClick.CheckNumber == 7)
        {
            CameraChangePanel.GetComponent<BoxCollider2D>().enabled = true;
            if (VideoPlayManager.ReNum == 0)
            {
                CameraChangePanel.GetComponent<SpriteRenderer>().material = mat[0];
                DialArrow[0].SetActive(true);
            }
            WasherDoorClick.CheckNumber = 8;  // 8
        }
        // 메인 패널 카메라 앞에 띄우고 다이얼 강조 부분
        if (WasherDoorClick.CheckNumber == 9)
        {
            if (VideoPlayManager.ReNum == 0)
            {
                Dial.GetComponent<SpriteRenderer>().material = mat[0];
                DialArrow[1].SetActive(true);
            }
            Invoke("MainPanelOn", 1f);
            WasherDoorClick.CheckNumber = 10;  // 10            
        }
        // 물높이 버튼 강조 부분
        if(WasherDoorClick.CheckNumber == 11)
        {
            if (VideoPlayManager.ReNum == 0)
            {
                PanelButtons[0].GetComponent<SpriteRenderer>().material = mat[0];
                DialArrow[2].SetActive(true);
            }
            WasherDoorClick.CheckNumber = 12;  //  12
            LocalizedComponent.MainTextNumber++;    // 7
        }
        // 시작 버튼 강조 부분
        if (WasherDoorClick.CheckNumber == 13)
        {
            if (VideoPlayManager.ReNum == 0)
            {
                PanelButtons[1].GetComponent<SpriteRenderer>().material = mat[0];
                DialArrow[3].SetActive(true);
            }
            WasherDoorClick.CheckNumber = 14;  // 14
            LocalizedComponent.MainTextNumber = 8;    // 8
        }
        // 카메라 화면 전환하는 부분
        if (WasherDoorClick.CheckNumber == 15)
        {
            LocalizedComponent.MainTextNumber = 10;    // 10
            PanelButtons[1].GetComponent<SpriteRenderer>().material = mat[2];
            //DialClick.DialReset();
            CameraMoveComponent.ChangeCamera(CameraMoveComponent.CameraSceneChangeNumber = 3);   // 메인카메라로 이동
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
