using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class MainCamera : MonoBehaviour
{
    public Canvas my_canva;
    public Camera[] SubCamera;
    public static int SceneNumber = 0;
    public GameObject my_Arrow;
    public GameObject my_WasherDoor;
    public static Action FChange;
    public static Action Change;
    public static Action Change1;

    void Start()
    {
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
            else if (SceneNumber == 2 && WasherDoorClick.CheckNumber == 0)
            {
                FirstScene();
                my_WasherDoor.GetComponent<BoxCollider>().enabled = true;
                Debug.Log("���������");
                LocalizedComponent.MainTextNumber++;
            }
            SceneNumber++;           
        }
       

    }

    // ī�޶� ��ǥ �������� �̵�
    public void MoveCamera(int index)
    {
        Vector3 new_position = SubCamera[index].transform.position;
        Vector3 new_rotation = SubCamera[index].transform.eulerAngles;

        iTween.MoveTo(this.gameObject, iTween.Hash("position", new_position, "easeType", iTween.EaseType.easeInSine, "time", 1.0f));
        iTween.RotateTo(this.gameObject, iTween.Hash("rotation", new_rotation, "easeType", iTween.EaseType.easeInSine, "time", 1.0f));
    }

    // 1�� ī�޶�� �̵�
    public void FirstScene()
    {
        MoveCamera(0);
        if(SceneNumber !=2)
            my_Arrow.SetActive(true);
    }
    //  2�� ī�޶�� �̵�
    public  void SecondScene(int i)
    {
        MoveCamera(i);
    }
    //  3�� ī�޶�� �̵�
    public void ThirdScene(int i)
    {
        MoveCamera(i);
    }
    private void Awake()
    {
        Change = () => { SecondScene(1); };
        Change1 = () => { ThirdScene(2); };
        FChange = () => { MoveCamera(3); };
    }
}
