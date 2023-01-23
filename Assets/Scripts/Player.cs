using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private string playerName;
    [SerializeField] private KeyCode playerButton;
    [SerializeField] private float movementSpeed = 20.0f;

    [SerializeField] private TextMeshProUGUI scoreText;

    private GameControl _gameController;
    private int _constellationsCollected;
    private float _maxStunTime;
    private float _timeInStun;
    private bool _isStunned;

    /// <summary>
    /// Gets the player's name.
    /// </summary>
    public string PlayerName => playerName;

    /// <summary>
    /// Gets a button that the player must press to discover a star.
    /// </summary>
    public KeyCode PlayerButton => playerButton;

    /// <summary>
    /// Gets or sets the player's score.
    /// </summary>
    public int Score 
    {
        get => _constellationsCollected;
        set
        {
            _constellationsCollected = value;
            scoreText.text = $"Contellations Collected: {_constellationsCollected}";
        }
    }

    private void Start()
    {
        _gameController = FindObjectOfType<GameControl>();
        var bottomLeft = Camera.main.ViewportToWorldPoint(Vector2.zero);
        var topRight = Camera.main.ViewportToWorldPoint(Vector2.one);

        _minX = bottomLeft.x;
        _minY = bottomLeft.y;
        _maxX = topRight.x;
        _maxY = topRight.y;
    }

    private void Update()
    {
        if (_isStunned)
        {
            _timeInStun += Time.deltaTime;
            if (_timeInStun < _maxStunTime)
            {
                return;
            }

            _timeInStun = 0.0f;
            _isStunned = false;
        }

        var horizontalInput = Input.GetAxis(playerName + "Horizontal");
        var verticalInput = Input.GetAxis(playerName + "Vertical");

        transform.position += movementSpeed * Time.deltaTime * new Vector3(horizontalInput, verticalInput, 0f);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minX, _maxX), Mathf.Clamp(transform.position.y, _minY, _maxY), 0f);
    }

    public void Freeze(float seconds)
    {
        _isStunned = true;
        _maxStunTime = seconds;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Warp"))
        {
            _gameController.FreezeOtherPlayers(playerName);
            Destroy(collider.gameObject);
        }
    }

    private float _minX;
    private float _minY;
    private float _maxX;
    private float _maxY;
}
