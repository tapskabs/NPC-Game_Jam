using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject GameOverPanel;
    // Start is called before the first frame updat

    // Update is called once per frame
    private void Start()
    {
        GameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (GameOverPanel.activeInHierarchy)
            {
                Time.timeScale = 1;
                GameOverPanel.SetActive(false);
            }
            else 
            {
                GameOverPanel.SetActive(true);
                Time.timeScale = 0;
            }

        }

    }
}
