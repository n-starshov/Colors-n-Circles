using System;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField] private CircleContainerBase _container;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private bool _stopSimOnClick;
    private RigidbodyConstraints2D _cachedConstraints;

    private void Awake()
    {
        _cachedConstraints = _rigidbody.constraints;
    }

    private void OnMouseDown()
    {
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        _container.OnMouseDownView();
    }

    private void OnMouseUp()
    {
        _rigidbody.constraints = _cachedConstraints;
    }

    private void OnMouseUpAsButton()
    {
        _container.OnMouseUpAsButtonView();
        if(_stopSimOnClick)
            _rigidbody.simulated = false;
    }
    
    
}