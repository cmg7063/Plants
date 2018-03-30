using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerScript : MonoBehaviour {
	private bool hurtPlayer;

	// Use this for initialization
	void Start () {
		hurtPlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool getHurtPlayer() {
		return hurtPlayer;
	}

	public void toggleHurtPlayer() {
		hurtPlayer = !hurtPlayer;
	}
}
