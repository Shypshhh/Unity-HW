using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public Constellation constellation;
    public bool isVisible;

    void Start()
    {
    
    }

    void Update()
    {
        if (isVisible)
        {
            
        } 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ENTERED");
        if (collision.gameObject.CompareTag("Player1"))
        {
            Debug.Log("ENTERED");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            Debug.Log("Left");
        }
    }
}
