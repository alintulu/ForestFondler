using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swaying : MonoBehaviour {

	public Vector2 POS { get { return transform.localPosition; } set { transform.localPosition = value; } }
	public float ROT { get { return transform.rotation.eulerAngles.z; } }

	public float swayspeed = 5;
	public float swayamount = 0.1f;

	Vector2 startpos;
	float swaytimer;

	void Start ( ) {
		startpos = POS;
	}

	void Update ( ) {
		swaytimer += Time.deltaTime * swayspeed;
		// POS = startpos + Uhh.SineVector (swaytimer) * swayamount;
		Vector2 sv = new Vector2 (
			Mathf.Sin (swaytimer * .94124f),
			Mathf.Cos (swaytimer));
		POS = startpos + sv * swayamount;
	}

}