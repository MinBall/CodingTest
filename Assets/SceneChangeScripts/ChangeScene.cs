using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

// �� ��ȯ�ϴ� ��ũ��Ʈ ����
public class ChangeScene : MonoBehaviour
{
    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Change();
        }
    }
    public void Change()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
