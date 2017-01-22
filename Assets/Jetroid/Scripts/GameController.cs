using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public int level = 1;


	[HideInInspector] public int score = 0;
	[HideInInspector] public int lemmingsNumber = 0;
	[HideInInspector] public int lemmingsSaved = 0;
	[HideInInspector] public int lemmingsDead = 0;

	// Use this for initialization
	void Start () {
		lemmingsNumber = level * 5;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
