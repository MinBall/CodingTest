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
    }

    void Update()
    {
        // SceneNumber !== 2;
        if (WasherDoorClick.CheckNumber == 3)
        {
            if(VideoPlay.ReNum == 0)
                Invoke("DeterStart", 1.5f);

            WasherDoorClick.CheckNumber=4;  // 4 
        }
    }

    //  세제,섬유유연제 클릭시 파티클 효과와 애니메이션 실행
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
    }

    //  세제와 섬유유연제 강조 부분
    void DeterStart()
    {
        ClickArrow.SetActive(true);
        Detergent[0].GetComponent<MeshRenderer>().material = mat[0];
        Detergent[1].GetComponent<MeshRenderer>().material = mat[0];
    }

    //  파티클 재생부분
    void ParticlePlay()
    {
        particleObject[0].Play();
        particleObject[1].Play();
    }

    void Plus()
    {
        WasherDoorClick.CheckNumber=5;  // 5
        LocalizedComponent.MainTextNumber++;    // 6
    }
}
