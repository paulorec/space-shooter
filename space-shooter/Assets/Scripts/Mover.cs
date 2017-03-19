using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed;

	void Start () {
		
		Rigidbody rb = GetComponent<Rigidbody> ();

		rb.velocity = transform.forward * speed;

	}
}
