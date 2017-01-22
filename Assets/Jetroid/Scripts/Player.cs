using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	 
	public float speed = 150f;
	public Vector2 maxVelocity = new Vector2 (60, 100);
	public float jetSpeed = 200f;
	public bool standing = false;
	public float standingThreeshold = 4f;
	public float airSpeedMultiplier = .3f;

	private Rigidbody2D body;
	private SpriteRenderer renderer;
	private PlayerController controller;
	private Animator animator;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		renderer = GetComponent<SpriteRenderer> ();
		controller = GetComponent<PlayerController> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		var absVelX = Mathf.Abs (body.velocity.x);
		var absVelY = Mathf.Abs (body.velocity.y);

		if (absVelY <= standingThreeshold) {
			standing = true;
		} else {
			standing = false;
		}

		var forceX = 0f;
		var forceY = 0f;


		if (controller.moving.x != 0) {
			animator.SetInteger ("AnimState", 1);
			if (absVelX < maxVelocity.x) {
				var newSpeed = speed * controller.moving.x;
				forceX = standing ? newSpeed : newSpeed * airSpeedMultiplier;
			}
			renderer.flipX = controller.moving.x < 0;
		} else {
			animator.SetInteger ("AnimState", 0);
		}
		if (controller.moving.y != 0) {
			animator.SetInteger ("AnimState", 2);
			if (absVelY < maxVelocity.y) {
				forceY = jetSpeed * controller.moving.y;
			}
		}
		else if (absVelY > 0 && !standing) {
			animator.SetInteger ("AnimState", 3);
		}
		body.AddForce (new Vector2 (forceX, forceY));
	}
}
