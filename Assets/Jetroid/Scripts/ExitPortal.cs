using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExitPortal : MonoBehaviour {
	private GameController game;
	// Use this for initialization
	void Start () {
		game = Camera.main.GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Lemming")) {
			game.AddSaved ();
			Destroy (other.gameObject);
		}
	}
}
