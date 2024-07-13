using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject NextLevelPanel;
    public GameObject PausePanel;

    private void Start()
    {
        NextLevelPanel.SetActive(false);
    }
    public void SetPanelActive() 
    {

        NextLevelPanel.SetActive(true);
        PausePanel.SetActive(false);
    }

    public void SetPanelDeactive()
    {

        NextLevelPanel.SetActive(false);
        PausePanel.SetActive(true);
    }

    public void LevelPanelActive()
    {

        NextLevelPanel.SetActive(true);       
    }

    public void LevelPanelDeactive()
    {

        NextLevelPanel.SetActive(false);

    }



    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void PauseGame()
    {
        if (NextLevelPanel.activeInHierarchy)
        {
            Time.timeScale = 1.0f;
            NextLevelPanel.SetActive(false);
        }

        else
        {
            Time.timeScale = 0.0f;
            NextLevelPanel.SetActive(true);
        }
        
    }

    public void ExitToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Level1() 
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Level2()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Level3()
    {
        SceneManager.LoadSceneAsync(3);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
