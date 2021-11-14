using UnityEngine;
using Zenject;

public class ButtonCircle : MonoBehaviour, ICircleObject
{
    public float Radius { get; }
    public Transform CenterPosition { get; }
    
    private CircleButtonService _circleButtonService;

    [Inject]
    public void SetDependencies(CircleButtonService circleButtonService)
    {
        _circleButtonService = circleButtonService;
    }
}