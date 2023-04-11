using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaterLevelButton : MonoBehaviour
{
    public GameObject WaterButton;
    public GameObject WaterArrow;
    public GameObject Bucket;
    public Material[] mat = new Material[2];
    bool isOver = false;
    public static Action WaterReset;

    private void Awake()
    {
        WaterReset = () => { WRest(); };
    }
    void Update()
    {      
        //  물높이 버튼 누르면 물 높이 이미지 생성
        if (isOver && Input.GetMouseButton(0) && WasherDoorClick.CheckNumber == 12)
        {
            WaterButton.GetComponent<SpriteRenderer>().material = mat[0];
            WaterArrow.SetActive(false);
            Bucket.SetActive(true);
            WasherDoorClick.CheckNumber = 13;
        }
        if (VideoPlay.ReNum == 1 && WasherDoorClick.CheckNumber == 0)
        {
            print("여기는 물 높이 리셋 부분입니다.");
            Bucket.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
        isOver = true;
    }

    private void OnMouseExit()
    {
        isOver = false;
    }

   public void WRest()
    {
        if (VideoPlay.ReNum == 1 && WasherDoorClick.CheckNumber == 0)
        {
            print("여기는 물 높이 리셋 부분입니다.");
            Bucket.SetActive(false);
        }
    }
}
