using System.Collections;
using System;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
	public GameObject creature;
	private Transform tr;
	// Use this for initialization
	void Start () {
		tr = this.transform;
		StartCoroutine(InvokeMethod(create, 1f, 5));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void create()
	{
		Debug.logger.Log (tr.position);
		Instantiate (creature, tr.position, Quaternion.identity);
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
