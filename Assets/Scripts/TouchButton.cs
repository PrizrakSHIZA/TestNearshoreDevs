using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent OnPinterDown;
    public UnityEvent OnPinterUp;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPinterDown.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPinterUp.Invoke();
    }
}
