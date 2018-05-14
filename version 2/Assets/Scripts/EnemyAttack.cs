using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;     
	public int attackDamage = 10;               
	GameObject player;                         
	PlayerHealth playerHealth;                  
	bool playerInRange;                        
	float timer;                               


	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}





	void Update ()
	{
		timer += Time.deltaTime;

		if((timer >= timeBetweenAttacks))
		{
			Attack ();
		}
			
	}


	void Attack ()
	{
		timer = 0f;

		if(playerHealth.currentHealth > 0)
		{
			playerHealth.TakeDamage (attackDamage);
		}
	}
}