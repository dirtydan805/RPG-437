using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour {
	public Transform player;
	public Transform head;
	Animator anim;
	bool pursuing = false;

	public AudioSource attackSound;
	public AudioSource notIdle;
	public AudioSource moveSound;
	//ok 
	string state = "patrol";
	public GameObject[] waypoint;
	int currentWP = 0;
	float rotSpeed = 0.2f;
	float speed = 1.5f;
	float accuracyWP = 5.0f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = player.position - this.transform.position;
		direction.y = 0;

		float angle = Vector3.Angle (direction, head.up);

		if (state == "patrol" && waypoint.Length > 0) {
			anim.SetBool ("isIdle", false);
			anim.SetBool ("isWalking", true);
			if (Vector3.Distance (waypoint [currentWP].transform.position, transform.position) < accuracyWP) {
				currentWP++;
				if (currentWP >= waypoint.Length) {
					currentWP = 0;
				}
			}
		
			//rotate towards waypoint

			direction = waypoint [currentWP].transform.position - transform.position;
			this.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotSpeed * Time.deltaTime);
			this.transform.Translate (0, 0, Time.deltaTime * speed);
		}

		if (Vector3.Distance (player.position, this.transform.position) < 15 && (angle < 30 || state == "pursuing")) 
		{
			//notIdle.Play();
			state = "pursuing";
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction),rotSpeed * Time.deltaTime);

			//anim.SetBool ("isIdle", false);
		
			if (direction.magnitude > 5) 
			{
				this.transform.Translate (0, 0, Time.deltaTime * speed);
				notIdle.Play();
				anim.SetBool ("isWalking", true);
				moveSound.Play ();
				anim.SetBool ("isAttacking", false);
			} 
			else {
				anim.SetBool ("isAttacking", true);
				anim.SetBool ("isWalking", false);
				attackSound.Play();
			}
		} else {
			//anim.SetBool ("isIdle", true);
			anim.SetBool ("isWalking", true);
			anim.SetBool ("isAttacking", false);
			state = "patrol";
		}
	}
}
