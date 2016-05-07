using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	GameObject splashScreen;

	// Use this for initialization
	void Start () {
		var joysticks = Input.GetJoystickNames ();
		for (int i = 0; i < joysticks.Length; i++) {
			Debug.Log (i + " : " + joysticks[i]);
		}
		splashScreen = GameObject.Find ("SplashScreen");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadSplashScreen() {

	}

	public void LoadGame() {
		
	}

	public void LoadOptions() {
		
	}

	public void LoadMainMenu() {
		
	}
}
