﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour {
	public int currentHealth = 100;

	public void Damage(int damageAmount)
	{
		currentHealth -= damageAmount;
		if(currentHealth <=0)
		{
			gameObject.SetActive (false);
	}

}
}
