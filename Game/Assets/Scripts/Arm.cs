using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour {

	public Vector2 POS { get { return transform.position; } set { transform.position = value; } }
	public float ROT { get { return transform.rotation.eulerAngles.z; } set { transform.rotation = Quaternion.Euler (0, 0, value); } }

	public bool updateself = false;

	bool HASTARGET { get { return target != null; } }
	public Transform target;

	BendyLine line;

	void Start ( ) {
		line = GetComponent<BendyLine> ( );
	}

	void Update ( ) {
		if (updateself) {
			if (HASTARGET) line.UpdateLine (POS, target.position);
			else line.UpdateLine (POS, Uhh.MousePosition ( ));

			// line.START = POS;

			// if (HASTARGET) line.END = target.position;
			// else {
			// 	line.END = Uhh.MousePosition ( );
			// 	if (Input.GetMouseButton (0)) line.hangamount = -4;
			// 	else line.hangamount = 3;
			// }
		}
	}
}