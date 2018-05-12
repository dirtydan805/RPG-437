using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public Image currentHealthbar;
	public Text ratioText;

	private float hitPoint = 150;
	private float maxHitPoint = 150;

	private void Start()
	{
		UpdateHealthbar ();
		
	}
	private void UpdateHealthbar()
	{
		float ratio = hitPoint / maxHitPoint;
		currentHealthbar.rectTransform.localScale = new Vector3 (ratio, 1, 1);
		ratioText.text = (ratio*100).ToString() + '%';
	}
	private void TakeDamage(float damage)
	{
		
	}
	private void HealDamage(float heal)
	{
		
	}
}
