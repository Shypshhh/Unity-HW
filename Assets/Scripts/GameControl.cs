using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControl : MonoBehaviour
{
    [SerializeField] private GameObject warpPrefab;
    [SerializeField] private GameObject[] constellations;
    [SerializeField] private float maxStunTime = 2.0f;
    private Player[] _players;
    private float _warpTimer;

    private List<int> _createdConstellationsIndexes = new List<int>();

    private const float horizontalOffset = 8f;
    private const float verticalOffset = 6f;
    private float _minX;
    private float _minY;
    private float _maxX;
    private float _maxY;

    private void Start()
    {
        _players = FindObjectsOfType<Player>();

        var bottomLeft = Camera.main.ViewportToWorldPoint(Vector2.zero);
        var topRight = Camera.main.ViewportToWorldPoint(Vector2.one);

        _minX = bottomLeft.x;
        _minY = bottomLeft.y;
        _maxX = topRight.x;
        _maxY = topRight.y;

        foreach (var player in _players)
        {
            CreateNewConstellationForPlayer(player.PlayerName, player.PlayerButton);
        }
    }

    private void Update()
    {
        _warpTimer += Time.deltaTime;
        if (_warpTimer >= Random.Range(10f, 20f))
        {
            GameObject newWarp = Instantiate(warpPrefab);
            float randomX = Random.Range(-10f, 10f);
            float randomY = Random.Range(-10f, 10f);
            newWarp.transform.position = new Vector3(randomX, randomY, 0f);
            _warpTimer = 0f;
        }
    }

    public void CreateNewConstellationForPlayer(string playerName, KeyCode playerButton)
    {
        // Get new random constellation by index
        int constellationIndex;

        // Continue generate random indxe, until there is constellation not created with this index
        do
        {
            constellationIndex = Random.Range(0, constellations.Length);
        }
        while (_createdConstellationsIndexes.Contains(constellationIndex));

        GameObject constellationToCreate = constellations[constellationIndex];

        // Create constellation
        GameObject newConstellationGameobject = Instantiate(constellationToCreate);
        float horizontalPosition = Random.Range(_minX + horizontalOffset, _maxX - horizontalOffset);
        float verticalPosition = Random.Range(_minY + verticalOffset, _maxY - verticalOffset);

        // Configure new constellation
        newConstellationGameobject.transform.position = new Vector3(horizontalPosition, verticalPosition, 0f);
        Constellation constellation = newConstellationGameobject.GetComponent<Constellation>();
        constellation.playerName = playerName;
        constellation.playerButton = playerButton;
        constellation.gameController = this;
        constellation.ConstellationIndex = constellationIndex;

        _createdConstellationsIndexes.Add(constellationIndex);
    }

    public void CompleteConstellation(int constellationIndex, string playerName, KeyCode playerButton)
    {
        CreateNewConstellationForPlayer(playerName, playerButton);
        _createdConstellationsIndexes.Remove(constellationIndex);
        foreach (var player in _players)
        {
            if (player.PlayerName == playerName)
            {
                player.Score++;
                break;
            }
        }
    }

    public void FreezeOtherPlayers(string playerName)
    {
        foreach (var player in _players)
        {
            if (player.PlayerName != playerName)
            {
                player.Freeze(maxStunTime);
            }
        }
    }
}
