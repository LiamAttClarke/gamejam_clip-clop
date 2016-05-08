using UnityEngine;
using System.Collections;

public class HorseHead : MonoBehaviour {

    GameManager gameManager;
    GameObject hitPrefab;

    void Start() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        hitPrefab = (GameObject)Resources.Load("Prefabs/Hit");
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Ground" && !gameManager.isGameOver) {
            Instantiate(hitPrefab, other.contacts[0].point, Quaternion.identity);
            gameManager.EndGame();
        }
    }
}
