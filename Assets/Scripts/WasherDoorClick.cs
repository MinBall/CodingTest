using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        if (VideoPlay.ReNum == 1&& WasherDoorClick.CheckNumber == 0)
        {
            Debug.Log("����� ��Ź�� ���� �κ��Դϴ�.");
            my_LaundryAnimator.SetTrigger("Idle");
            //DialClick.DialReset();
            PlayButtonclick.PalyBtReset();
            WaterLevelButton.WaterReset();
        }
        //  ��Ź�⹮ �� �ٲٱ�
        if (MainCamera.SceneNumber ==1)
        {            
            my_WasherDoor.GetComponent<MeshRenderer>().material = mat[0];
            my_WasherDoor.GetComponent<BoxCollider>().enabled = true;         
        }
    }

    //  ��Ź�� �� Ŭ���� �� ������ ��Ź�� �ִ� �ִϸ��̼� ����
    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            my_WasherDoor.GetComponent<BoxCollider>().enabled = false;
            my_WasherDoor.GetComponent<MeshRenderer>().material = mat[1];
            my_DoorAnimator.SetBool("DoorOpen", true);        
            Invoke("LaundryAnimation", 0.4f);
            my_LaundryAnimator.ResetTrigger("Idle");
            Invoke("CloseDoor", 1);
            DelayPlus();
        }   

        my_Arrow.SetActive(false);
        CheckNumber = 1;  // 1
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
