using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	//level creation happens here
	//this can be improved
	public GameObject platform1;
	public GameObject platform2;
	public GameObject platform3;
	public GameObject fuelPickup;
	private GameObject obj;
	List<GameObject> objs = new List<GameObject> ();

	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void CreateObj(int numObjs, float left, float right, float yVal) {

		for (int i = 1; i <= numObjs; i++) {
			int platNum = Random.Range (1, 4);
			//int yChange = Random.Range (-2, 4);

			if (platNum == 1) {
				obj = platform1;
			} else if (platNum == 2) {
				obj = platform2;
			} else {
				obj = platform3;
			}

			GameObject o = Instantiate(obj, new Vector3 (Random.Range (left, right), yVal, 0), Quaternion.identity);
			objs.Add (o);
		}
	}

	public void SpawnFuel(float yVal) {
		for (int i = 1; i <= 5; i++) {
			GameObject o = Instantiate(fuelPickup, new Vector3 (Random.Range (-200, 201), yVal, 0), Quaternion.identity);
			objs.Add (o);
		}
	}

	public void Init() {
		foreach (GameObject obj in objs)
		{
			Destroy (obj);
		}
		objs.Clear ();

		CreateObj (15, -200, 201, 10);
		CreateObj (15, -200, 201, 20);
		CreateObj (15, -200, 201, 30);
		SpawnFuel (15);
		SpawnFuel (25);
		//recreate level
	}
}
