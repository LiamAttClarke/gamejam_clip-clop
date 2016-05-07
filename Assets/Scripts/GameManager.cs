using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var joysticks = Input.GetJoystickNames ();
		for (int i = 0; i < joysticks.Length; i++) {
			Debug.Log (i + " : " + joysticks[i]);
		}
	}
}
