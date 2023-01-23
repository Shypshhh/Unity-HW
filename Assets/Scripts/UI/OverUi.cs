using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverUI : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjectsToDisable;
    [SerializeField] private GameObject gameOverMenu;

    private void OnEnable()
    {
        Timer.OnTimerZero += ShowGameOverMenu;
    }

    private void OnDisable()
    {
        Timer.OnTimerZero -= ShowGameOverMenu;
    }

    private void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        foreach (var item in gameObjectsToDisable)
        {
            item.SetActive(false);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
