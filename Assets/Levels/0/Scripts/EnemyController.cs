using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
//using NUnit.Framework.Internal.Filters;
using System.Threading;

public class EnemyController : MonoBehaviour {


	public float speed, attack, attackRate;
	public int startingHealth;
	public int currentHealth;
	public float lerpSpeed;
	public AudioClip deathEnemyClip;


//	private Rigidbody2D rb;
	private GameObject player, gameController;
	private bool isDead, playerInRange;
	private PlayerController playerController;
	private Transform playerTransform;
	private GameController gameControllerScript;
	private Vector3 radius;
	private float timer;

	// Use this for initialization
	void Start(){

//		rb = GetComponent<Rigidbody2D>();

		player = GameObject.FindGameObjectWithTag("Player");
		playerController = player.GetComponent<PlayerController>();
		playerTransform = player.GetComponent<Transform>();

		gameController = GameObject.FindGameObjectWithTag("GameController");
		gameControllerScript = gameController.GetComponent<GameController>();

		currentHealth = startingHealth;
		radius = new Vector3(startingHealth, startingHealth, 1.0f);
		timer = 0.0f;
		playerInRange = false;
		isDead = false;

	}

	void FixedUpdate () {
		// update self radius
		if (isDead) {
			if (transform.localScale == Vector3.zero) {
				Destroy(gameObject);
			}
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, lerpSpeed * Time.deltaTime * 4);
		}else{
			transform.localScale = Vector3.Lerp(transform.localScale, radius, lerpSpeed * Time.deltaTime);
		}

		float offset = 1.5f;
		if (Vector3.Distance(transform.position, playerTransform.position) > offset) {
			transform.position = Vector3.Lerp(transform.position, playerTransform.position, speed * Time.deltaTime);
		}

//		rb.AddForce(Random.insideUnitSpheres);

		timer += Time.deltaTime;
		if (playerInRange && timer >= attackRate) {
			Attack();
			timer = 0.0f;
		}

	}


	void Death(){
		isDead = true;
		GetComponent<AudioSource>().PlayOneShot(deathEnemyClip);
		gameControllerScript.spawnEnemyRandomly();	
	}


	void Attack(){
		playerController.TakeDamage(attack);
	}


	public void TakeDamage (int amount)
	{
		if (isDead)
			return;

		currentHealth -= amount;
		radius -= new Vector3(amount, amount, 1.0f);

		if (currentHealth <= 0){
			Death();
		}
	}
}
