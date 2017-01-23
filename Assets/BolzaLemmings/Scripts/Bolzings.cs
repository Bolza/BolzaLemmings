using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bolzings : MonoBehaviour {
	public float speed = 20f;
	public GameObject blockToBuild = null;
	public GameObject selectedLed = null;
	public GameObject bomb = null;

	private GameController game;
	private Rigidbody2D body;
	private Renderer urenderer;
	private bool isSelected = false;
	private int activePower = -1;
//	private bool standing = false;
	// Use this for initialization
	void Start () {
		game = Camera.main.GetComponent<GameController> ();
		body = GetComponent<Rigidbody2D> ();
		urenderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		body.velocity = new Vector2 (transform.localScale.x * speed, body.velocity.y);
	}

	void OnMouseDown() {
		if (game.selectedPower > -1) {
			ActivatePower ();
		} else {
			ToggleSelection ();
		}
	}
	public void ActivatePower() {
		activePower = game.selectedPower;
		switch (game.selectedPower) {
		case 1:
			PowerBlock ();
			break;
		case 2:
			PowerBuild ();
			break;
		case 3:
			PowerBomb ();
			break;
		}
	}

	private void ToggleSelection() {
		SetSelectionState (!isSelected);
		if (isSelected) {
			game.setSelectedLemmings(this.gameObject);
		} 
		else {
			game.setSelectedLemmings(null);
		}
	}
	public void SetSelectionState(bool sel) {
		isSelected = sel;
		selectedLed.GetComponent<Renderer> ().enabled = isSelected;
	}

	void OnCollisionEnter2D(Collision2D target) {
		if(target.collider.gameObject.tag == "Deadly") {
			GetComponent<Explode> ().OnExplode ();
			game.DieLemming ();
		}
	}


//	POWERS
	void PowerBlock(bool off = false) {
		GetComponent<LookForward> ().needsCollision = false;
		speed = 0;
		this.gameObject.layer = LayerMask.NameToLayer ("Solid");
	}

	void PowerBuild(bool off = false) {
		speed = 10f;
		StartCoroutine(InvokeMethod(BuildBlock, 1.2f, 100));
	}
	void BuildBlock()
	{
		float buildX = transform.position.x + urenderer.bounds.size.x * transform.localScale.x;
		float buildY = transform.position.y - (urenderer.bounds.size.y / 2);
		Vector3 newPos = new Vector3 (buildX, buildY , transform.position.z);
		Instantiate (blockToBuild, newPos, Quaternion.identity);
	}

	void PowerBomb(bool off = false) {
//		speed = 20f;
		bomb.GetComponent<Renderer> ().enabled = true;
//		StartCoroutine(InvokeMethod(BuildBlock, 1.2f, 100));
	}

//	VARIOUS UTILITY
	public IEnumerator InvokeMethod(Action method, float interval, int invokeCount)
	{
		for (int i = 0; i < invokeCount; i++)
		{
			method();
			yield return new WaitForSeconds(interval);
		}
	}
}
