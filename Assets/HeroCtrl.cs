using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCtrl : MonoBehaviour {

	private Animator anim;
	public static HeroCtrl This;

	// Use this for initialization
	void Start () {
		anim = this.gameObject.GetComponent<Animator> ();

		if (This == null) {
			This = this;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void PressButton(bool press) {
		anim.SetBool ("Button", press);
	}

	public void PullLever(bool pull) {
		anim.SetBool ("Lever", pull);
	}

	public void Victory() {
		anim.SetTrigger("Victory");
	}

	public void Defeat(bool lose) {
		anim.SetBool ("Defeat", lose);
	}
}
