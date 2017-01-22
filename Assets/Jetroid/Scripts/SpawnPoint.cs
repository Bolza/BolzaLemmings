using System.Collections;
using System;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
	public GameObject creature;
	private GameController game;
	// Use this for initialization
	void Start () {
		game = Camera.main.GetComponent<GameController> ();
		StartCoroutine(InvokeMethod(create, 1f, game.lemmingsNumber));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void create()
	{
		Instantiate (creature, transform.position, Quaternion.identity);
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
