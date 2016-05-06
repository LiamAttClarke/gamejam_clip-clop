using UnityEngine;
using System.Collections;

public enum LegType { Lower, Upper }

public class Leg : MonoBehaviour {

	public GameObject lowerLeg { get; private set; }
	public GameObject upperLeg { get; private set; }

	HingeJoint2D lowerHinge, upperHinge;

	void Awake () {
		lowerLeg = transform.Find ("Lower").gameObject;
		upperLeg = transform.Find ("Upper").gameObject;
		lowerHinge = lowerLeg.GetComponent<HingeJoint2D> ();
		upperHinge = upperLeg.GetComponent<HingeJoint2D> ();
		lowerHinge.useMotor = upperHinge.useMotor = true;
	}

	void Start () {
	
	}
	
	void Update () {
	
	}

	public void SetMotorSpeed (LegType legType, float speed) {
		JointMotor2D motor;
		switch (legType) {
		case LegType.Lower:
			if (lowerHinge == null) throw new UnityException ("Lower Hinge is null");
			motor = lowerHinge.motor;
			motor.motorSpeed = speed;
			lowerHinge.motor = motor;
			break;
		case LegType.Upper:
			if (upperHinge == null) throw new UnityException ("Upper Hinge is null");
			motor = upperHinge.motor;
			motor.motorSpeed = speed;
			upperHinge.motor = motor;
			break;
		}
	}

	public float GetMotorSpeed (LegType legType) {
		float motorSpeed = 0;
		switch (legType) {
		case LegType.Lower:
			if (lowerHinge == null) throw new UnityException ("Lower Hinge is null");
			motorSpeed = lowerHinge.motor.motorSpeed;
			break;
		case LegType.Upper:
			if (upperHinge == null) throw new UnityException ("Upper Hinge is null");
			motorSpeed = upperHinge.motor.motorSpeed;
			break;
		}
		return motorSpeed;
	}
}
