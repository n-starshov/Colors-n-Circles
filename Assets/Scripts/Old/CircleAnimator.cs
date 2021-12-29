using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CircleAnimator : MonoBehaviour
{
    [SerializeField] private float _animationDuration;
    [SerializeField] private float _finalScale;
    [SerializeField] private CanvasGroup _canvasGroup;

    private Sequence _animation;

    private static List<CircleAnimator> _animators = new List<CircleAnimator>();

    private void Awake()
    {
        _animators.Add(this);
    }

    private void OnDestroy()
    {
        _animators.Remove(this);
    }

    private void RefreshTween()
    {
        _animation?.Kill();
        _animation ??= DOTween.Sequence();
    }

    public void OnAllScreen(Action onComplete = null)
    {
        RefreshTween();
        
        var finalScale = CncHelper.GetScreenDiagonal() + Mathf.Abs(transform.position.magnitude);
        _animation.Append(transform.DOScale(Vector3.one * finalScale, _animationDuration));
        _animation.Insert(_animationDuration / 5, _canvasGroup.DOFade(0, _animationDuration / 2));
        _animation.OnComplete(() => onComplete?.Invoke());
        _animation.Play();
    }

    private void Hide()
    {
        RefreshTween();

        _animation.Append(_canvasGroup.DOFade(0, _animationDuration / 2));
        _animation.Insert(_animationDuration / 5, transform.DOScale(Vector3.zero, _animationDuration));
        _animation.Play();
    }

    public void HideAllExceptMe()
    {
        foreach (var animator in _animators)
        {
            if(animator == this) continue;
            animator.Hide();
        }
    }
}