using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAttack : MonoBehaviour {


	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;


	GameObject player;
	PlayerController playerController;
	bool playerInRange;
	float timer;


	void Awake (){
		player = GameObject.FindGameObjectWithTag("Player");
		playerController = player.GetComponent <PlayerController> ();
		if (player == null) {
			Debug.Log("Player Not Found!!!!");
		}
	}


	void OnTriggerEnter (Collider other){
		if(other.gameObject == player){
			playerInRange = true;
		}
	}


	void OnTriggerExit(Collider other){
		if(other.gameObject == player){
			playerInRange = false;
		}
	}


	void Update (){
		timer += Time.deltaTime;
		if(timer >= timeBetweenAttacks && playerInRange){
			playerController.TakeDamage(attackDamage);
			timer = 0f;
		}
	}
}
