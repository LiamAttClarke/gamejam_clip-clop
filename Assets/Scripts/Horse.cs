using UnityEngine;
using System.Collections;

public class Horse : MonoBehaviour {

    float speed = 0.15f;
    Transform tran;

    void Awake() {
        tran = transform;
        Destroy(gameObject, 10f);
    }
	
	// Update is called once per frame
	void Update () {
        tran.position = new Vector3(tran.position.x + speed, tran.position.y, tran.position.z);
	}
}
