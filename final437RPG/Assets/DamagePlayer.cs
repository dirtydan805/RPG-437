using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

	public int playerHealth = 30;
	int damage = 10;

	// Use this for initialization
	void Start () {
		print (playerHealth);
	}
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "enemyDong") {
			playerHealth -= damage;
			print (" Just hit" + playerHealth);
		}
	}

}
