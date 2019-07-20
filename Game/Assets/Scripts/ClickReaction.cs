using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickReaction : Clickable {

	// basically add an animation that will be loaded when clicked here.. 
	// like an eye that blinks, 
	// or a mouth that closes
	// should then have a timer and return to normal after a while. 
	// interaction !! 

	public string idle = "idle";
	public string onpoint;

	public bool mumble = false;
	public bool sigh = false;
	public bool waterdrop = true;
//	Particles particles;

	Anim anim;
	float cooldown = -1;

	void Start ( ) {
		anim = GetComponent<Anim> ( );
	}

	void Update ( ) {
		if (cooldown > 0) {
			cooldown -= Time.deltaTime;
			if (cooldown <= 0) {
				anim.Load (idle);
			}
		}
	}

	public override void Hold (GameObject subject) {
		if (cooldown <= 0) {
			print (gameObject + "got clicked!");
			anim.Load (onpoint);
		}
		cooldown = .15f;
	}
}