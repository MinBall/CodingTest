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
    public static Action PlayBtReset;

    private void Awake()
    {
        PlayBtReset = () => { PBReset(); };
    }
    private void Update()
    {
        //  세탁 시작 버튼
        /*if (isOver && Input.GetMouseButtonDown(0))  //
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
        }       */
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (WasherDoorClick.CheckNumber == 14)
            {                
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
        if (VideoPlayManager.ReNum == 1 && WasherDoorClick.CheckNumber == 0)
        {
            text.gameObject.SetActive(false);
        }
    }
   /* private void OnMouseOver()
    {
        isOver = true;
    }

    private void OnMouseExit()
    {
        isOver = false;
    }*/

    void Plus()
    {
        WasherDoorClick.CheckNumber = 15;
    }
}
