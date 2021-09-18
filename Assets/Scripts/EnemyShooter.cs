using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Transform textPrefab;
    private float instantiationSpeed = 1.5f;

    void Start()
    {
        InvokeRepeating("Shoot", 0, instantiationSpeed);
    }

    void Shoot()
    {
        if (Game.CanPlay())
        {
            Transform newText = Instantiate(textPrefab, new Vector2(transform.position.x - 0.7f, transform.position.y - 0.3f), transform.rotation);
        }
    }
}
