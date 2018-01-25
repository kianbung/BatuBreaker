using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name) {
        // Debug.Log("Level load: " + name);
        Brick.breakableCount = 0;
        SceneManager.LoadScene(name);
    }

    public void NextLevel() {
        // Debug.Log("Scene transition from: " + SceneManager.GetActiveScene().buildIndex);
        Brick.breakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void WinCheck() {
        if (Brick.breakableCount <= 0) {
            NextLevel();
        }
    }

    public void QuitGame() {
        // Debug.Log("Quit Level Requested");
        Application.Quit();
    }
}
