using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverUi : MonoBehaviour
{
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
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
}
