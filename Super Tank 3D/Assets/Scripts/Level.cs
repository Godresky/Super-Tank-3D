using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField]
    private int levelId;
    [SerializeField]
    private GameObject losePanel;
    [SerializeField]
    private GameObject winPanel;

    private Player player;

    private Enemy[] enemies;

    private void Awake()
    {
        enemies = FindObjectsOfType<Enemy>();
    }

    public void Lose()
    {
        losePanel.SetActive(true);
    }

    public void Win()
    {
        winPanel.SetActive(true);
    }

    public void CheckWin()
    {
        bool result = true;
        foreach (Enemy enemy in enemies)
        {
            if (enemy != null)
            {
                result = false;
                break;
            }
        }

        if (result)
            Win();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        PlayerPrefs.SetInt("Level", levelId + 1);
        SceneManager.LoadScene(levelId+1);
    }

    public void LoadLevel(int levelId)
    {
        SceneManager.LoadScene(levelId);
    }
}
