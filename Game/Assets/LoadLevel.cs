using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour {

	public Vector2 POS { get { return transform.position; } set { transform.position = value; } }
	public float ROT { get { return transform.rotation.eulerAngles.z; } }

	public string levelToLoad = "StartScreen";

	void Start ( ) {

	}

	void Update ( ) {
		if (Input.GetKeyDown (KeyCode.Return))
			Uhh.LoadLevel (levelToLoad);
	}
}