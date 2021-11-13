using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public string sceneToOpen;
    public float lerpSpeed;
    public Vector3 finalScale;
    public GameObject textOnButton;

    private Vector3 stopScale;
    private bool isButtonOn;
    private Color transparencyColor;

    private void Start()
    {
        isButtonOn = false;
        stopScale = new Vector3(finalScale.x * 0.75f, finalScale.y * 0.75f, 1);
        transparencyColor = textOnButton.GetComponent<Text>().color;
        transparencyColor.a = 0.0f;
    }

    private void Update()
    {
        if (isButtonOn)
        {
            transform.localScale = Vector3.Lerp(
                transform.localScale,
                finalScale,
                lerpSpeed * Time.deltaTime
            );

            textOnButton.GetComponent<Text>().color = Color.Lerp(
                textOnButton.GetComponent<Text>().color,
                transparencyColor,
                lerpSpeed * Time.deltaTime * 10
            );


            if (transform.localScale.x >= stopScale.x) isButtonOn = false;
            if (!isButtonOn)
                try
                {
                    SceneManager.LoadScene(sceneToOpen);
                }
                catch (Exception e)
                {
                    Debug.Log(e.StackTrace);
                }
        }
    }

    private void OnMouseDown()
    {
        isButtonOn = true;
        var pos = transform.position;
        pos.z = 5;
        transform.position = pos;
    }
}
