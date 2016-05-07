using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	GameObject currentScreen;

	public GameObject mainMenu;
	public GameObject options;
	public GameObject credits;

	// Use this for initialization
	void Start () {
		var joysticks = Input.GetJoystickNames ();
		for (int i = 0; i < joysticks.Length; i++) {
			Debug.Log (i + " : " + joysticks[i]);
		}
		//mainMenu = GameObject.Find ("MainMenu");
		//options = GameObject.Find ("Options");
		print (options == null);
		options.SetActive (false);
		currentScreen = mainMenu;
		currentScreen.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void LoadGame() {
		SceneManager.LoadScene ("Game");	
	}

	public void LoadOptions() {
		currentScreen.SetActive (false);
		currentScreen = options;
		currentScreen.SetActive (true);
	}

	public void LoadMainMenu() {
		currentScreen.SetActive (false);
		currentScreen = mainMenu;
		currentScreen.SetActive (true);
		
	}

	public void LoadCredits() {

		currentScreen.SetActive (false);
		currentScreen = credits;
		currentScreen.SetActive (true);
	}
}
