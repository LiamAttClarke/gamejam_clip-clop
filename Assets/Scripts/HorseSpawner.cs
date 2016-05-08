using UnityEngine;
using System.Collections;

public class HorseSpawner : MonoBehaviour {

    public bool spawnHorses = true;
    public float minSpawnTime, maxSpawnTime;
    public float horseSpeed = 1.0f;

    Transform tran;
    GameObject horsePrefab;
    float nextSpawnTime;
    float timeElapsed = 0;

    void Awake() {
        tran = transform;
        nextSpawnTime = SpawnTime();
    }

    // Use this for initialization
    void Start () {
        horsePrefab = (GameObject)Resources.Load("Prefabs/Horse");
        if (horsePrefab == null)
            throw new UnityException("Missing Horse prefab");
    }
	
	// Update is called once per frame
	void Update () {
        if (spawnHorses) {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > nextSpawnTime) {
                nextSpawnTime = SpawnTime();
                timeElapsed = 0;
                SpawnHorse();
            }
        }       
	}

    float SpawnTime() {
        return Mathf.Abs(Random.Range(minSpawnTime, maxSpawnTime));
    }

    void SpawnHorse() {
        GameObject horse = (GameObject)Instantiate(horsePrefab, transform.position, Quaternion.identity);
        horse.transform.parent = transform;
        horse.GetComponent<Horse>().speed = horseSpeed;
    }
}
