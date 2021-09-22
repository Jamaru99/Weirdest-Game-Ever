using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
  public static Text lifeText;
  public static Text emojiText;
  public static int life = 30;
  public static int totalEmojis = 0;
  public static int maxEmojis = 16;
  public static int currentSceneIndex = 0;
  public static bool warped = false;

  void Start()
  {
    TranslateIfNecessary();
    lifeText = GameObject.Find("LifeText").GetComponent<Text>();
    emojiText = GameObject.Find("EmojiText").GetComponent<Text>();
    if (PlayerPrefs.HasKey("life"))
    {
      life = PlayerPrefs.GetInt("life");
    }
    if (PlayerPrefs.HasKey("totalEmojis"))
    {
      totalEmojis = PlayerPrefs.GetInt("totalEmojis");
    }
    lifeText.text = "x" + life;
    emojiText.text = "x" + totalEmojis + "/" + maxEmojis;
    if (totalEmojis >= maxEmojis)
    {
      GameObject.Find("ChosenText").GetComponent<TextMeshPro>().text = "game over";
    }
  }

  public static void ChangeScene()
  {
    Scene scene = SceneManager.GetActiveScene();
    warped = true;
    if (scene.name == "Top")
    {
      currentSceneIndex = 1;
      SceneManager.LoadScene("Bottom");
    }
    if (scene.name == "Bottom")
    {
      currentSceneIndex = 0;
      SceneManager.LoadScene("Top");
    }
  }

  public static void CollectEmoji(string emojiName)
  {
    totalEmojis += 1;
    emojiText.text = "x" + totalEmojis + "/" + maxEmojis;
    PlayerPrefs.SetInt("totalEmojis", totalEmojis);
    PlayerPrefs.SetInt(emojiName, 1);
    if (totalEmojis == maxEmojis)
    {
      Destroy(GameObject.Find("Warp"));
      Destroy(GameObject.Find("EnemyDemon"));
      Destroy(GameObject.Find("EnemyShooter"));
      Destroy(GameObject.Find("EnemyBike"));
      Destroy(GameObject.Find("EnemyPlane"));
      GameObject.Find("ChosenText").GetComponent<TextMeshPro>().text = "GAME OVER";
    }
  }

  public static bool EmojiCollected(string emojiName)
  {
    return PlayerPrefs.HasKey(emojiName);
  }

  public static bool CanPlay()
  {
    return life > 0;
  }

  public static void DecreaseLife()
  {
    life -= 1;
    lifeText.text = "x" + life;
    PlayerPrefs.SetInt("life", life);
  }

  private void TranslateIfNecessary()
  {
    Scene scene = SceneManager.GetActiveScene();
    bool isPortuguese = Application.systemLanguage == SystemLanguage.Portuguese;
    if (isPortuguese)
    {
      if (scene.name == "Top")
      {
        GameObject.Find("ChosenText").GetComponent<TextMeshPro>().text = "evite textos";
        GameObject.Find("ChosenText2").GetComponent<TextMeshPro>().text = "liberte   emojis";
      }
      GameObject.Find("AdText").GetComponent<TextMeshPro>().text = "Assista um video para continuar jogando";
      GameObject.Find("AdButtonText").GetComponent<TextMeshPro>().text = "assistir";
    }
  }
}
