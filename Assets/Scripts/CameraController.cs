using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform target;

    Transform tran;

    void Awake() {
        tran = transform;
        if (target == null)
            throw new UnityException("Missing target");
    }
	
	// Update is called once per frame
	void Update () {
        tran.position = new Vector3(target.position.x, tran.position.y, tran.position.z);
    }
}
