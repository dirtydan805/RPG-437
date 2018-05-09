﻿//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class enemychase : MonoBehaviour {

	public Transform player;
	static Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () 
	{
		Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		if(Vector3.Distance(player.position, this.transform.position) < 15 && angle<30)
		{
			
			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
				Quaternion.LookRotation(direction), 0.1f);

			anim.SetBool("isIdle",false);
			if(direction.magnitude > 10)
			{
				
				this.transform.Translate(0,0,0.05f);
				anim.SetBool("isRunning",true);
				anim.SetBool("isAttacking",false);
			}
			else
			{
					
				anim.SetBool("isAttacking",true);
				anim.SetBool("isRunning",false);
			
			}

		}
		else 
		{
			anim.SetBool("isIdle", true);
			anim.SetBool("isAttacking", false);
			anim.SetBool("isRunning", false);
		}

	}
}