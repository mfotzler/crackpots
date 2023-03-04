using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameStats : NetworkBehaviour
{
    public NetworkVariable<int> lives = new(3);
    public NetworkVariable<int> score = new(0);
    public NetworkVariable<int> highScore = new(0);
    static GameStats instance;

    public static NetworkVariable<int> Lives => instance.lives;
    public static NetworkVariable<int> Score => instance.score;
    public static NetworkVariable<int> HighScore => instance.highScore;

    public static void WhatAGoal()
    {
        if (instance.IsServer)
            Score.Value++;
    }

    void Update()
    {
        if (!IsServer)
            return;

        if (lives.Value == 0)
            UpdateHighScoreAndResetLives();
    }

    private void UpdateHighScoreAndResetLives()
    {
        if (score.Value > highScore.Value)
            highScore.Value = score.Value;

        lives.Value = 3;
        score.Value = 0;
    }

    void Awake()
    {
        instance = this;
    }
}
