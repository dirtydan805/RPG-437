using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerShoot : MonoBehaviour {
	public playerWeapon weapon; 
	public ParticleSystem muzzleFlash;
	public GameObject impactEffect;
	public int gunDamage = 1;
	public float fireRate = .25f;
	public float weaponRange = 200f;
	public float hitForce = 100f;
	public Transform gunEnd;
	public int maxAmmo = 5;
	private int currentAmmo = 30;
	public float reloadTime = 3f;
	public Transform shotText;
	public Animator animator;

	private bool isReloading = false;

	public AudioSource shootSound;
	public AudioSource reloadSound;
	private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
	private LineRenderer laserLine;
	private float nextFire;

	[SerializeField]
	private Camera cam;
	[SerializeField]
	private LayerMask mask;

	void Start(){
		laserLine = GetComponent<LineRenderer> ();

		if(cam == null)
		{
			//throw error if no camera found
			Debug.LogError ("Player Shoot: No camera referenced!");
			this.enabled = false;
		}

		if (currentAmmo == -1) {
			currentAmmo = maxAmmo;
		}
	}

	void Update()
	{
		if (isReloading) {
			return;
		}
		currentAmmo = currentAmmo;
		muzzleFlash.Stop ();
		if(Input.GetButtonDown("Fire1") && Time.time > nextFire){
			//shoot when button pressed and 
			nextFire = Time.time + fireRate;
			currentAmmo--;
			shotText.GetComponent<Text> ().text = currentAmmo.ToString ();
			muzzleFlash.Play ();
			shootSound.Play();
			animator.SetBool ("Shooting", true);
			StartCoroutine (ShotEffect ());
			Vector3 rayOrigin = cam.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 0));
			Debug.DrawRay (rayOrigin, cam.transform.forward * weaponRange, Color.red);
			RaycastHit hit;
			laserLine.SetPosition (0, gunEnd.position);

			if (Physics.Raycast (rayOrigin, cam.transform.forward, out hit, weaponRange)) {
				laserLine.SetPosition (1, hit.point);
				Shootable health = hit.collider.GetComponent<Shootable> ();
				if (health != null) {
					health.Damage (gunDamage);
				}
				if (hit.rigidbody != null) {
					hit.rigidbody.AddForce (-hit.normal * hitForce);
				}
				GameObject impactGO  = Instantiate(impactEffect,hit.point,Quaternion.LookRotation(hit.normal));
				Destroy (impactGO, 1f);
			}
			
			else{
				laserLine.SetPosition (1, rayOrigin + (cam.transform.forward * weaponRange));
			}
			animator.SetBool ("Shooting", false);
		}
	
//		if (currentAmmo <= 0) {
//			StartCoroutine (Reload ());
//			return;
//		}
		if(currentAmmo <= 0){
			StartCoroutine (Reload ());
			return;
			}
		if(Input.GetButtonUp("Fire2") && currentAmmo <30){
			StartCoroutine (Reload ());
			return;
		}
	}
		
	IEnumerator Reload(){
		isReloading = true;
		reloadSound.Play();
		Debug.Log("Reloading...");
		animator.SetBool ("Reloading", true);
		yield return new WaitForSeconds (reloadTime - .25f);
		animator.SetBool ("Reloading", false);
		yield return new WaitForSeconds (.25f);
		currentAmmo = maxAmmo;
		isReloading = false;
	}

	private IEnumerator ShotEffect()
	{

		laserLine.enabled = true;
		yield return shotDuration;
		laserLine.enabled = false;
	}

}
