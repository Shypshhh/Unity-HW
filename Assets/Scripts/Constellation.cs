using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constellation : MonoBehaviour
{
    public string playerName;
    public KeyCode playerButton;
    [HideInInspector] public int constellationIndex;
    [HideInInspector] public GameControl gameControl;

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
            gameControl.CompleteConstellation(constellationIndex, playerName, playerButton);
            Destroy(gameObject);
        }
    }
}
