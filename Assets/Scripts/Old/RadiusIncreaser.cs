using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadiusIncreaser : MonoBehaviour {


	public Vector3 radiusScale;
	public Text label;
	public float lerpSpeed;

	private bool isScaled;

	// Use this for initialization
	void Start () {
		transform.localScale = Vector3.zero;

		Color color = label.color;
		color.a = 0;
		label.color = color;

		isScaled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isScaled)
			return;
		
		transform.localScale = Vector3.Lerp(
			transform.localScale, 
			radiusScale,
			lerpSpeed * Time.deltaTime * 15
		);

		Color color = label.color;
		color.a = Mathf.Lerp(
			color.a, 
			1.0f, 
			lerpSpeed * Time.deltaTime
		);
		label.color = color;

		if (color.a >= 0.8f){
			transform.localScale = radiusScale;

			color.a = 1;
			label.color = color;

			isScaled = true;

		}
	}
}
