using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayButtonclick : MonoBehaviour
{
    public GameObject PlayButton;
    public GameObject PlayButtonArrow;
    public Text text;
    public Material[] mat = new Material[2];
    bool isOver = false;


    private void Update()
    {
        //  세탁 시작 버튼
        if (isOver && Input.GetMouseButton(0) && WasherDoorClick.CheckNumber == 14)
        {
            LocalizedComponent.MainTextNumber = 9;    // 9
            MainCamera.Change1();
            PlayButton.GetComponent<SpriteRenderer>().material = mat[0];
            PlayButtonArrow.SetActive(false);
            text.gameObject.SetActive(true);
            Invoke("Plus", 1.5f);
        }
        if(VideoPlay.ReNum == 1 && WasherDoorClick.CheckNumber == 0)
        {
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
