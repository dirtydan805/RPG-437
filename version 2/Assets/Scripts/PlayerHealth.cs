using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;                           
	public int currentHealth;                                  
	public Slider healthSlider;                                 
	public Image damageImage;                                  
	//public AudioClip deathClip;                               
	public float flashSpeed = 5f;                              
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     
	bool isDead;                                                
	bool damaged;   
	public int sceneAfterDeath;


	float healthTimer = 0.0f;
	bool healthShouldRespawn = false;
	public GameObject healthBottle;

	void Awake ()
	{

//		anim = GetComponent  ();
//		playerAudio = GetComponent  ();
//		playerMovement = GetComponent  ();
//		playerShooting = GetComponentInChildren  ();

		// Set the initial health of the player.
		currentHealth = startingHealth;
	}


	void Update ()
	{
		if(damaged)
		{
			damageImage.color = flashColour;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
			
		damaged = false;


		if (healthShouldRespawn) 
		{
			healthTimer += Time.deltaTime;
			if (healthTimer > 5.0f) 
			{
				healthBottle.gameObject.SetActive (true);
				healthTimer = 0.0f;
			}
		}
	}


	public void TakeDamage (int amount)
	{
		damaged = true;

		currentHealth -= amount;

		healthSlider.value = currentHealth;

		//playerAudio.Play ();

		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}
	public void HealDamage(int amount){
		currentHealth += amount;
	}

	void Death ()
	{
		//isDead = true;
		//playerAudio.clip = deathClip;
		//playerAudio.Play ();
		SceneManager.LoadScene(sceneAfterDeath);

	} 

	void OnTriggerEnter(Collider item)
	{
		if (item.gameObject.tag == "PlayerHealthBottle") 
		{
			if (currentHealth < 100) 
			{
				currentHealth = currentHealth + 40;
				item.gameObject.SetActive (false);
				healthShouldRespawn = true;
			}
		}
	}
}