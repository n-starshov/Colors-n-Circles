using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class RandomMover : MonoBehaviour {


	public float speed = 5.0f;
	public Boundary randomPosition;

	private Rigidbody rb;


	void Start () {
		rb = GetComponent<Rigidbody>();
		Vector2 randomDirection = new Vector2(
			Random.Range(-speed, speed), 
			Random.Range(-speed, speed)
		); 
		rb.velocity = randomDirection;
	}


	void OnTriggerEnter(Collider other){
		Debug.Log("Circle Collide!");
		if ((other.gameObject.name == "TopBound") || (other.gameObject.name == "BottomBound")) {
			Vector3 vel = rb.velocity;
			vel.y *= -1.0f;
			rb.velocity = vel;
		} else {
			if ((other.gameObject.name == "LeftBound") || (other.gameObject.name == "RightBound")) {
				Vector3 vel = rb.velocity;
				vel.x *= -1.0f;
				rb.velocity = vel;
			} else {
				rb.velocity *= -1;
			} 
		}	
	}
}
