using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetergentInsertClick : MonoBehaviour
{
    public Material[] mat = new Material[2];
    public Animator Detergent_Insert_Animator;
    public GameObject[] Detergent_Insertparts;
    public GameObject Detergent_Insert_Arrow;
    GameObject Detergent_Insert;

    void Start()
    {
        Detergent_Insert = GameObject.Find("Detergent-Insert");
        Detergent_Insert_Arrow.SetActive(false);
        Detergent_Insert.GetComponent<BoxCollider>().enabled = false;
    }


    void Update()
    {
        if(WasherDoorClick.CheckNumber == 0)
            Detergent_Insert.GetComponent<BoxCollider>().enabled = false;

        if (WasherDoorClick.CheckNumber == 1)
        {
            if (VideoPlayManager.ReNum == 0)
                Invoke("Delay", 1.5f);
            else
                Invoke("DGColliderOn",1.5f);

            WasherDoorClick.CheckNumber++;  // 2
        }
        if (WasherDoorClick.CheckNumber == 5)
        {
            if (VideoPlayManager.ReNum == 0)
            {
                Detergent_Insert_Arrow.SetActive(true);
                for (int i = 0; i < 6; i++)
                {
                    Detergent_Insertparts[i].GetComponent<MeshRenderer>().material = mat[0];
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
                Detergent_Insert_Arrow.SetActive(false);
                CameraMoveComponent.ChangeCamera(CameraMoveComponent.CameraSceneChangeNumber = 1);
                Detergent_Insertparts[0].GetComponent<MeshRenderer>().material = mat[1];
                Invoke("DetOpen", 1);
                WasherDoorClick.CheckNumber=3;   // 3
                WasherDoorClick.delayPlus();    //LocalizedComponent.MainTextNumber = 4
            }
            // 세제통 닫힘
            if (WasherDoorClick.CheckNumber == 6)
            {
                Detergent_Insert_Animator.SetTrigger("DetergentClose");
                Detergent_Insert_Arrow.SetActive(false);
                for (int i = 0; i < 6; i++)
                {
                    Detergent_Insertparts[i].GetComponent<MeshRenderer>().material = mat[1];                    
                }
                WasherDoorClick.CheckNumber=7;  // 7
                LocalizedComponent.MainTextNumber = 6;    // 7

            }
         }
    }

    void DGColliderOn()
    {
        Detergent_Insert.GetComponent<BoxCollider>().enabled = true;
    }

    void Delay()
    {
        Detergent_Insert_Arrow.SetActive(true);
        Detergent_Insertparts[0].GetComponent<MeshRenderer>().material = mat[0];
        DGColliderOn();
    }

    public void DetOpen()
    {
        Detergent_Insert_Animator.SetTrigger("DetergentOpen");
    }

    void Plus()
    {
        WasherDoorClick.CheckNumber=6;  // 6
    }
}
