using UnityEngine;
using System;

public class PlayerController : MonoBehaviour 
{

	public float speed = 800.0f;
	public float jumpSpeed = 100.0f;
	private bool onGround = false;
	Rigidbody rb;


	void FixedUpdate()
	{
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		rb=GetComponent<Rigidbody>();
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);

		if (Input.GetKeyDown("space"))
		{
			rb.AddForce(Vector3.up * jumpSpeed);
		}
	}
	void OnCollisionStay ()
	{
		onGround = true;
	}
}