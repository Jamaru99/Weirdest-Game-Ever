using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Emoji : MonoBehaviour
{
  private GameObject wings;
  private AudioSource audioSource;
  private CircleCollider2D circleCollider;
  private bool canFly = false;
  private float flySpeed = 0.2f;

  void Start()
  {
    audioSource = GetComponent<AudioSource>();
    circleCollider = GetComponent<CircleCollider2D>();
    if (Game.EmojiCollected(gameObject.name))
    {
      Destroy(gameObject);
    }
    wings = transform.GetChild(0).gameObject;
  }

  void FixedUpdate()
  {
    if (canFly)
    {
      Fly();
    }
    if (transform.position.y > 100)
    {
      Destroy(gameObject);
    }
  }

  private void Fly()
  {
    transform.position += new Vector3(0, flySpeed, 0);
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      circleCollider.enabled = false;
      canFly = true;
      wings.SetActive(true);
      audioSource.Play();
      Game.CollectEmoji(gameObject.name);
    }
  }
}
