using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour {

	void Update () {

		transform.Rotate (new Vector3 (0,0, 90) * Time.deltaTime * 1);
		transform.Translate (new Vector3 (0,  15, Mathf.Cos (Time.time * 16)) * Time.deltaTime);
	}
}
