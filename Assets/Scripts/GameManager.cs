using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject target;
    public AudioClip startClip, endClip;
    GameObject gameOverPanel;
    AudioSource jukebox;
    public bool isGameOver { get; private set;}

    Text distance;

	// Use this for initialization
	void Start () {
        // controllers
		var joysticks = Input.GetJoystickNames ();
		for (int i = 0; i < joysticks.Length; i++) {
			Debug.Log (i + " : " + joysticks[i]);
		}

        distance = GameObject.Find("Distance").GetComponent<Text>();
        gameOverPanel = GameObject.Find("Game Over");
        jukebox = GameObject.Find("Jukebox").GetComponent<AudioSource>();
        gameOverPanel.SetActive(false);
        jukebox.PlayOneShot(startClip);
    }

    void Update() {
        if (!isGameOver) {
            distance.text = Mathf.FloorToInt(target.transform.position.x).ToString();        
        }
    }

    public void EndGame() {
        if (isGameOver) return;
        isGameOver = true;
        jukebox.Stop();
        jukebox.PlayOneShot(endClip);
        gameOverPanel.SetActive(true);        
    }
}
