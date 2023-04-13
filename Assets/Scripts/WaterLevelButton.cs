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
        if (isOver && Input.GetMouseButtonDown(0))
        {
            if (WasherDoorClick.CheckNumber == 12)
            {
                WaterButton.GetComponent<SpriteRenderer>().material = mat[0];
                WaterArrow.SetActive(false);
                Bucket.SetActive(true);
                WasherDoorClick.CheckNumber = 13;
            }
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
            Bucket.SetActive(false);
        }
    }
}
