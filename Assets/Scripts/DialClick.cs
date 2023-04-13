using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialClick : MonoBehaviour
{
    public GameObject Dial;
    public GameObject DialArrow;
    public Material[] mat = new Material[2];
    bool isOver = false;
    public Animator DialAimator;
    public static Action DialReset;

    private void Awake()
    {
        DialReset = () => { DReset(); };
    }
    private void Update()
    {       
        //  ���̾� Ŭ���� �ִϸ��̼�, ���� ȿ���� �Ѿ
        if ((isOver && Input.GetMouseButtonDown(0)) && WasherDoorClick.CheckNumber==10)
        {
            //MainCamera.Change1();
            Dial.GetComponent<SpriteRenderer>().material = mat[1];
            DialArrow.SetActive(false);
            DialAimator.SetTrigger("Turn");
            WasherDoorClick.CheckNumber = 11;
        }
        
    }

    void DReset()
    {
        if (VideoPlay.ReNum == 1 && WasherDoorClick.CheckNumber == 0)
        {
            Debug.Log("���̾� �ʱ�ȭ �κ��Դϴ�.");
            DialAimator.SetTrigger("Idle");
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
}
