using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {


	//public float speed;
	//public float stoppingDistance;

	public Transform player;


	// Use this for initialization
	void Start () {

		//target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
	}
	void Update()
	{
		//if (Vector3.Distance (transform.position, target.position) > 3) {
		//	transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		//}

		if (Vector3.Distance (player.position, this.transform.position) < 100) 
		{
			Vector3 direction = player.position - this.transform.position;
			direction.y = 0;
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
			if (direction.magnitude > 5) 
			{
				this.transform.Translate (0, 0, 0.05f);
			}
		}
	}
	

}
