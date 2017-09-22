using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using NUnit.Framework.Internal;
using System;
using System.ComponentModel;
using UnityStandardAssets.CrossPlatformInput;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, yMin, yMax;
}

[System.Serializable]
public class Weapon{
	public Sprite weapon;
	public GameObject bullet;
}

public class PlayerController : MonoBehaviour {


	public float currentHealth, armor, startingHealth = 130;
	public float speed = 5.0f, rotationSpeed = 5.0f;
	public Boundary boundary;
	public float fireRate;
	public GameObject shotSpawn;
	public Weapon[] weapons;
	public int countOfWeapon; // count of weapon for player at the current moment. 1-baze index
	public float lerpSpeed;
	public GameObject backgroundHealth;
	public AudioClip shotClip;


	private Rigidbody rb;
	private float movementInputValue, turnInputValue;
	bool fireInputValue, changeInputValue;
	private int weaponIndex;
	private float nextFire;
	private bool isDead, isChangingWeapon;
	private Vector3 radius;
	private SpriteRenderer spriteRender;
	private Color playerColor;


	void Start(){
		rb = GetComponent<Rigidbody>();
		isDead = false;
		isChangingWeapon = false;
		movementInputValue = 0f;
		turnInputValue = 0f;
		weaponIndex = 0;
		nextFire = 0;
		currentHealth = startingHealth;
		radius = new Vector3(startingHealth, startingHealth, 0.0f);
		backgroundHealth.transform.localScale = radius;
		spriteRender = GetComponent<SpriteRenderer>();

		playerColor = spriteRender.color;
		playerColor.a = 0.0f;
		spriteRender.color = playerColor;
	}

	void Update(){
		playerColor = spriteRender.color;
		playerColor.a = Mathf.Lerp (spriteRender.color.a, 1.0f, Time.deltaTime);
		spriteRender.color = playerColor;
	}

	void FixedUpdate (){
		backgroundHealth.transform.localScale = Vector3.Lerp(backgroundHealth.transform.localScale, radius, lerpSpeed * Time.deltaTime);

		movementInputValue = CrossPlatformInputManager.GetAxisRaw("Vertical");
		turnInputValue = CrossPlatformInputManager.GetAxisRaw("Horizontal");
		fireInputValue = CrossPlatformInputManager.GetButton("Fire");
		changeInputValue = CrossPlatformInputManager.GetButtonDown("Change");

		Move();
		Turn();
		Fire();
		ChangeWeapon();
	}


	private void Move (){
		Vector3 movement = transform.up * movementInputValue * speed * Time.deltaTime;
		transform.position += movement;

		Vector3 pos = new Vector3(
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
			0.0f
		);

		transform.position = pos;
	}


	private void Turn (){
		float turn = -turnInputValue * rotationSpeed * Time.deltaTime;
		transform.Rotate(Vector3.forward * turn);
	}


	private void Fire(){
		if (fireInputValue && (Time.time > nextFire)  && !isChangingWeapon){
			nextFire = Time.time + fireRate;
			Instantiate(weapons[weaponIndex].bullet, shotSpawn.transform.position, shotSpawn.transform.rotation);
			GetComponent<AudioSource>().PlayOneShot(shotClip);
		}
	}


	private void ChangeWeapon(){
		if (isChangingWeapon)
			return;

		if (changeInputValue){
			
			isChangingWeapon = true;

			weaponIndex += 1;

			if (weaponIndex == countOfWeapon) {
				weaponIndex = 0;
			}

			ChangeSprite();
		}

	}


	void ChangeSprite(){
		spriteRender.sprite = weapons[weaponIndex].weapon;
		isChangingWeapon = false;
	}


	void Death(){
		isDead = true;
		radius = Vector3.zero;
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().GameOver();
		GameObject.Destroy(gameObject);
	}


	public void TakeDamage (float amount)
	{
		if (isDead) {
			return;
		}
			
		amount *= armor;

		currentHealth-= amount;
		radius -= new Vector3(amount, amount, 1.0f);

		if (currentHealth <= 0) {
			Death();
		}
	}


	public void Refresh(){
		isDead = false;
		currentHealth = startingHealth;
		radius = new Vector3(startingHealth, startingHealth, 1.0f);
		backgroundHealth.transform.localScale = Vector3.zero;
		isChangingWeapon = false;
		weaponIndex = 0;
		nextFire = 0;
		transform.position = Vector3.zero;
	}
}
