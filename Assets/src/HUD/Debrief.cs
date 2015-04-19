using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


class Debrief : MonoBehaviour
{

    public Text result;

    public void SetResult(bool won)
    {
		GameCore.instance.onPause = true;

        if (won)
        {
            result.text = "You won!";
        }
        else
        {
            result.text = "You lost!";
        }
        this.gameObject.SetActive(true);
    }
    
}

