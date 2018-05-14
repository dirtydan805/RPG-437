using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public Image currentHealthbar;
	public Text ratioText;

	public float hitPoint = 150;
	public float maxHitPoint = 150;

	public void Start()
	{
		UpdateHealthbar ();
		
	}
	public void UpdateHealthbar()
	{
		float ratio = hitPoint / maxHitPoint;
		currentHealthbar.rectTransform.localScale = new Vector3 (ratio, 1, 1);
		ratioText.text = (ratio*100).ToString() + '%';
	}
	public void TakeDamage(float damage)
	{
		
	}
	public void HealDamage(float heal)
	{
		
	}
}
