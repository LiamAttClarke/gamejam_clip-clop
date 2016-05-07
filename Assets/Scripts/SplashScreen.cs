using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Front_A") || Input.GetButtonDown ("Front_X") || Input.GetButtonDown ("Back_A") || Input.GetButtonDown ("Back_X")) {
			gameObject.SetActive (false);
		}
	}
}
