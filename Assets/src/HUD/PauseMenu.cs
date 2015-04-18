using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class PauseMenu : MonoBehaviour
{
    public void onResume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);        
    }

    public void onExit()
    {
        Application.Quit();
    }

    public void onRestart()
    {
        Time.timeScale = 1;
        Application.LoadLevel(1);
    }
}

