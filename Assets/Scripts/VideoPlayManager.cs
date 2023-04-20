using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Runtime.InteropServices;

public class VideoPlayManager : MonoBehaviour
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
        //video = GetComponent<VideoPlayer>();
        video.url = System.IO.Path.Combine(Application.streamingAssetsPath, "SampleClip.mp4");
    }
    void Update()
    {
        if (WasherDoorClick.CheckNumber == 16)
        {
            Phone.SetActive(true);
            Invoke("VideoPlayer", 0.5f);
            video.Play();
            WasherDoorClick.CheckNumber = 17;
            if (ReNum == 0)
            {
                 Invoke("ResetNumber",4f);
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
        video.Pause();
    }

    void ResetNumber()
    {
        video.Stop();
        WasherDoorClick.CheckNumber = 0;
        PhoneAimator.SetTrigger("Idle");
        LocalizedComponent.MainTextNumber = 1;
        ReNum++;
        CameraMoveComponent.SceneNumber = 2;
        
    }

    void VideoPlayer()
    {
        PhoneAimator.SetTrigger("PhoneMove");
    }
}
