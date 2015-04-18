using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class HUD : MonoBehaviour
{
    public TopPanel topPanel;


    void Update()
    {
        topPanel.score.text = GameCore.instance.score.ToString();
    }
}

