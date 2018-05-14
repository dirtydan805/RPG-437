using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {


	//public float speed;
	//public float stoppingDistance;
	public float timeBetweenAttacks = 3f;     
	public int attackDamage = 3;               
	//GameObject player;                         
	PlayerHealth playerHealth;                  
	bool playerInRange;                        
	float timer; 
	public Transform player;
	static Animator anim;


	void Awake ()
	{
		
		//player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}
	// Use this for initialization
	void Start () {

		//target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		anim = GetComponent<Animator>();

	}
	void Update()
	{
		//if (Vector3.Distance (transform.position, target.position) > 3) {
		//	transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		//}

		timer += Time.deltaTime;
		if (Vector3.Distance (player.position, this.transform.position) < 10000) {
			Vector3 direction = player.position - this.transform.position;
			direction.y = 0;
			anim.SetBool ("isIdle", false);
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
			if (direction.magnitude > 5) {
				this.transform.Translate (0, 0, 0.06f);
				anim.SetBool ("isWalking", true);
				anim.SetBool ("isAttacking", false);
			} else {
				anim.SetBool ("isAttacking", true);
				anim.SetBool ("isWalking", false);

				if(timer >= timeBetweenAttacks)
				{
					Attack ();
				}
			}
		} else {
			anim.SetBool ("isIdle", true);
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isAttacking", false);
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
