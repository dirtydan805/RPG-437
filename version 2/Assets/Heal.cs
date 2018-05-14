using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour {
	PlayerHealth playerHealth; 
	public int health = 10;
	public Transform player;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		print (health);
	}

	void OnTriggerEnter(){
		playerHealth.HealDamage(health);
		gameObject.SetActive (false);
	}
}
