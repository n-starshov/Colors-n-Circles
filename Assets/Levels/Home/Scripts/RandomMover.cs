using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMover : MonoBehaviour {


	public float speed = 5.0f;

	private Rigidbody rb;
	private Vector3 randomDirection;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.velocity = new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
