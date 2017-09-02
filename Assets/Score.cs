using System.Collections;
using System.Collections.Generic;

public class Score {

	string time;
	int points;
	string player;

	public Score(string time, int points, string player) {
		this.time = time;
		this.points = points;
		this.player = player;
	}

	public Score() {
	
	}

	public string Time {
		get {
			return this.time;
		}
		set {
			time = value;
		}
	}

	public int Points {
		get {
			return this.points;
		}
		set {
			points = value;
		}
	}

	public string Player {
		get {
			return this.player;
		}
		set {
			player = value;
		}
	}
}
