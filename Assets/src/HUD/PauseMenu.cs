using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class PauseMenu : MonoBehaviour
{
    public void onResume()
    {
		GameCore.instance.onPause = false;
        gameObject.SetActive(false);        
    }

    public void onExit()
    {
        Application.Quit();
    }

    public void onRestart()
    {
		GameCore.instance.onPause = false;
        Application.LoadLevel(1);
    }
}

