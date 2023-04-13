using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetergentClick : MonoBehaviour
{
    public GameObject[] Detergent;
    public GameObject ClickArrow;
    public Animator my_DetInputAnimator;
    public Material[] mat = new Material[3];
    public ParticleSystem[] particleObject;


    void Start()
    {
        ClickArrow.SetActive(false);
        Detergent[0].GetComponent<BoxCollider>().enabled = false;
    }

    void Update()
    {
        // SceneNumber !== 2;
        if (WasherDoorClick.CheckNumber == 3)
        {
            if(VideoPlay.ReNum == 0)
                Invoke("DeterStart", 1.5f);

            Detergent[0].GetComponent<BoxCollider>().enabled = true;
            WasherDoorClick.CheckNumber=4;  // 4 
                
        }
    }

    //  ����,���������� Ŭ���� ��ƼŬ ȿ���� �ִϸ��̼� ����
    private void OnMouseDown()
    {
        ClickArrow.SetActive(false);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (WasherDoorClick.CheckNumber == 4)
            {
                
                Detergent[0].GetComponent<MeshRenderer>().material = mat[1];
                Detergent[1].GetComponent<MeshRenderer>().material = mat[2];
                my_DetInputAnimator.SetTrigger("Detlnput");
                Invoke("ParticlePlay", 1.3f);
                Invoke("Plus", 4);                
            }
        }
        Detergent[0].GetComponent<BoxCollider>().enabled = false;
    }

    //  ������ ���������� ���� �κ�
    void DeterStart()
    {
        ClickArrow.SetActive(true);
        Detergent[0].GetComponent<MeshRenderer>().material = mat[0];
        Detergent[1].GetComponent<MeshRenderer>().material = mat[0];
    }

    //  ��ƼŬ ����κ�
    void ParticlePlay()
    {
        particleObject[0].Play();
        particleObject[1].Play();
    }

    void Plus()
    {
        WasherDoorClick.CheckNumber=5;  // 5
        LocalizedComponent.MainTextNumber = 5;    // 6
    }
}
