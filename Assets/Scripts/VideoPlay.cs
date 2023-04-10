using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Runtime.InteropServices;

public class VideoPlay : MonoBehaviour
{
    public GameObject Phone;
    public VideoPlayer video;
    public Animator PhoneAimator;
    public static int ReNum = 0;
#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void ShowMessage(string message);
#endif
    
    private void Start()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
         WebGLInput.captureAllKeyboardInput = false;
        #endif
    }
    void Update()
    {
        if (WasherDoorClick.CheckNumber == 16)
        {
            Phone.SetActive(true);
            PhoneAimator.SetTrigger("PhoneMove");
            video.Play();
            WasherDoorClick.CheckNumber = 17;   //  17을 좀 늦게 올리고 비디오 실행 되면 다시 처음부터 시작하기 CheckNumber = 0
            if (ReNum == 0)
            {
                MainCamera.SceneNumber = 2;        //  조건에 ScnenNumber 추가, 실행 Point Metarial, Arrow 다 지우기 
                Invoke("ResetNumber",3);
                ReNum++;
            }
        }                                            
        if (WasherDoorClick.CheckNumber == 17 && ReNum == 1)
        {
            StartCoroutine(JSMessage());
            WasherDoorClick.CheckNumber = 18;
        }
    }

    public void MessageToJS()
    {
        string MessageToSend = "콘텐츠가 종료되었습니다.";
        Debug.Log("Sending message to JavaScript : " + MessageToSend);
#if UNITY_WEBGL && !UNITY_EDITOR
    ShowMessage(MessageToSend);
#endif
    }

    IEnumerator JSMessage()
    {      
        yield return new WaitForSeconds(3);
        MessageToJS();
    }

    void ResetNumber()
    {
        WasherDoorClick.CheckNumber = 0;
        Phone.SetActive(false);        
        LocalizedComponent.MainTextNumber = 1;
    }
}
