using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    float timeBeforeStun = 0.0f;
    float timeInStun = 0.0f;
    bool isStunned;

    float minX;
    float minY;
    float maxX;
    float maxY;

    public int numberOfConsts;
    public string playerName;
    public float moveSpeed = 20f;
    public KeyCode playerButton;

    public float maxTimeBeforeStun = 2.0f;
    public float maxStunTime = 2.0f;

    private void Start()
    {
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));

        minX = bottomLeft.x;
        minY = bottomLeft.y;
        maxX = topRight.x;
        maxY = topRight.y;
    }

    void Update()
    {
        if (isStunned)
        {
            if (timeBeforeStun >= maxTimeBeforeStun)
            {
                timeInStun += Time.deltaTime;
                if (timeInStun >= maxStunTime)
                {
                    timeInStun = 0.0f;
                    timeBeforeStun = 0.0f;
                    isStunned = false;
                }

                return;
            }

            timeBeforeStun += Time.deltaTime;
        }

        transform.position += new Vector3(Input.GetAxis(playerName + "Horizontal"), Input.GetAxis(playerName + "Vertical"), 0f)
        * Time.deltaTime
        * moveSpeed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                                       Mathf.Clamp(transform.position.y, minY, maxY),
                                       0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Warp"))
        //{
        //    isStunned = true;

        //    FreezeWarp warp = collision.gameObject.GetComponent<FreezeWarp>();
        //    warp.RemoveInSeconds(maxTimeBeforeStun);
        //}
    }
}
