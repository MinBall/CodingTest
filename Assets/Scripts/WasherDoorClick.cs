using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasherDoorClick : MonoBehaviour
{
    public GameObject my_Arrow;
    public GameObject Detergent_Arrow;
    public GameObject my_WasherDoor;
    public Animator my_DoorAnimator;
    public Animator my_LaundryAnimator;
    public Material[] mat = new Material[2];
    public static int CheckNumber = 0;
    public static Action DPlus;

    private void Awake()
    {
        my_WasherDoor.GetComponent<BoxCollider>().enabled = false;
        DPlus = () => { DelayPlus(); };
    }
    void Update()
    {
        //  세탁기문 색 바꾸기
        if (MainCamera.SceneNumber ==1)
        {            
            my_WasherDoor.GetComponent<MeshRenderer>().material = mat[0];
            my_WasherDoor.GetComponent<BoxCollider>().enabled = true;         
        }
    }

    //  세탁기 문 클릭시 문 열리고 세탁물 넣는 애니메이션 실행
    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            my_WasherDoor.GetComponent<BoxCollider>().enabled = false;
            my_WasherDoor.GetComponent<MeshRenderer>().material = mat[1];
            my_DoorAnimator.SetBool("DoorOpen",true);
            Invoke("LaundryAnimation", 0.4f);
            Invoke("CloseDoor", 1);
            DelayPlus();
        }   

        my_Arrow.SetActive(false);
        CheckNumber++;  // 1
    }

    void LaundryAnimation()
    {
        my_LaundryAnimator.SetTrigger("LaundryMove");
    }

    public void CloseDoor()
    {
        my_DoorAnimator.SetBool("CloseDoor", true);
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
