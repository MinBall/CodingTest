using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class StepController : MonoBehaviour
{
    public Animator animator;
    public LocalizedTMPComponent localizedTMPComponent;
    public Camera mainCamera;
    //public Camera uiCamera;
    public TextMeshProUGUI TempText;
    public LayerMask guideLayer;
    public GameObject[] GuideBtn;

  public void ChangeMainText(string code)
    {
        localizedTMPComponent.LocalizedCode = code; 
    }
    public void TurnOffGuide()
    {
        mainCamera.cullingMask = mainCamera.cullingMask ^ guideLayer;
        //uiCamera.cullingMask = uiCamera.cullingMask ^ guideLayer;
        animator.SetInteger("PlayCount", animator.GetInteger("PlayCount") + 1);

        for(int i = 0; i<GuideBtn.Length; i++)
            GuideBtn[i].SetActive(false);

        TempText.text = "30.6" + "°C";

        if (animator.GetInteger("PlayCount") >= 2)
        {
            Native.TestFinish();
        }
    }
    public static class Native
    {
        [DllImport("__Internal")]
        public static extern void TestFinish();
    }
    
    public void Temp()
    {
        StartCoroutine(Count());
    }

    IEnumerator Count()
    {
        float target = 27f;
        float current = 32.6f;
        float duration = 2.5f; // 카운팅에 걸리는 시간 설정. 
        float offset = (29f - current) / duration;

        while (current > target)
        {
            if(current >30)
            {
                TempText.color = Color.red;
            }
            else if(current < 30)
            {
                TempText.color = Color.black;
            }
            current += offset * Time.deltaTime;
            TempText.text = ((int)current).ToString() + "°C";
            yield return null;
        }

        current = target;
        TempText.text = ((int)current).ToString()+ "°C";
    }
}
