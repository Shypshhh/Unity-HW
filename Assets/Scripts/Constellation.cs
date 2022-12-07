using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constellation : MonoBehaviour
{
    public string playerName;
    public KeyCode playerButton;

    Star[] stars;
    int starsInConstellation;
    int startsActive = 0;

    void Start()
    {
        stars = GetComponentsInChildren<Star>();
        starsInConstellation = stars.Length;
        foreach (var star in stars)
        {
            // Move constellation stars to the player's layer
            star.spriteRenderer.sortingLayerName = playerName;
        }
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
