using Assets.Scripts.Stars;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constellation : MonoBehaviour
{
    private Star[] _stars;
    private int _undiscoveredStarsLeft;

    private void Start()
    {
        _stars = GetComponentsInChildren<Star>();
        _undiscoveredStarsLeft = _stars.Length;
        if (_undiscoveredStarsLeft == 0)
        {
            Debug.LogError("There are no stars in the constellation.", this);
        }

        foreach (var star in _stars)
        {
            ConfigureStar(star);
        }
    }

    private void ConfigureStar(Star star)
    {
        star.StarDiscovered += CountStar;
        star.PlayerName = playerName;
        star.PlayerButton = playerButton;
        star.SortingLayerName = playerName;
    }

    private void CountStar(object sender, StarEventArgs args)
    {
        _undiscoveredStarsLeft--;
        if (_undiscoveredStarsLeft <= 0)
        {
            // Refactor
            gameControl.CompleteConstellation(constellationIndex, playerName, playerButton);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        foreach (var star in _stars)
        {
            star.StarDiscovered -= CountStar;
        }
    }


    [HideInInspector] public string playerName;
    [HideInInspector] public KeyCode playerButton;
    [HideInInspector] public int constellationIndex;
    [HideInInspector] public GameControl gameControl;
}
