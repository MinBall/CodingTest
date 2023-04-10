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
        //  다이얼 클릭시 애니메이션, 다음 효과로 넘어감
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
