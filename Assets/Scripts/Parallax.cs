using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	//should be between 1 and 0. Or not. You have free will.
	public float backgroundSpeed;
	public float midgroundSpeed;

	GameObject midLayer;
	GameObject backLayer;
	Vector3 oldCameraPos;
	Vector3 deltaCameraPos;

	// Use this for initialization
	void Start () {
		midLayer = GameObject.Find ("Mid");
		backLayer = GameObject.Find ("Back");
		oldCameraPos = Camera.main.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//sets the parallax objects position = to camera so that we dont need to fuck with child objects
		transform.position = Camera.main.transform.position + Vector3.forward	/*left in for liam*/;
		//calculates change in camera position
		deltaCameraPos = oldCameraPos - Camera.main.transform.position;
		//moves the layers
		backLayer.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(backgroundSpeed*Camera.main.transform.position.x, 0);
		midLayer.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(midgroundSpeed*Camera.main.transform.position.x, 0);
		
		oldCameraPos = Camera.main.transform.position;
	}
}
