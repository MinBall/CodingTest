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
        //  ��Ź ���� ��ư
        if (isOver && Input.GetMouseButtonDown(0))  // ���� ����� �κ� �н� ��忡���� �� ����µ� ���� ��忡���� �ƹ��볪 Ŭ���ϸ� �۵��ȴ�. ��????
        {
            //PlayButton.GetComponent<BoxCollider>().enabled = true;
            if (WasherDoorClick.CheckNumber == 14)
            {
                Debug.Log(WasherDoorClick.CheckNumber+"���� ��ư");
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
            Debug.Log("��Ź����ư �����Դϴ�.");
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
