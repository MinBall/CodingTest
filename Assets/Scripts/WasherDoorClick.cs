using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WasherDoorClick : MonoBehaviour
{
    public GameObject WasherDoorArrow;
    public GameObject Detergent_Arrow;
    public GameObject WasherDoor;
    public Animator DoorAnimator;
    public Animator LaundryAnimator;
    public Material[] mat = new Material[2];
    public static int CheckNumber = 0;
    public static Action delayPlus;
    private void Awake()
    {
        WasherDoor.GetComponent<BoxCollider>().enabled = false;
        delayPlus = () => { DelayPlus(); };        
    }
    void Update()
    {
        if (VideoPlayManager.ReNum == 1&& WasherDoorClick.CheckNumber == 0)
        {
            LaundryAnimator.SetTrigger("Idle");
            PlayButtonclick.PlayBtReset();
            WaterLevelButton.WaterReset();
            
        }
        //  세탁기문 색 바꾸기
        if (CameraMoveComponent.SceneNumber ==1)
        {
            WasherDoor.GetComponent<MeshRenderer>().material = mat[0];
            WasherDoor.GetComponent<BoxCollider>().enabled = true;         
        }
    }

    //  세탁기 문 클릭시 문 열리고 세탁물 넣는 애니메이션 실행
    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            WasherDoor.GetComponent<BoxCollider>().enabled = false;
            WasherDoor.GetComponent<MeshRenderer>().material = mat[1];
            DoorAnimator.SetBool("DoorOpen", true);
            Invoke("LaundryAnimation", 0.4f);
            LaundryAnimator.ResetTrigger("Idle");
            Invoke("CloseDoor", 1);            
            DelayPlus();
        }

        WasherDoorArrow.SetActive(false);
        CheckNumber = 1;  // 1
    }

    void LaundryAnimation()
    {
        LaundryAnimator.SetTrigger("LaundryMove");

    }

    public void CloseDoor()
    {
        DoorAnimator.SetBool("CloseDoor", true);        
    }

    public void Plus()
    {
        LocalizedComponent.MainTextNumber++; // 3
    }

    public void DelayPlus()
    {
        Invoke("Plus", 1.5f);
    }

   

}
