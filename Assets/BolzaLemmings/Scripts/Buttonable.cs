using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Exception;

public class Buttonable : MonoBehaviour {
	public GameObject connectedObject;
	void start() {
//		if (!connectedObject) throw new Exception("No connectedObject for Buttonable: " + name);
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.collider.name == "ButtonTop") {
			connectedObject.GetComponent<Door>().Trigger (name);
		}
	}	
}
