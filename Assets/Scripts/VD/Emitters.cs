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
    public void OnTimelinePlay() // Ÿ�Ӷ��� �ӵ��� 1�� �����Ͽ� Play()�� ������ ȿ���� �ִ� ���
    {
        timeline.playableGraph.GetRootPlayable(0).SetSpeed(1f);
    }
    public void OnTimelineStop() // Ÿ�Ӷ��� �ӵ��� 0���� �����Ͽ� Stop()�� ������ ȿ���� �ִ� ���
    {
        timeline.playableGraph.GetRootPlayable(0).SetSpeed(0f);
    }
    public void OnTimelineSpeed(float speed)
    {
        timeline.playableGraph.GetRootPlayable(0).SetSpeed(speed);
    }
    public void Set_EmitterEvent() // UnityEvent Ÿ�Կ� ���, Signal Emitter(= Signal Asset)�� Reaction �̺�Ʈ�� �ִ� ���
    {
        UnityEvent eventContainer = new UnityEvent();
        eventContainer.AddListener(() =>
        {
            // �̺�Ʈ �� ��ġ            
        });
        receiver.AddReaction(signal, eventContainer);
    }
}