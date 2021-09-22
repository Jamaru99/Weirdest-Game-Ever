using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  private GameObject wings;
  private Rigidbody2D rigidBody;
  private AudioSource audioSource;
  public Joystick joystick;

  private float speed = 9.0f;
  private int flyForce = 50;
  private int jumpForce = 450;
  private float horizontal;
  public float minX;
  public float maxX;

  void Start()
  {
    wings = transform.GetChild(0).gameObject;
    rigidBody = GetComponent<Rigidbody2D>();
    audioSource = GetComponent<AudioSource>();
    if (Game.warped && Game.currentSceneIndex == 0)
    {
      transform.position = new Vector2(79, -27);
      rigidBody.AddForce(new Vector2(0, jumpForce));
    }
  }

  void FixedUpdate()
  {
    if (Game.CanPlay())
    {
      Move();
      HandleFlight();
    }
  }

  private void Move()
  {
    horizontal = joystick.Horizontal;
    float amtToMove = horizontal * speed * Time.deltaTime;
    transform.Translate(Vector3.right * amtToMove);
    transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y);
  }

  private void Jump()
  {
    rigidBody.AddForce(new Vector2(0, jumpForce));
  }

  private void HandleFlight()
  {
    for (int i = 0; i < Input.touchCount; i++)
    {
      if (Input.GetTouch(i).position.x > Screen.width / 2.6f)
      {
        wings.SetActive(true);
        rigidBody.AddForce(new Vector2(0, flyForce));
        break;
      }
      else
      {
        wings.SetActive(false);
      }
    }
    if (Input.touchCount == 0)
    {
      wings.SetActive(false);
    }
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "ground")
    {
      if (Game.CanPlay())
      {
        Jump();
      }
    }
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "text")
    {
      audioSource.Play();
      Game.DecreaseLife();
    }
    if (other.name == "Warp")
    {
      Game.ChangeScene();
    }
  }
}
