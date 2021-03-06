﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class HUD : MonoBehaviour
{
    public TopPanel topPanel;
    public PauseMenu pauseMenu;
    public Debrief debrief;
    public AdvisePanel advicePanel;

    private bool overed = false;

    void Update()
    {
        if (overed)
            return;

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseMenu.gameObject.SetActive(true);
			GameCore.instance.onPause = true;
            advicePanel.Show();
        }
        else if (GameCore.instance.gameOver)
        {
            overed = true;
            debrief.SetResult();
            advicePanel.Show();
        }

        topPanel.score.text = GameCore.instance.score.ToString();
		topPanel.stamina.value = GameCore.instance.stamina;
    }

    public void ClickSound()
    {
        gameObject.GetComponent<AudioSource>().gameObject.SetActive(true);
        gameObject.GetComponent<AudioSource>().Play();
    }

}

