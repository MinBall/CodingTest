using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector playabledirector;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        // �ƹ� Ű�� ������ gameObj set, timeline play ��
        if(Input.anyKeyDown)
        {
            playabledirector.gameObject.SetActive(true);
            playabledirector.Play();
        }
    }
}
