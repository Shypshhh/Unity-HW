using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constellation : MonoBehaviour
{
    public List<Star> stars;
    public string playerName;
    public KeyCode playerButton;

    int starsInConstellation;
    int startsActive = 0;

    void Start()
    {
        starsInConstellation = stars.Count;
    }

    void Update()
    {
       
    }

    public void DetectStar()
    {
        startsActive++;
        if (startsActive >= starsInConstellation)
        {
            // Constellation completion logic
        }
    }
}
