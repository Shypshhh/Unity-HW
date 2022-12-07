using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    float warpTimer = 0f;
    public GameObject warpPrefab;
    public GameObject[] constellations;

    void Start()
    {
        CreateNewConstellationForPlayer("Player1", KeyCode.Space);
        CreateNewConstellationForPlayer("Player2", KeyCode.Escape);
    }

    // Update is called once per frame
    void Update()
    {
        //warpTimer += 1f * Time.deltaTime;
        //if (warpTimer >= Random.Range(10f, 20f))
        //{
        //    GameObject newWarp = Instantiate(warpPrefab);
        //    float randomX = Random.Range(-10f, 10f);
        //    float randomY = Random.Range(-10f, 10f);
        //    newWarp.transform.position = new Vector3(randomX, randomY, 0f);
        //    warpTimer = 0f;
        //}
    }
    
    public void CreateNewConstellationForPlayer(string playerName, KeyCode playerButton)
    {
        // Get new random constellation by index and create it
        int constellationIndex = Random.Range(0, constellations.Length);
        GameObject newConstellationGameobject = Instantiate(constellations[constellationIndex]);

        // Configure new constellation
        Constellation constellation = newConstellationGameobject.GetComponent<Constellation>();
        constellation.playerName = playerName;
        constellation.playerButton = playerButton;
    }
}
