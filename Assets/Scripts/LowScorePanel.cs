using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LowScorePanel : MonoBehaviour {
	public GameObject[] scoreBoxes;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void WriteScores() {
		for (int i = 0; i < scoreBoxes.Length; i++) {
			Score tmp = ScoreManager.lowScores.list [i];
			scoreBoxes [i].GetComponent<ScoreBox> ().SetText (i, tmp.name, tmp.distance);
		}
	}
}
