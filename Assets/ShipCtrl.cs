using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipCtrl : MonoBehaviour {

	//all ship movements will be handled in here

	private Rigidbody rb;
	public int fuel = 5000;
	bool activeControls = false;
	int landed = 0;//0 = not landed/game has not started, 1 = landed sucessfullly, 2 = failed landing
	float verticalVelocity;
	float horizontalVelocity;
	float messageTime = 0f;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		rb = this.gameObject.GetComponent<Rigidbody> ();
	}

	public void OnTriggerEnter (Collider other) {
		IsAFuelPickup iafp = other.gameObject.GetComponent<IsAFuelPickup>();

		if (iafp != null) {
			SoundManager.This.FuelSound ();
			Destroy (other.gameObject);
			fuel += 1000;
		}
	}

	public void OnCollisionEnter (Collision other)
	{
		IsAPlatform1 iap1 = other.gameObject.GetComponent<IsAPlatform1>();
		IsAPlatform2 iap2 = other.gameObject.GetComponent<IsAPlatform2>();
		IsAPlatform3 iap3 = other.gameObject.GetComponent<IsAPlatform3>();

		if (activeControls) {
			SoundManager.This.ThrustSound (false);
			if ((transform.localEulerAngles.z < 20f || transform.localEulerAngles.z > 340f) && (verticalVelocity > -100f && 
				verticalVelocity < 1f && horizontalVelocity > -50F && horizontalVelocity < 50F)) {
				//SAFE LANDING
				HeroCtrl.This.Victory ();
				SoundManager.This.WinSound ();
				UIManager.This.main.text = "You Landed Successfully";

				if (iap1 != null && !iap1.landed) {
					//points X 1
					UIManager.This.SetPoints(fuel);
					UIManager.This.main.text += "\nPoints X 1";
					fuel += 1000;
				} else if (iap2 != null && !iap2.landed) {
					//points X 2
					UIManager.This.SetPoints(fuel * 2);
					UIManager.This.main.text += "\nPoints X 2";
					fuel += 1000;
				} else if (iap3 != null && !iap3.landed) {
					//points X 3
					UIManager.This.SetPoints(fuel * 3);
					UIManager.This.main.text += "\nPoints X 3";
					fuel += 1000;
				}
				landed = 1;
			} else {
				landed = 2;
				Instantiate(explosion, this.transform.position, Quaternion.identity);
				UIManager.This.main.text = "GAMEOVER";
				HeroCtrl.This.Defeat (true);
				SoundManager.This.LoseSound ();
				UIManager.This.tStart = false;
				HighScoreManager.This.newScore = new Score (string.Format ("{0:N2}", UIManager.This.timer), UIManager.This.points, "Anonymous"); 
				HighScoreManager.This.DisplayCurrentScore ();
				HighScoreManager.This.DisplayAll ();
			}
		}

		activeControls = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (activeControls) {
			Ship ();
		}

		UIMgr ();

		if (landed != 0) {
			messageTime += Time.deltaTime;
			if (Mathf.FloorToInt (messageTime) == 3f) {
				Landed ();
			}
		}
	}

	public void Ship() {
		float translation = Input.GetAxis ("Vertical") * 35f;//0.8
		translation *= Time.deltaTime;
		float rotation = Input.GetAxis ("Horizontal") * 2.5f;//0.1
		rotation *= Time.deltaTime;

		if (Input.GetAxis ("Vertical") > 0f && fuel > 0) {//using get axis instead of get button so that no reverse
			rb.AddForce (transform.up * translation);
			SoundManager.This.ThrustSound (true);
			HeroCtrl.This.PullLever (true);
			fuel -= 1;
		} else {
			HeroCtrl.This.PullLever (false);
		}

		if (Input.GetButton ("Horizontal") && fuel > 0) {
			fuel -= 1;
			rb.AddForce (transform.up * 0.75f);
			rb.AddTorque (0, 0, rotation * -1);
			SoundManager.This.ThrustSound (true);
			HeroCtrl.This.PressButton (true);
		} else {
			HeroCtrl.This.PressButton (false);
		}

		if ((!Input.GetButton ("Vertical") && !Input.GetButton ("Horizontal")) || fuel == 0) {
			SoundManager.This.ThrustSound (false);
		}
	}

	public void UIMgr() {
		UIManager.This.altitude.text = "Altitude " + ((int)(transform.position.y * 100) - 100);//perhaps pass number and format it in uimanager

		UIManager.This.tFuel.text = "Fuel " + fuel;
		UIManager.This.fuel = fuel;

		horizontalVelocity = (int)(Vector2.Dot(rb.velocity, Vector2.right) * 100);
		UIManager.This.horiz.text = "Horizontal Speed " + horizontalVelocity;

		verticalVelocity = (int)(Vector2.Dot(rb.velocity, Vector2.up) * 100);
		UIManager.This.vert.text = "Vertical Speed " + verticalVelocity;

	}

	public void Landed() {//use this method for ui handling + stuff after landing
		messageTime = 0f;
		UIManager.This.main.text = "";
		if (landed == 1) {
			activeControls = true;
		} else {
			UIManager.This.HighScores.SetActive (true);
			SoundManager.This.Music ();
			rb.isKinematic = true;
		}
		landed = 0;
	}

	public void Init() {
		//Reset ship
		rb.isKinematic = false;
		transform.eulerAngles = new Vector3(0, 0, 30);
		transform.position = new Vector3(-30, 50, 0);
		activeControls = true;

		rb.AddForce (transform.right * 100f);
		rb.AddForce (transform.up * 30f);
		fuel = 2500;

		UIManager.This.points = 0;
		HeroCtrl.This.Defeat (false);
		UIManager.This.timer = 0f;
		UIManager.This.tStart = true;
	}
}
