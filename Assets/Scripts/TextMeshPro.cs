using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextMeshPro : LocalizedTextComponent
{
    /*public TextMeshProUGUI StautText;
    void Start()
    {
        StautText = GetComponent<TextMeshProUGUI>();
        //StautText.text = "세탁기 사용 방법 학습을 시작합니다.\n" + "화면을 클릭해 주세요.";
        StautText.text = textComponent.text;
    }

    // Update is called once per frame
    void Update()
    {    
        if (MainCamera.SceneNumber == 1)
        {
            LocalizedComponent.MainTextNumber = 2;                       
        }
        if(WasherDoorClick.CheckNumber == 1)
        {
            //Invoke("DetOpenMsg", 1.0f);
            LocalizedComponent.MainTextNumber = 3;
        }
        if(WasherDoorClick.CheckNumber == 3)
        {
            Invoke("DetTouchMsg", 1.5f);
        }
        if (WasherDoorClick.CheckNumber == 5)
        {
            //Invoke("DetCloseMsg", 1.0f);
            DetCloseMsg();
        }
        if(WasherDoorClick.CheckNumber == 7)
        {
            SelectModeMsg();
        }
        if (WasherDoorClick.CheckNumber == 11)
        {
            WaterLevelMsg();
        }
        if (WasherDoorClick.CheckNumber == 13)
        {
            StartMsg();
        }
        if (WasherDoorClick.CheckNumber == 15)
        {
            StartMsg();
        }
        if (WasherDoorClick.CheckNumber == 17)
        {
            WaitingMsg();
        }
    }

   public void DetOpenMsg()
    {
        StautText.text = "세제 자동 투입함을 엽니다.";
    }

    public void DetTouchMsg()
    {
        StautText.text = "적정량의 세재와 섬유 유연제를 투입합니다.";
    }

    public void DetCloseMsg()
    {
        StautText.text = "세제 자동 투입함을 닫습니다.";
    }

    public void SelectModeMsg()
    {
        StautText.text = "세탁 모드를 설정합니다.";
    }

    public void WaterLevelMsg()
    {
        StautText.text = "물 높이를 설정합니다.";
    }

    public void StartMsg()
    {
        StautText.text = "시작/일시정지 버튼을 눌러 세탁을 시작합니다.";
    }

    public void GuideMsg()
    {
        StautText.text = "세탁이 시작 되었습니다.";
    }

    public void WaitingMsg()
    {
        StautText.text = "세탁이 완료 되기까지 시간을 보냅니다.";
    }*/
}
