using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer spriteRenderer;
    public Constellation constellation;
    public List<Line> lines;
    bool isVisible;
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isVisible)
        {
            if (Input.GetKeyDown(constellation.playerButton))
            {
                constellation.DetectStar();

                // Run activation animation here
                animator.SetTrigger("isActivated");
                foreach (var line in lines)
                {
                    // Move line to the player's layer
                    line.spriteRenderer.sortingLayerName = spriteRenderer.sortingLayerName;
                    line.Display();
                }

                enabled = false;
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(constellation.playerName))
        {
            isVisible = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(constellation.playerName))
        {
            isVisible = false;
        }
    }
}
