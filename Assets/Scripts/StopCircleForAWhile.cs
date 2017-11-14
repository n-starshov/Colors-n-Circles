using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCircleForAWhile : MonoBehaviour {


	public float stopTime;

	private Vector3 oldVelocity;
	private Rigidbody rb;
	private float timer;

	// Use this for initialization
	void Start(){
		oldVelocity = GetComponent<Rigidbody>().velocity;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update(){
		timer += Time.deltaTime;
		if (timer >= stopTime) {
			GetComponent<Rigidbody>().velocity = oldVelocity;
			this.enabled = false;
		}

	}
}
