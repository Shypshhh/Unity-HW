using System;
using Assets.Scripts.Stars;
using Assets.Scripts.Utilities;
using UnityEngine;

public sealed class Line : MonoBehaviour
{
    [SerializeField] private Star[] stars;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        if (stars.Length != 2)
        {
            Debug.LogError("The line does not connect two stars.", this);
        }

        foreach (var star in stars)
        {
            star.StarDiscovered += DisplayLine;
        }

        _spriteRenderer = GetComponent<SpriteRenderer>().LogErrorIfNotAttached();
        _spriteRenderer.enabled = false;
    }

    private void DisplayLine(object sender, StarEventArgs args)
    {
        _spriteRenderer.sortingLayerName = args.Star.SortingLayerName;
        _spriteRenderer.enabled = true;
    }

    private void OnDestroy()
    {
        foreach (var star in stars)
        {
            star.StarDiscovered -= DisplayLine;
        }
    }
}
