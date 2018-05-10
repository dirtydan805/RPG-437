using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {


	public float speed;
	public float stoppingDistance;

	private Transform target;


	// Use this for initialization
	void Start () {

		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
	}
	void Update()
	{
		if (Vector3.Distance (transform.position, target.position) > 3) {
			transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		}
	}
	

}
