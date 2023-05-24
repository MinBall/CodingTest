using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderButton : MonoBehaviour
{
    public UnityEvent onClick;

    private void OnMouseDown()
    {
        onClick?.Invoke();
    }
}
