using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {

	public List<Score> scores = new List<Score> ();
	public Score newScore;
	public static HighScoreManager This;
	public InputField tPlayer;

	public Text myScore;
	public Text highscores;

	// Use this for initialization
	void Start () {
		if (This == null) {
			This = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddScore() {
		if (tPlayer.text != "") {
			newScore.Player = tPlayer.text;
		}
		scores.Add (newScore);
	}

	public void DisplayCurrentScore(){
		myScore.text = "YOUR SCORE Time: " + newScore.Time + " Points: " + newScore.Points;
	}

	public void DisplayAll() {
		highscores.text = "";
		foreach (Score score in scores)
		{
			highscores.text += "Player: " + score.Player + " Score: " + score.Time + " Points: " + score.Points + "\n";
		}
	}
}
