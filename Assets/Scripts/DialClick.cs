using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialClick : MonoBehaviour
{
    public GameObject Dial;
    public GameObject DialArrow;
    public Material[] mat = new Material[2];
    bool isOver = false;
    public Animator DialAimator;

    private void Update()
    {
        if (VideoPlay.ReNum == 1&&WasherDoorClick.CheckNumber == 0)
        {
            Debug.Log("��������������������������������������");
            DialAimator.SetTrigger("Dial");
        }
        //  ���̾� Ŭ���� �ִϸ��̼�, ���� ȿ���� �Ѿ
        if (isOver && Input.GetMouseButton(0) && WasherDoorClick.CheckNumber==10)
        {
            MainCamera.Change1();
            Dial.GetComponent<SpriteRenderer>().material = mat[1];
            DialArrow.SetActive(false);
            DialAimator.SetTrigger("Turn");
            WasherDoorClick.CheckNumber = 11;
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
