using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detachable : Clickable {

	[HideInInspector ( )]
	public bool clicked = false;

	public bool onClick;
	
	int basesortinglayer;
	Rigidbody2D body;
	SpriteRenderer ren;

	void Start ( ) {
		basesortinglayer = 666;
		body = GetComponent<Rigidbody2D> ( );
		ren = GetComponent<SpriteRenderer> ( );
		basesortinglayer = ren.sortingOrder;
		grabbable = true;
		for (int i = 0; i < toUnlock.Count; i++) {
			toUnlock[i].gameObject.GetComponent<Detachable> ( ).enabled = false;
		}
	}

	public List<GameObject> toExpose = new List<GameObject> ( );
	bool exposed = false;
	void Expose ( ) {
		if (exposed) return;
		for (int i = 0; i < toExpose.Count; i++) {
			toExpose[i].gameObject.SetActive (true);
		}
		exposed = true;
	}

	public List<GameObject> toUnlock = new List<GameObject> ( );
	bool unlocked = false;
	void Unlock ( ) {
		if (unlocked) return;
		for (int i = 0; i < toUnlock.Count; i++) {
			// toUnlock[i].gameObject.SetActive (true);
			toUnlock[i].gameObject.GetComponent<Detachable> ( ).enabled = true;
		}
		unlocked = true;
	}
 
	public override void Click (GameObject subject) {
		if (!onClick) return;
		base.Click (subject);
		transform.SetParent (null);
		body.bodyType = RigidbodyType2D.Dynamic;
		// body.AddForceAtPosition (Vector2.up * 15f + Uhh.RandomVector (5f), subject.transform.position, ForceMode2D.Impulse);
		Expose ( );
		Unlock ( );
		ren.sortingOrder = 666;
		
	}

	public override void Hold (GameObject subject) {
		if (onClick) return;
		base.Hold (subject);
		transform.SetParent (null);
		body.bodyType = RigidbodyType2D.Dynamic;
		// body.AddForceAtPosition (Vector2.up * 15f + Uhh.RandomVector (5f), subject.transform.position, ForceMode2D.Impulse);
		Unlock ( );
		Expose ( );
	}

	public override void LetGo (GameObject subject) {
		base.LetGo (subject);
		// go back to start position ... 
		body.bodyType = RigidbodyType2D.Static;
	}

}