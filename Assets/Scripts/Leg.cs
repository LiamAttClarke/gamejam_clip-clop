using UnityEngine;
using System.Collections;

public enum LegType { Lower, Upper }

public class Leg : MonoBehaviour {

	public GameObject lowerLeg { get; private set; }
	public GameObject upperLeg { get; private set; }

	HingeJoint2D lowerHinge, upperHinge;
	float maxHingeSpeed = 250f;

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

	// Set leg position [0, 1]
	public void MoveToPosition (LegType legType, float percent) {
		percent = Mathf.Clamp (percent, 0, 1f);
		HingeJoint2D hinge = null;
		JointMotor2D motor;
		if (legType == LegType.Lower) {
			hinge = lowerHinge;
		} else if (legType == LegType.Upper) {
			hinge = upperHinge;
		}
			
		if (hinge == null)
			throw new UnityException ("Hinge is missing");

		motor = hinge.motor;
		float desiredAngle = Mathf.Lerp (hinge.limits.min, hinge.limits.max, percent);
		float diff = Mathf.Abs (desiredAngle - hinge.jointAngle) / hinge.limits.max;
		if (hinge.jointAngle < desiredAngle) {
			motor.motorSpeed = diff * maxHingeSpeed;
		} else if (lowerHinge.jointAngle > desiredAngle) {
			motor.motorSpeed = diff * -maxHingeSpeed;
		} else {
			motor.motorSpeed = 0;
		}

		hinge.motor = motor;
	}
}
