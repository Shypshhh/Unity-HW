using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public Constellation constellation;
    SpriteRenderer spriteRenderer;
    public bool isVisible;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
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

                enabled = false;
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(constellation.playerName))
        {
            isVisible = true;
            spriteRenderer.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(constellation.playerName))
        {
            isVisible = false;
            spriteRenderer.enabled = false;
        }
    }
}
