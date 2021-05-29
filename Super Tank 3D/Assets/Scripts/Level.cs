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
    private bool needCheck;

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
        needCheck = true;
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

    private void LateUpdate()
    {
        if (needCheck)
        {
            needCheck = false;
            bool result = true;
            foreach (Enemy enemy in enemies)
            {
                Debug.Log(enemy);
                if (enemy)
                    result = false;
            }

            if (result)
                Win();
        }
    }

    public void LoadLevel(int levelId)
    {
        SceneManager.LoadScene(levelId);
    }
}
