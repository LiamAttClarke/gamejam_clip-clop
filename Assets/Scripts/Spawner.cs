using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public bool spawn = true;
    public float minSpawnTime, maxSpawnTime;
    public GameObject prefab;

    Transform tran;
    float nextSpawnTime;
    float timeElapsed = 0;

    void Awake() {
        tran = transform;
        nextSpawnTime = SpawnTime();
    }

    // Use this for initialization
    void Start () {
        if (prefab == null)
            throw new UnityException("Missing prefab");
    }
	
	// Update is called once per frame
	void Update () {
        if (spawn) {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > nextSpawnTime) {
                nextSpawnTime = SpawnTime();
                timeElapsed = 0;
                Spawn();
            }
        }       
	}

    float SpawnTime() {
        return Mathf.Abs(Random.Range(minSpawnTime, maxSpawnTime));
    }

    void Spawn() {
        GameObject obj = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity);
        obj.transform.parent = transform;
    }
}
