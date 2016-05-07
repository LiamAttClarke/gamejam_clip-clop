using UnityEngine;
using System.Collections;

public enum PlayerType { Front, Back }

public class Player : MonoBehaviour {

	public PlayerType playerType = PlayerType.Front;
	public float legSpeed = 1.0f;

	// input names
	string inputLL, inputLU, inputRL, inputRU;

	Leg leftLeg, rightLeg;

	void Awake () {
		//leftLeg = transform.Find ("Left Leg").GetComponent<Leg>();
		rightLeg = transform.Find ("Right Leg").GetComponent<Leg>();

		switch (playerType) {
		case PlayerType.Front:
			inputLL = "Front_LL";
			inputLU = "Front_LU";
			inputRL = "Front_RL";
			inputRU = "Front_RU";
			break;
		case PlayerType.Back:
			inputLL = "Back_LL";
			inputLU = "Back_LU";
			inputRL = "Back_RL";
			inputRU = "Back_RU";
			break;
		}
	}

	void Start () {
		
	}
	
	void Update () {
		rightLeg.SetMotorSpeed (LegType.Lower, Input.GetAxis (inputRL) * legSpeed);
		rightLeg.SetMotorSpeed (LegType.Upper, Input.GetAxis (inputRU) * legSpeed);
	}
}
