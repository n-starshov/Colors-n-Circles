using System;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField] private CircleContainerBase _container;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Collider2D _collider;
    private RigidbodyConstraints2D _cachedConstraints;

    private void Awake()
    {
        
        _cachedConstraints = _rigidbody.constraints;
        // _container.OnMouseDownEvent += OnMouseDown;
        // _container.OnMouseUpEvent += OnMouseUp;
    }

    private void OnDestroy()
    {
        // _container.OnMouseDownEvent -= OnMouseDown;
        // _container.OnMouseUpEvent -= OnMouseUp;
    }

    private void OnMouseDown()
    {
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        _container.OnMouseDownView();
    }

    private void OnMouseUpAsButton()
    {
        _rigidbody.constraints = _cachedConstraints;
        _container.OnMouseUpAsButtonView();
    }
    
    
}