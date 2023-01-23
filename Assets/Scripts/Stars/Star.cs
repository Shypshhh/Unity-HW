using System;
using Assets.Scripts.Stars;
using Assets.Scripts.Utilities;
using UnityEngine;

public class Star : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool _isVisible;

    /// <summary>
    /// An event triggered when a player discovers a star.
    /// </summary>
    public event EventHandler<StarEventArgs> StarDiscovered;

    /// <summary>
    /// Gets or sets the name of a sprite's sorting layer.
    /// </summary>
    public string SortingLayerName
    {
        get => _spriteRenderer.sortingLayerName;
        set => _spriteRenderer.sortingLayerName = value;
    }

    /// <summary>
    /// Gets or sets a button that the player must press to discover a star.
    /// </summary>
    public KeyCode PlayerButton { get; set; }

    /// <summary>
    /// Gets or sets the name of the player for whom this star is visible.
    /// </summary>
    public string PlayerName { get; set; }

    /// <summary>
    /// A method called when a player discovers a star.
    /// </summary>
    protected virtual void OnStarDiscovered()
    {
        _animator.SetTrigger("Discovered");
        StarDiscovered?.Invoke(this, new StarEventArgs { Star = this });
        this.Disable();
    }

    protected virtual void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>().LogErrorIfNotAttached();
        _animator = GetComponent<Animator>().LogErrorIfNotAttached();
    }

    private void Update()
    {
        if (_isVisible)
        {
            if (Input.GetKeyDown(PlayerButton))
            {
                OnStarDiscovered();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerName))
        {
            _isVisible = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerName))
        {
            _isVisible = false;
        }
    }
}
