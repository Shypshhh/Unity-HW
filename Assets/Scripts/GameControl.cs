using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControl : MonoBehaviour
{
    float warpTimer = 0f;
    List<int> createdConstellationsIndexes = new List<int>();
    character[] players;
    public GameObject warpPrefab;
    public GameObject[] constellations;
    public float maxStunTime = 2.0f;
    public float numberOfConsts;
    private const float horizontalOffset = 8f;
    private const float verticalOffset = 6f;
    float minX;
    float minY;
    float maxX;
    float maxY;

    void Start()
    {
        players = FindObjectsOfType<character>();

        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));

        minX = bottomLeft.x;
        minY = bottomLeft.y;
        maxX = topRight.x;
        maxY = topRight.y;

        CreateNewConstellationForPlayer("Player1", KeyCode.Space);
        CreateNewConstellationForPlayer("Player2", KeyCode.Escape);
    }

    // Update is called once per frame
    void Update()
    {
        warpTimer += 1f * Time.deltaTime;
        if (warpTimer >= Random.Range(10f, 20f))
        {
            GameObject newWarp = Instantiate(warpPrefab);
            float randomX = Random.Range(-10f, 10f);
            float randomY = Random.Range(-10f, 10f);
            newWarp.transform.position = new Vector3(randomX, randomY, 0f);
            warpTimer = 0f;

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
        while (createdConstellationsIndexes.Contains(constellationIndex));

        GameObject constellationToCreate = constellations[constellationIndex];

        // Create constellation
        GameObject newConstellationGameobject = Instantiate(constellationToCreate);
        float horizontalPosition = Random.Range(minX + horizontalOffset, maxX - horizontalOffset);
        float verticalPosition = Random.Range(minY + verticalOffset, maxY - verticalOffset);

        // Configure new constellation
        newConstellationGameobject.transform.position = new Vector3(horizontalPosition, verticalPosition, 0f);
        Constellation constellation = newConstellationGameobject.GetComponent<Constellation>();
        constellation.playerName = playerName;
        constellation.playerButton = playerButton;
        constellation.gameControl = this;
        constellation.constellationIndex = constellationIndex;

        createdConstellationsIndexes.Add(constellationIndex);
    }

    public void CompleteConstellation(int constellationIndex, string playerName, KeyCode playerButton)
    {
        CreateNewConstellationForPlayer(playerName, playerButton);
        createdConstellationsIndexes.Remove(constellationIndex);
         foreach (var player in players)
        {
            if (player.playerName == playerName)
            {
                player.numberOfConsts++;
                player.ConstText.text = ("Contellations Collected: ") + numberOfConsts.ToString("0");
                break;
            }
        }
        
    }

    public void FreezeOtherPlayers(string playerName)
    {
        foreach (var player in players)
        {
            if (player.playerName != playerName)
            {
                player.Stun(maxStunTime);
            }
        }
    }
}
