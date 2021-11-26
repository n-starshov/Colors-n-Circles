using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : CircleContainerBase
{
    [SerializeField] private  string sceneToOpen;
    [SerializeField] private  GameObject textOnButton;
    [SerializeField] private CircleAnimator _animator;

    private Vector3 stopScale;
    private bool isButtonOn;
    private Color transparencyColor;

    private void Start()
    {
        isButtonOn = false;
        // stopScale = new Vector3(_finalScale, _finalScale, 1f);
        transparencyColor = textOnButton.GetComponent<Text>().color;
        transparencyColor.a = 0.0f;
    }

    private void Update()
    {
        // move animation in dotweenanimator
        // if (isButtonOn)
        // {
        //     transform.localScale = Vector3.Lerp(
        //         transform.localScale,
        //         Vector3.one * _finalScale,
        //         lerpSpeed * Time.deltaTime
        //     );
        //
        //     textOnButton.GetComponent<Text>().color = Color.Lerp(
        //         textOnButton.GetComponent<Text>().color,
        //         transparencyColor,
        //         lerpSpeed * Time.deltaTime * 10
        //     );
        // }
    }

    public override void OnMouseDownView()
    {
        base.OnMouseDownView();
        isButtonOn = false;
    }

    public override void OnMouseUpAsButtonView()
    {
        isButtonOn = true;
        _animator.OnAllScreen(OnOpenAnimationComplete);
    }

    private void OnOpenAnimationComplete()
    {
        SceneManager.LoadScene(sceneToOpen);
    }
}