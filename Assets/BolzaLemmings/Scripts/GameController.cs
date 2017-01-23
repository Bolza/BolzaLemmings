using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public int level = 1;
	public Text uiSpawned;
	public Text uiDead;
	public Text uiSaved;

	[HideInInspector] public int score = 0;
	[HideInInspector] public int lemmingsNumber = 0;
	[HideInInspector] public int lemmingsSpawned = 0;
	[HideInInspector] public int lemmingsSaved = 0;
	[HideInInspector] public int lemmingsDead = 0;
	[HideInInspector] public int selectedPower = -1;
	[HideInInspector] public GameObject selectedLemmings = null;

	// Use this for initialization
	void Start () {
		lemmingsNumber = level * 5;
	}

	// Update is called once per frame
	void Update () {}


	// POWERS
	public void ActivatePower(int power) {
		selectedPower = power;
	}

	public void setSelectedLemmings(GameObject o) {
		if (selectedLemmings) {
			selectedLemmings.GetComponent<Bolzings> ().SetSelectionState (false);
		}
		selectedLemmings = o;
	}

	// COUNTERS AND UI
	public void AddSpawned() {
		lemmingsSpawned++;
		uiSpawned.text = "Bolzings " + lemmingsSpawned;
	}
	public void RemoveSpawned() {
		lemmingsSpawned--;
		uiSpawned.text = "Bolzings " + lemmingsSpawned;
	}
	public void AddSaved() {
		lemmingsSaved++;
		uiSaved.text = "Saved " + lemmingsSaved;
	}
	public void DieLemming() {
		lemmingsDead++;
		uiDead.text = "Dead " + lemmingsDead;
	}

}
