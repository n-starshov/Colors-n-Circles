using System;
using UnityEngine;

public class CircleContainerBase : MonoBehaviour
{
    public Action OnMouseDownEvent;
    public Action OnMouseUpEvent;

    protected virtual void OnMouseDown()
    {
        OnMouseDownEvent?.Invoke();
    }

    protected virtual void OnMouseUp()
    {
        OnMouseUpEvent?.Invoke();
    }

    protected virtual void OnMouseUpAsButton()
    {
        OnMouseUpEvent?.Invoke();
    }
}
