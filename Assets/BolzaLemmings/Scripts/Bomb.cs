using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
	private int countdown = 6;
	public TextMesh textMesh;
	public GameObject explosion;
	// Use this for initialization
	void Awake () {
		StartCoroutine(InvokeMethod(TriggerBomb, 1f, countdown));
	}	
	
	// Update is called once per frame
	void TriggerBomb () {
		countdown--;
		textMesh.text = countdown.ToString();
		if (countdown == 0) {
			ExplosionDamage ();
			Destroy (gameObject);
			Instantiate (explosion, transform.position, Quaternion.identity);
			Destroy (transform.parent.gameObject);
		}
	}

	void ExplosionDamage() {
		CircleCollider2D ren = GetComponent<CircleCollider2D> ();
		float radius = ren.radius;
		Vector3 center = transform.position + new Vector3 (ren.offset.x, ren.offset.y, 0);

		Debug.DrawLine(center, new Vector3 (center.x+radius, center.y-radius, center.z),Color.red, 100f);
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius, 1 << LayerMask.NameToLayer("Solid"));
		int i = 0;
		while (i < hitColliders.Length) {
			Destroy (hitColliders [i].gameObject);
//			Debug.logger.Log (hitColliders [i].name);
			i++;
		}
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
