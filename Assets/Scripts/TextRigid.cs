using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRigid : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "ground")
    {
      Destroy(gameObject);
    }
  }
}
