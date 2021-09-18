using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDemon : MonoBehaviour
{
    public Transform textPrefab;
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    private float speedX = 0.15f;
    private float speedY = 0.03f;
    private float instantiationSpeed = 1.2f;

    void Start()
    {
        InvokeRepeating("ThrowText", 0, instantiationSpeed);
        minX = transform.position.x - 7;
        maxX = transform.position.x + 7;
        minY = transform.position.y - 0.75f;
        maxY = transform.position.y + 0.75f;
    }

    void FixedUpdate()
    {
        if (Game.CanPlay())
        {
            Move();
        }
    }

    void Move()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;
        if (posX < minX || posX > maxX)
        {
            speedX = -speedX;
        }
        if (posY < minY || posY > maxY)
        {
            speedY = -speedY;
        }
        transform.position += new Vector3(speedX, speedY, 0);
    }

    void ThrowText()
    {
        if (Game.CanPlay())
        {
            Transform newText = Instantiate(textPrefab, new Vector2(transform.position.x - 1.0f, transform.position.y + 1.0f), Quaternion.identity);
            newText.GetComponent<Rigidbody2D>().AddForce(new Vector2(2000 * speedX, 400));
        }
    }
}
