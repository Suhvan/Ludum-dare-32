using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class MainMenu : MonoBehaviour
{

    public GameObject aboutWindow;

    public void StartGame()
    {
        Application.LoadLevel(1);
    }

    public void onAboutEnabled()
    {
        aboutWindow.SetActive(true);
    }

    public void onAboutDisabled()
    {
        aboutWindow.SetActive(false);
    }

    public void onExit()
    {
        Application.Quit();
    }

    public void ClickSound()
    {
        gameObject.GetComponent<AudioSource>().gameObject.SetActive(true);
        gameObject.GetComponent<AudioSource>().Play();
    }
}

