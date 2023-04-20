using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangePanelClick : MonoBehaviour
{
    public GameObject CameraChangePanel;
    public GameObject DialArrow;
    public Material[] mat = new Material[3];
    bool isOver = false;

    private void Awake()
    {
        CameraChangePanel.GetComponent<BoxCollider2D>().enabled = false;
    }
    private void Update()
    {
        //  패널 클릭시 화면 전환, 패널 확대
        if ((isOver && Input.GetMouseButton(0)) && WasherDoorClick.CheckNumber == 8)
        {
            CameraMoveComponent.ChangeCamera(CameraMoveComponent.CameraSceneChangeNumber = 2);
            CameraChangePanel.GetComponent<SpriteRenderer>().material = mat[1];
            CameraChangePanel.GetComponent<BoxCollider2D>().enabled = false;
            DialArrow.SetActive(false);
            WasherDoorClick.CheckNumber = 9;
        }
    }

    private void OnMouseOver()
    {
        isOver = true;
    }

    private void OnMouseExit()
    {
        isOver = false;
    }
}
