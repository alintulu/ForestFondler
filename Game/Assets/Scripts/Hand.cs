using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

	public Vector2 POS { get { return transform.position; } set { transform.position = value; } }
	public float ROT { get { return transform.rotation.eulerAngles.z; } set { transform.rotation = Quaternion.Euler (0, 0, value); } }

	public bool mouseControlled = false;
	public bool fakeHand = false;

	public LayerMask layer;

	Vector2 SHOULDER { get { return arm.POS; } }
	public BendyLine arm;

	public Transform grabposition;
	public Transform pointposition;
	Anim anim;

	bool STATIC { get { return body == null || body.bodyType == RigidbodyType2D.Static; } }
	Rigidbody2D body;


	void Start ( ) {
		anim = GetComponent<Anim> ( );
		anim.AddAnim (1, 1, "two");
		anim.AddAnim (2, 1, "one");
		anim.AddAnim (3, 1, "grab");
		anim.AddAnim (4, 1, "cangrab");
		body = GetComponent<Rigidbody2D> ( );
		joint = GetComponent<HingeJoint2D> ( );
	}

	bool justletgo;

	void Update ( ) {

		if (mumbletimer > 0) mumbletimer -= Time.deltaTime;

		// position 
		if (mouseControlled) {
			//Vector2 mp = Uhh.MousePosition ( );
			//body.MovePosition (mp);

			if (ISGRABBING) {
				anim.Load ("grab");
			} else {
				//Input.GetKey(KeyCode.Space)
				if (Input.GetKey("joystick button 0") && !justletgo) {
					anim.Load ("one");
				} else {
					if (cangrab)
						anim.Load ("cangrab");
					else
						anim.Load ("idle");
				}
			}
			if (fakeHand) {
				anim.color = Color.clear;
			} else {
				HandleGrabbing ( );
			}
			// rotation 
			Vector2 dir = arm.END - arm.MID;
			body.rotation = Uhh.AngleFromVector (dir);
		} else {
			if (STATIC) {
				// rotation 
				Vector2 dir = arm.END - arm.MID;
				ROT = Uhh.AngleFromVector (dir);
			}
		}

		arm.UpdateLine (SHOULDER, POS);
	}

	HingeJoint2D joint;

	bool cangrab;
	float mumbletimer;
	Vector2 lastpos;
	[HideInInspector ( )]
	public Vector2 vel;
	bool ISGRABBING { get { return grabbedBody != null; } }
	Rigidbody2D grabbedBody;
	void HandleGrabbing ( ) {

		vel = Vector2.Lerp (vel, (lastpos - POS) * 2f, .45f);
		lastpos = POS;
		Debug.DrawRay (POS, vel, Color.yellow);
		// clicking 
		Collider2D col = Physics2D.OverlapPoint (grabposition.position, layer);
		cangrab = false;
		if (col != null) {
			// trigger something on this part ?? 
			GameObject g = col.gameObject;
			//print ("colliding w " + g);

			Clickable[ ] clickables = g.GetComponents<Clickable> ( );
			foreach (Clickable c in clickables) {
				if (c != null) {
					if (c.grabbable) cangrab = true;
					if (Input.GetKey("joystick button 0")) {
						if (!c.IsLocked ( )) {
							//c.Click (this.gameObject);
							Rigidbody2D bod = c.gameObject.GetComponent<Rigidbody2D> ( );
							if (bod != null) {
								grabbedBody = bod;
								bod.AddForce (Vector2.up * 1f, ForceMode2D.Impulse);
								//joint.connectedBody = bod;
								justletgo = true;

								if (mumbletimer <= 0) {
									mumbletimer = 5;
								}
							}
						}
					} else {
						// LOCKED !! 

					}
				}

			}
		}

		if (Input.GetKey("joystick button 0")) {
			justletgo = false;
			if (ISGRABBING) {
				Clickable c = grabbedBody.GetComponent<Clickable> ( );
				//c.LetGo (gameObject);
				joint.connectedBody = null;
				//grabbedBody.AddForceAtPosition (vel * 4f, grabposition.position, ForceMode2D.Impulse);
				grabbedBody = null;
			}
		}

		if (!ISGRABBING && !justletgo) {
			col = Physics2D.OverlapPoint (pointposition.position, layer);
			if (col != null) {
				// trigger something on this part ?? 
				GameObject g = col.gameObject;
				Clickable[ ] clickables = g.GetComponents<Clickable> ( );
				foreach (Clickable c in clickables) {
					if (c != null) {

						if (Input.GetKey("joystick button 0")) {
							c.Hold (this.gameObject);
						}
					}

				}
			}
		}

	}
}