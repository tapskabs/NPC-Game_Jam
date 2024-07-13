using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scenes : MonoBehaviour
{
    private string pausedSceneName;
    private bool isPaused = false;

    // Method to pause the current scene
    public void PauseScene()
    {
        if (!isPaused)
        {
            pausedSceneName = SceneManager.GetActiveScene().name;
            Time.timeScale = 0;
            isPaused = true;
            Debug.Log("Scene paused");
        }
    }

    // Method to unpause the current scene
    public void UnpauseScene()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            Debug.Log("Scene unpaused");
        }
    }

    // Method to switch to the game scene
    public void GoToGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        isPaused = false;
        Debug.Log("Switched to game scene");
    }

    // Method to switch to the tutorial scene
    public void GoToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
        Time.timeScale = 1;
        isPaused = false;
        Debug.Log("Switched to tutorial scene");
    }

    // Method to quit the game
    public void QuitGame()
    {
        Debug.Log("Game quit");
        Application.Quit();
    }
}
