using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : Clickable {

	Rigidbody2D body;
	SpriteRenderer ren;

	void Start ( ) {
		body = GetComponent<Rigidbody2D> ( );
		ren = GetComponent<SpriteRenderer> ( );
		grabbable = true;
	}

	public override void Click (GameObject subject) {
		base.Click (subject);
		transform.SetParent (null);
		body.bodyType = RigidbodyType2D.Dynamic;
		body.AddForceAtPosition (Vector2.up * 15f + Uhh.RandomVector (5f), subject.transform.position, ForceMode2D.Impulse);
		ren.sortingOrder = Random.Range (25, 55);
	}

	public override void LetGo (GameObject subject) {
		base.LetGo (subject);
		// go back to start position ... 
		body.bodyType = RigidbodyType2D.Static;
	}

}