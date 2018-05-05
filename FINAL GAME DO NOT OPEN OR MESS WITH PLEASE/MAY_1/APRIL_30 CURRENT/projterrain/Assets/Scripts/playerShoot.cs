using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerShoot : MonoBehaviour {
	public playerWeapon weapon; 
	public ParticleSystem muzzleFlash;
	public int gunDamage = 1;
	public float fireRate = .25f;
	public float weaponRange = 200f;
	public float hitForce = 100f;
	public Transform gunEnd;
	public int maxAmmo = 5;
	private int currentAmmo;
	public float reloadTime = 1f;
	public Transform shotText;

	private bool isReloading = false;

	public AudioSource shootSound;
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
		muzzleFlash.Stop ();
		if(Input.GetButtonDown("Fire1") && Time.time > nextFire){
			//shoot when button pressed and 
			nextFire = Time.time + fireRate;
			currentAmmo--;
			shotText.GetComponent<Text> ().text = currentAmmo.ToString ();
			muzzleFlash.Play ();
			shootSound.Play();
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
			}
			
			else{
				laserLine.SetPosition (1, rayOrigin + (cam.transform.forward * weaponRange));
			}
		}
	
		if (currentAmmo <= 0) {
			StartCoroutine (Reload ());
			return;
		}
	}
		
	IEnumerator Reload(){
		isReloading = true;
		Debug.Log("Reloading...");
		yield return new WaitForSeconds (reloadTime);
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
