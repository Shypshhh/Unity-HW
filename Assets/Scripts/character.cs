using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    float timeInStun = 0.0f;
    bool isStunned;

    float minX;
    float minY;
    float maxX;
    float maxY;
    GameControl gameControl;

    public int numberOfConsts;
    public string playerName;
    public float moveSpeed = 20f;
    public KeyCode playerButton;

    public float maxStunTime = 2.0f;

    private void Start()
    {
        gameControl = FindObjectOfType<GameControl>();
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
            timeInStun += Time.deltaTime;
            if (timeInStun >= maxStunTime)
            {
                timeInStun = 0.0f;
                isStunned = false;
            }

            return;
        }

        transform.position += new Vector3(Input.GetAxis(playerName + "Horizontal"), Input.GetAxis(playerName + "Vertical"), 0f)
        * Time.deltaTime
        * moveSpeed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), 0f);
    }

    public void Stun(float seconds)
    {
        isStunned = true;
        maxStunTime = seconds;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Warp"))
        {
            gameControl.FreezeOtherPlayers(playerName);
            Destroy(collision.gameObject);
        }
    }
}
