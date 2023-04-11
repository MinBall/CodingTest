using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;


public class PlayButtonclick : MonoBehaviour
{
    public GameObject PlayButton;
    public GameObject PlayButtonArrow;
    public TextMeshProUGUI text;
    public Material[] mat = new Material[2];
    bool isOver = false;
    public static Action PalyBtReset;

    private void Awake()
    {
        PalyBtReset = () => { PBReset(); };
       // PlayButton.GetComponent<BoxCollider>().enabled = false;
    }
    private void Update()
    {
        //  세탁 시작 버튼
        if (isOver && Input.GetMouseButtonDown(0))  // 버그 생기는 부분 학습 모드에서는 안 생기는데 퀴즈 모드에서는 아무대나 클릭하면 작동된다. 왜????
        {
            //PlayButton.GetComponent<BoxCollider>().enabled = true;
            if (WasherDoorClick.CheckNumber == 14)
            {
                Debug.Log(WasherDoorClick.CheckNumber+"시작 버튼");
                LocalizedComponent.MainTextNumber = 9;    // 9           
                PlayButton.GetComponent<SpriteRenderer>().material = mat[0];
                PlayButtonArrow.SetActive(false);              
                text.gameObject.SetActive(true);
                Invoke("Plus", 1.5f);
            }
        }       
    }

    void PBReset()
    {
        if (VideoPlay.ReNum == 1 && WasherDoorClick.CheckNumber == 0)
        {
            Debug.Log("세탁모드버튼 리셋입니다.");
            text.gameObject.SetActive(false);
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

    void Plus()
    {
        WasherDoorClick.CheckNumber = 15;
    }
}
