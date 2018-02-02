using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
private RigidBody rb;

	void Start()
	{
		rb = GetComponent <RigidBody>();
	}
	
	void Update()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
	
		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);
		
		rb.AddForce (movement);
	}
}

