using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : CircleContainerBase
{
    public string sceneToOpen;
    public float lerpSpeed;
    public float finalScale;
    public GameObject textOnButton;

    private Vector3 stopScale;
    private bool isButtonOn;
    private Color transparencyColor;

    private void Start()
    {
        isButtonOn = false;
        stopScale = new Vector3(finalScale, finalScale, 1f);
        transparencyColor = textOnButton.GetComponent<Text>().color;
        transparencyColor.a = 0.0f;
    }

    private void Update()
    {
        // move animation in dotweenanimator
        if (isButtonOn)
        {
            transform.localScale = Vector3.Lerp(
                transform.localScale,
                Vector3.one * finalScale,
                lerpSpeed * Time.deltaTime
            );

            textOnButton.GetComponent<Text>().color = Color.Lerp(
                textOnButton.GetComponent<Text>().color,
                transparencyColor,
                lerpSpeed * Time.deltaTime * 10
            );
        }
    }

    public override void OnMouseDownView()
    {
        base.OnMouseDownView();
        isButtonOn = false;
    }

    public override void OnMouseUpAsButtonView()
    {
        isButtonOn = true;
        SceneManager.LoadScene(sceneToOpen);
    }
}