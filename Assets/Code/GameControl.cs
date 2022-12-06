using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    float warpTimer = 0f;
    public GameObject warpPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        warpTimer += 1f * Time.deltaTime;
        if(warpTimer >= Random.Range (10f, 20f)){
            GameObject newWarp = Instantiate(warpPrefab);
            float randomX = Random.Range (-10f, 10f);
            float randomY = Random.Range (-10f, 10f);
            newWarp.transform.position = new Vector3(randomX, randomY, 0f);
            warpTimer = 0f;
        }
    }
    
}
