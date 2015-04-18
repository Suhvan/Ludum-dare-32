﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class GameCore : MonoBehaviour
{
    public static GameCore instance
    {
        get
        {
            return FindObjectOfType<GameCore>();
        }
    }

    public int score = 0;


    public void OnRocketSpawn()
    {
        score++;
    }

    public void onCityDamaged()
    {
        score -= 10;
    }

}
