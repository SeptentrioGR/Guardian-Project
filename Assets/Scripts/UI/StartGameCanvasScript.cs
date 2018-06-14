﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameCanvasScript : MonoBehaviour {
    public Button StartButton;

	// Use this for initialization
	void Start () {
        StartButton.onClick.AddListener(() =>
        {
            StartGameButton();
        });

    }
	public void StartGameButton()
    {
        Game.Instance.StartGame();
    }
}
