using System;
using ModestTree.Util;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public interface ICircleObject
{
    float Radius { get; }
    Transform CenterPosition { get; }
}

public class ButtonView : MonoBehaviour, ICircleObject
{
    public float Radius { get; }
    public Transform CenterPosition { get; } 

    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _label;

    private readonly CompositeDisposable _disposables = new CompositeDisposable();

    private void Start()
    {
        var model = new ButtonModel(
            1f,
            "Hello, world",
            () => Debug.Log("Log onClick")
        );
        SetModel(model);
    }

    public void SetModel(ButtonModel model)
    {
        _disposables.Clear();
        _button.OnClickAsObservable()
            .Subscribe(_ => model.OnClick())
            .AddTo(_disposables);
        _label.text = model.Text;
    }

    private void OnDestroy()
    {
        _disposables.Dispose();
    }
}

public class ButtonModel
{
    public readonly float Radius;
    public readonly string Text;
    public readonly Action OnClick;

    public ButtonModel(float radius, string text, Action onClick)
    {
        Radius = radius;
        Text = text;
        OnClick = onClick;
    }
}
