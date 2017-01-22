using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolzings : MonoBehaviour {
	private GameController game;
	public float speed = 10f;
	private Rigidbody2D body;
//	private bool standing = false;
	// Use this for initialization
	void Start () {
		game = Camera.main.GetComponent<GameController> ();
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		body.velocity = new Vector2 (transform.localScale.x * speed, body.velocity.y);
	}

	void OnMouseDown() {
		switch (game.activatedPower) {
		case 1:
			PowerBlock ();
			break;
		}
	}

	void OnCollisionEnter2D(Collision2D target) {
		if(target.collider.gameObject.tag == "Deadly") {
			GetComponent<Explode> ().OnExplode ();
			game.DieLemming ();
		}
	}

	void PowerBlock() {
		GetComponent<LookForward> ().needsCollision = false;
		speed = 0;
		this.gameObject.layer = LayerMask.NameToLayer ("Solid");
	}
}
