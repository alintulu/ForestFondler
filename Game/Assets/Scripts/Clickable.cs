using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour {

	public Vector2 POS { get { return transform.position; } set { transform.position = value; } }
	public float ROT { get { return transform.rotation.eulerAngles.z; } set { transform.rotation = Quaternion.Euler (0, 0, value); } }

	[HideInInspector ( )]
	public bool grabbable;

	public virtual void Click (GameObject subject) {

	}
	public virtual void Hold (GameObject subject) {

	}
	public virtual void LetGo (GameObject subject) {

	}

	public virtual bool IsLocked(){return false;}

}