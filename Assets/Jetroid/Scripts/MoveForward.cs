using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {
	public float speed = 10f;
	private Rigidbody2D body;
	private bool standing = false;

	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		body.velocity = new Vector2 (transform.localScale.x * speed, body.velocity.y);
	}
}
