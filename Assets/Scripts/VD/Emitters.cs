using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.Timeline;
public class Emitters : MonoBehaviour
{
    public PlayableDirector timeline;
    public SignalReceiver receiver;
    public SignalAsset signal;
    public void OnTimelinePlay() // 타임라인 속도를 1로 변경하여 Play()와 동일한 효과를 주는 기능
    {
        timeline.playableGraph.GetRootPlayable(0).SetSpeed(1f);
    }
    public void OnTimelineStop() // 타임라인 속도를 0으로 변경하여 Stop()과 동일한 효과를 주는 기능
    {
        timeline.playableGraph.GetRootPlayable(0).SetSpeed(0f);
    }
    public void OnTimelineSpeed(float speed)
    {
        timeline.playableGraph.GetRootPlayable(0).SetSpeed(speed);
    }
    public void Set_EmitterEvent() // UnityEvent 타입에 담아, Signal Emitter(= Signal Asset)에 Reaction 이벤트를 넣는 방법
    {
        UnityEvent eventContainer = new UnityEvent();
        eventContainer.AddListener(() =>
        {
            // 이벤트 들어갈 위치            
        });
        receiver.AddReaction(signal, eventContainer);
    }
}