using System.Collections;
using System;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
	public GameObject creature;
	private GameController game;
	private int countdown = 6;
	private TextMesh textMesh;
	// Use this for initialization
	void Start () {
		game = Camera.main.GetComponent<GameController> ();
		textMesh = GetComponentInChildren<TextMesh> ();
		StartCoroutine(InvokeMethod(Countdown, 1f, game.GetTotalLemmingsToSpawn() * countdown));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Countdown() {
		countdown--;
		textMesh.text = countdown.ToString();
		if (countdown == 0) {
			countdown = 6;
			create ();
		}
	}
	void create()
	{
		Instantiate (creature, transform.position, Quaternion.identity);
		game.AddSpawned ();
	}

	public IEnumerator InvokeMethod(Action method, float interval, int invokeCount)
	{
		for (int i = 0; i < invokeCount; i++)
		{
			method();
			yield return new WaitForSeconds(interval);
		}
	}
}
