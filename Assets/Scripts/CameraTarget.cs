using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
  private Transform playerPosition;
  private float playerDistance = 1.2f;

  void Start()
  {
    playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
  }

  void FixedUpdate()
  {
    float posY = transform.position.y;
    float playerPosY = playerPosition.transform.position.y;
    if (playerPosY - posY < -playerDistance)
    {
      posY = playerPosY + playerDistance;
    }
    if (playerPosY - posY > playerDistance)
    {
      posY = playerPosY - playerDistance;
    }
    transform.position = new Vector2(playerPosition.transform.position.x, posY);
  }
}
