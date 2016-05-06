using UnityEngine;
using System.Collections;

public enum PlayerType { Front, Back }

public class Player : MonoBehaviour {

	public PlayerType playerType = PlayerType.Front;
	public float legSpeed = 1.0f;

	Leg leftLeg, rightLeg;

	void Awake () {
		//leftLeg = transform.Find ("Left Leg").GetComponent<Leg>();
		rightLeg = transform.Find ("Right Leg").GetComponent<Leg>();
	}

	void Start () {
		
	}
	
	void Update () {
		rightLeg.SetMotorSpeed (LegType.Lower, Input.GetAxis ("Horizontal") * legSpeed);
		rightLeg.SetMotorSpeed (LegType.Upper, Input.GetAxis ("Vertical") * legSpeed);
	}
}
