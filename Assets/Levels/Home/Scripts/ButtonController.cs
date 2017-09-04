using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {


	public String sceneToOpen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnMouseDown(){
		try {
			SceneManager.LoadScene(sceneToOpen);
		} catch {
			
		}
	}
}
