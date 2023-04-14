using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.AI;

public class MainCamera : MonoBehaviour
{
    public Canvas my_canva;
    public Camera[] SubCamera;
    public static int SceneNumber = 0;
    public GameObject my_Arrow;
    public GameObject my_WasherDoor;
    public static Action<int> Change;
    public static int CameraSceneChangeNumber;
    private void Awake()
    {
        Change = (int CameraSceneChangeNumber) => { SecondScene(CameraSceneChangeNumber); };
        my_Arrow.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (SceneNumber == 0)
            {
                FirstScene();
                LocalizedComponent.MainTextNumber++;    // 2               
            }
            else if ((SceneNumber == 2 && WasherDoorClick.CheckNumber == 0) && VideoPlay.ReNum ==1)
            {
                FirstScene();
                my_WasherDoor.GetComponent<BoxCollider>().enabled = true;
                Debug.Log("퀴즈모드시작");
                LocalizedComponent.MainTextNumber++;    // 2
            }
            SceneNumber++;           
        }       
    }

    // 카메라를 목표 지점으로 이동
    public void MoveCamera(int index)
    {
        Vector3 new_position = SubCamera[index].transform.position;
        Vector3 new_rotation = SubCamera[index].transform.eulerAngles;

        iTween.MoveTo(this.gameObject, iTween.Hash("position", new_position, "easeType", iTween.EaseType.easeInSine, "time", 1.0f));
        iTween.RotateTo(this.gameObject, iTween.Hash("rotation", new_rotation, "easeType", iTween.EaseType.easeInSine, "time", 1.0f));
    }

    // 1번 카메라로 이동
    public  void FirstScene()
    {
        MoveCamera(0);
        if (SceneNumber != 2)
            my_Arrow.SetActive(true);
    }
    //  2번 카메라로 이동
    public  void SecondScene(int i)
    {
        if (i == 1)
            MoveCamera(i);
        else if (i == 2)
            MoveCamera(i);
        else if (i == 3)
            MoveCamera(i);
    }
    //  3번 카메라로 이동
   /* public void ThirdScene(int i)
    {
        MoveCamera(i);
    }*/
   
}
