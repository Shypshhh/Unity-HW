using System;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static event Action OnTimerZero;
    
    [Header("Component")]
    public TextMeshProUGUI timerText;

    public float currentTime;

    [Header("Timer Number")]
    public float timerLimit;

    void Update()
    {
        currentTime = currentTime -= Time.deltaTime;

        if (currentTime <= timerLimit)
        {
        
            currentTime = timerLimit;
            timerText.text = currentTime.ToString("0.00");
            timerText.color = Color.red;
            OnTimerZero?.Invoke();
            enabled = false;

            
        }

        timerText.text = currentTime.ToString("0.00");   
    }
}
