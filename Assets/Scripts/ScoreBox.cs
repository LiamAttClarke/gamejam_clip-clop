using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreBox : MonoBehaviour {
	public Text placeText;
	public Text nameText;
	public Text distanceText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetText(int place, string name, int distance) {
		placeText.text = "" + place + ".";
		nameText.text = name;
		distanceText.text = "" + distance;

	}

}
