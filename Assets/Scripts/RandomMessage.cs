using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class RandomMessage : MonoBehaviour {
	
	public string[] messages;
	
	Text text;
	
	// Use this for initialization
	void Awake () {
		text = GetComponent<Text>();
	}
	
	void OnEnable() {
		text.text = messages[(int)Random.Range(0, messages.Length - 1)];
	}
}
