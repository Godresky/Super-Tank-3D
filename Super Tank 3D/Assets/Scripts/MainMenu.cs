using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int level;

    private void Start()
    {
        CheckLevel();
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene(1);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void CheckLevel()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            level = PlayerPrefs.GetInt("Level");
        } 
        else
        {
            level = 1;
        }
    }
}
