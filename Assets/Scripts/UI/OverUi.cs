using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverUi : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjectsToDisable;

    public GameObject OverMenu;

    private void OnEnable()
    {
        Timer.OnTimerZero += EnableOverMenu;
    }

    private void OnDisable()
    {
        Timer.OnTimerZero -= EnableOverMenu;
    }

    public void EnableOverMenu()
    {
        OverMenu.SetActive(true);
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
        SceneManager.LoadScene(0);
    }
}
