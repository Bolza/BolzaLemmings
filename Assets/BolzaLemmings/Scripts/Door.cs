using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	public bool isOpen = false;
	public bool canBeClosed = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Trigger(string name) {
		if (canBeClosed) {
			isOpen = !isOpen; 
		} else {
			isOpen = true;
		}
	}
}
