using System;
using DG.Tweening;
using UnityEngine;

public class CircleAnimator : MonoBehaviour
{
    [SerializeField] private float _animationDuration;
    [SerializeField] private float _finalScale;

    private Sequence _animation;

    private void RefreshTween()
    {
        _animation?.Kill();
        _animation ??= DOTween.Sequence();
    }

    public void OnAllScreen(Action onComplete = null)
    {
        RefreshTween();
        
        _animation.Append(transform.DOScale(Vector3.one * _finalScale, _animationDuration));
        _animation.OnComplete(() => onComplete?.Invoke());
        _animation.Play();
    }
}
