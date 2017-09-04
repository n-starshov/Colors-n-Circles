using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMover : MonoBehaviour {


	public float speed = 5.0f;

	private Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
		Vector3 randomDirection = Random.insideUnitSphere;
		randomDirection.z = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
