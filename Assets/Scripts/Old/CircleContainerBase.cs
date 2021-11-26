using System;
using UnityEngine;

public class CircleContainerBase : MonoBehaviour
{
    // public Action OnMouseDownEvent;
    // public Action OnMouseUpEvent;

    public virtual void OnMouseDownView()
    {
        // OnMouseDownEvent?.Invoke();
    }

    protected virtual void OnMouseUp()
    {
        // OnMouseUpEvent?.Invoke();
    }

    public virtual void OnMouseUpAsButtonView()
    {
        // OnMouseUpEvent?.Invoke();
    }
}
