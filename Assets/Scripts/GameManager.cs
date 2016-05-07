using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var joysticks = Input.GetJoystickNames ();
		foreach (var joystick in joysticks) {
			Debug.Log (joystick);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
