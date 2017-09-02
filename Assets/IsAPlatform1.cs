using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAPlatform1 : MonoBehaviour {

	public bool landed = false;

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(Random.Range (3, 11),0.5f,2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionExit (Collision other)
	{
		landed = true;
	}
}
