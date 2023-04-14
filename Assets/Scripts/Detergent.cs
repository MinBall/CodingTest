using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detergent : MonoBehaviour
{
    public Material[] mat = new Material[2];
    public Animator my_DetergentInAnimator;
    public GameObject[] my_DetergentIn;
    public GameObject Detergent_Arrow;
    GameObject DetergentIn;

    void Start()
    {
        DetergentIn = GameObject.Find("Detergent-Insert");
        Detergent_Arrow.SetActive(false);
        DetergentIn.GetComponent<BoxCollider>().enabled = false;
    }


    void Update()
    {
        if(WasherDoorClick.CheckNumber == 0)
            DetergentIn.GetComponent<BoxCollider>().enabled = false;

        if (WasherDoorClick.CheckNumber == 1)
        {
            if (VideoPlay.ReNum == 0)
                Invoke("Delay", 1.5f);
            else
                Invoke("DGColliderOn",1.5f);

            WasherDoorClick.CheckNumber++;  // 2
        }
        if (WasherDoorClick.CheckNumber == 5)
        {
            if (VideoPlay.ReNum == 0)
            {
                Detergent_Arrow.SetActive(true);
                for (int i = 0; i < 6; i++)
                {
                    my_DetergentIn[i].GetComponent<MeshRenderer>().material = mat[0];
                }
            }
            WasherDoorClick.CheckNumber = 6; // 6
        }
    }

    // 세재통 눌렀을 때 열고 닫히는 부분
    private void OnMouseDown()
    {        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
         if (Physics.Raycast(ray, out hit))
         {
            //  세제통 열림
            if (WasherDoorClick.CheckNumber == 2)
            {
                Detergent_Arrow.SetActive(false);
                MainCamera.Change(MainCamera.CameraSceneChangeNumber = 1);
                my_DetergentIn[0].GetComponent<MeshRenderer>().material = mat[1];
                Invoke("DetOpen", 1);
                WasherDoorClick.CheckNumber=3;   // 3
                WasherDoorClick.DPlus();    //LocalizedComponent.MainTextNumber = 4
            }
            // 세제통 닫힘
            if (WasherDoorClick.CheckNumber == 6)
            {
                my_DetergentInAnimator.SetTrigger("DetergentClose");
                Detergent_Arrow.SetActive(false);
                for (int i = 0; i < 6; i++)
                {
                    my_DetergentIn[i].GetComponent<MeshRenderer>().material = mat[1];                    
                }
                WasherDoorClick.CheckNumber=7;  // 7
                LocalizedComponent.MainTextNumber = 6;    // 7

            }
         }
    }

    void DGColliderOn()
    {
        DetergentIn.GetComponent<BoxCollider>().enabled = true;
    }

    void Delay()
    {
        Detergent_Arrow.SetActive(true);
        my_DetergentIn[0].GetComponent<MeshRenderer>().material = mat[0];
        DGColliderOn();
    }

    public void DetOpen()
    {
        my_DetergentInAnimator.SetTrigger("DetergentOpen");
    }

    void Plus()
    {
        WasherDoorClick.CheckNumber=6;  // 6
    }
}
