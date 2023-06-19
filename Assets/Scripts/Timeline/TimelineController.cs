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
        // 아무 키나 누르면 gameObj set, timeline play 됨
        if(Input.anyKeyDown)
        {
            playabledirector.gameObject.SetActive(true);
            playabledirector.Play();
        }
    }
}
