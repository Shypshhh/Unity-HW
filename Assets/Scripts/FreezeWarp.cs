using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeWarp : MonoBehaviour
{
    bool isToBeRemoved;
    float timePassed = 0.0f;
    float maxTimeToRemove;
    Collider2D warpCollider;

    void Start()
    {
        warpCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (isToBeRemoved)
        {
            timePassed += Time.deltaTime;
            if (timePassed >= maxTimeToRemove)
            {
                Destroy(gameObject);
            }
        }
    }

    public void RemoveInSeconds(float seconds)
    {
        isToBeRemoved = true;
        maxTimeToRemove = seconds;
        warpCollider.enabled = false;
    }
}
