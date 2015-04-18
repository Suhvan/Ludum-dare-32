using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        Application.LoadLevel(1);
    }

    public void onExit()
    {
        Application.Quit();
    }
}

