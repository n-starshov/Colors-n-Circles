using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;

public class BulletController : MonoBehaviour {


	public float speed = 5.0f;
	public string tagColour;
	public int damage;


	void Start(){
//		isKinematic = false;
	}


	void Update () {
		Vector3 movement = transform.up * speed;
		transform.position += movement * Time.deltaTime;
	}
		

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player"){
			return;
		}
		if (other.gameObject.CompareTag(tagColour)) {
			other.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().IncreaseTextScore();
			Destroy(gameObject);
		} else {
			Destroy(gameObject);
		}
	}
}
