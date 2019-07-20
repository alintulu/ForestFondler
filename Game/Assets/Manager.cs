using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour {

	public Vector2 POS { get { return transform.position; } set { transform.position = value; } }
	public float ROT { get { return transform.rotation.eulerAngles.z; } }

	void Start ( ) {

	}

	void Update ( ) {
		if (Input.GetKeyDown (KeyCode.Escape)) Uhh.LoadLevel ("StartScreen");
	}
}