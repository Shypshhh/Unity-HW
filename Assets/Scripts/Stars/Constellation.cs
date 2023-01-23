using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Stars;
using UnityEngine;

public class Constellation : MonoBehaviour
{
    private Star[] _stars;
    private int _undiscoveredStarsLeft;

    [HideInInspector] public string playerName;
    [HideInInspector] public KeyCode playerButton;
    [HideInInspector] public GameControl gameController;

    /// <summary>
    /// Gets or sets the constellation index used to instantiate this one.
    /// </summary>
    public int ConstellationIndex { get; set; }

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
            gameController.CompleteConstellation(ConstellationIndex, playerName, playerButton);
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
}
