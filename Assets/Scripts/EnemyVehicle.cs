using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVehicle : MonoBehaviour
{
    private float speed = 0.2f;
    private float direction = 1;

    void FixedUpdate()
    {
        if (Game.CanPlay())
        {
            transform.position += new Vector3(speed * direction, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ground")
        {
            direction = -direction;
        }
    }
}
