using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetergentClick : MonoBehaviour
{
    public GameObject[] Detergent;
    public GameObject Detergent_Arrow;
    public Animator Detergent_Animator;
    public Material[] mat = new Material[3];
    public ParticleSystem[] Detergent_Particle;


    void Start()
    {
        Detergent_Arrow.SetActive(false);
        Detergent[0].GetComponent<BoxCollider>().enabled = false;
    }

    void Update()
    {
        // SceneNumber !== 2;
        if (WasherDoorClick.CheckNumber == 3)
        {
            if (VideoPlayManager.ReNum == 0)
            {
                Invoke("DeterStart", 0.5f) ;
            }
            else if(VideoPlayManager.ReNum == 1)
                Detergent[0].GetComponent<BoxCollider>().enabled = true;

            WasherDoorClick.CheckNumber=4;  // 4 
                
        }
    }

    //  세제,섬유유연제 클릭시 파티클 효과와 애니메이션 실행
    private void OnMouseDown()
    {
        Detergent_Arrow.SetActive(false);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (WasherDoorClick.CheckNumber == 4)
            {
                
                Detergent[0].GetComponent<MeshRenderer>().material = mat[1];
                Detergent[1].GetComponent<MeshRenderer>().material = mat[2];
                Detergent_Animator.SetTrigger("Detlnput");
                Invoke("ParticlePlay", 1.3f);
                Invoke("Plus", 4);                
            }
        }
        Detergent[0].GetComponent<BoxCollider>().enabled = false;
    }

    //  세제와 섬유유연제 강조 부분
    void DeterStart()
    {
        Detergent_Arrow.SetActive(true);
        Detergent[0].GetComponent<MeshRenderer>().material = mat[0];
        Detergent[1].GetComponent<MeshRenderer>().material = mat[0];
        Detergent[0].GetComponent<BoxCollider>().enabled = true;
    }

    //  파티클 재생부분
    void ParticlePlay()
    {
        Detergent_Particle[0].Play();
        Detergent_Particle[1].Play();
    }

    void Plus()
    {
        WasherDoorClick.CheckNumber=5;  // 5
        LocalizedComponent.MainTextNumber = 5;    // 6
    }
}
