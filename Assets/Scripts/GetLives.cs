using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class GetLives : MonoBehaviour
{
    RewardBasedVideoAd rbva;
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;
    private TextMeshPro adText;
    private TextMeshPro adButtonText;
    string adId = "ca-app-pub-1541045839364233/7361453181";

    void Start()
    {
        rbva = RewardBasedVideoAd.Instance;
        rbva.OnAdRewarded += HandleRewardBasedVideoRewarded;
        rbva.OnAdClosed += HandleAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        rbva.LoadAd(request, adId);

        adText = GameObject.Find("AdText").GetComponent<TextMeshPro>();
        adButtonText = GameObject.Find("AdButtonText").GetComponent<TextMeshPro>();
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    public void HandleAdClosed(object sender, EventArgs args)
    {
        AdRequest request = new AdRequest.Builder().Build();
        rbva.LoadAd(request, adId);
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        Game.life = 25;
		Game.lifeText.text = "x25";
        PlayerPrefs.SetInt("life", 25);
		adText.enabled = false;
		adButtonText.enabled = false;
    }

    void Update()
    {
        if (Game.CanPlay())
        {
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
			adButtonText.enabled = false;
			adText.enabled = false;
        }
        else
        {
            meshRenderer.enabled = true;
            boxCollider.enabled = true;
			adButtonText.enabled = true;
			adText.enabled = true;
        }
    }

    void OnMouseDown()
    {
        transform.localScale *= 0.9f;
    }

    void OnMouseUp()
    {
        if (rbva.IsLoaded())
            rbva.Show();
        transform.localScale /= 0.9f;
    }
}
