using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour {

    public void LoadStart() {
        SceneManager.LoadScene("Start");
    }

    public void LoadGame() {
        SceneManager.LoadScene("Game");
    }
    
    public void LoadControls() {
        SceneManager.LoadScene("Controls");    
    }
    
    public void LoadHighscores() {
        SceneManager.LoadScene("Highscores");    
    }
    
    public void LoadCredits() {
        SceneManager.LoadScene("Credits");    
    }
}
