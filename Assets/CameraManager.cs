using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public GameObject CamPos1;
	public GameObject CamPos2;

	float kh = 0.1f;

	private int posNum = 1;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if (posNum == 1) {
			transform.position += kh * (CamPos1.transform.position - this.transform.position);
		} else {
			transform.position += kh * (CamPos2.transform.position - this.transform.position);
		} 
	}

	public void SwitchCamera() {

		if (posNum == 1) {
			posNum = 2;
		} else {
			posNum = 1;
		} 
	}
}
