using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager This;

	public Text altitude;
	public Text tFuel;
	public Text horiz;
	public Text vert;
	public Text main;
	public Text tPoints;
	public Text tTimer;
	public GameObject HighScores;
	public float timer = 0f;
	public bool tStart = false;
	public int fuel;
	public int points = 0;

	// Use this for initialization
	void Start () {
		if (This == null) {
			This = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (fuel < 500) {
			tFuel.color = Color.red;
		} else {
			tFuel.color = Color.black;
		}

		tPoints.text = points.ToString();

		if (tStart) {
			tTimer.text = string.Format ("{0:N2}", timer += Time.deltaTime);
		}
	}

	public void SetPoints(int pts) {
		points += pts;
	}
}
