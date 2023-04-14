using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangePanelClick : MonoBehaviour
{
    public GameObject CameraChangePanel;
    public GameObject DialArrow;
    public Material[] mat = new Material[3];
    bool isOver = false;

    private void Update()
    {
        //  �г� Ŭ���� ȭ�� ��ȯ, �г� Ȯ��
        if ((isOver && Input.GetMouseButton(0)) && WasherDoorClick.CheckNumber == 8)
        {            
            MainCamera.Change(MainCamera.CameraSceneChangeNumber = 2);
            CameraChangePanel.GetComponent<SpriteRenderer>().material = mat[1];
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
