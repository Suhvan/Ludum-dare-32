using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


class Debrief : MonoBehaviour
{

    public Text summary;

    public Text leftCityStats;

    public Text rightCityStats;

    public void SetResult()
    {
		GameCore.instance.onPause = true;

        if (GameCore.instance.TotalLoss)
        {
            summary.text = "Entire city population wasted!";
        }
        else if (GameCore.instance.TotalWin)
        {
            summary.text = "Wow, you saved everyone!";
        }
        else
        {
            summary.text = "You could save more people...";
        }

        leftCityStats.text = string.Format("{0}/{1} millions", GameCore.instance.leftCity.humans.survivalCount, GameCore.instance.leftCity.humans.totalCount);
        rightCityStats.text = string.Format("{0}/{1} millions", GameCore.instance.rightCity.humans.survivalCount, GameCore.instance.rightCity.humans.totalCount);

        this.gameObject.SetActive(true);
    }
    
}

