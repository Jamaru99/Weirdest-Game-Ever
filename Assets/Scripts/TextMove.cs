using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMove : MonoBehaviour
{
  private float destructionPoint;
  private float speed = -0.15f;

  void Awake()
  {
    destructionPoint = transform.position.x - 25;
  }

  void FixedUpdate()
  {
    transform.position += new Vector3(speed, 0, 0);
    if (transform.position.x < destructionPoint)
    {
      Destroy(gameObject);
    }
  }
}
