using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {

	public float xMin, xMax, zMin, zMax;

}

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public Boundary boundary;
	public float tilt;

	public float shootRate;
	public GameObject bolt;
	public Transform shotSpwan;
	private float nextFire;

	void Update() {

		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + shootRate;

			Instantiate (bolt, shotSpwan.position, shotSpwan.rotation);
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
		}
	}

	void FixedUpdate () {
		
		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveH, 0.0f, moveV);

		Rigidbody rb = GetComponent<Rigidbody> ();

		rb.velocity = movement * speed;

		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x,boundary.xMin,boundary.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z, boundary.zMin,boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
