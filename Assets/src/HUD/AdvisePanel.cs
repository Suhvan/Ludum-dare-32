using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


class AdvisePanel : MonoBehaviour
{
    public Text advice;

    private string[] advices = {"Save people! Harvest them with your tractor beam (LMB)",
        "When rocket hits city, it kills people.",
        "You are not immortal!",
        "Redirect rockets using your tractor beam (LMB)",
        "Red rockets aims at YOU!",
        "There is tractor beam (LMB) charge at top left corner",
        "You must save everyone!",
        "Don't let people die!"};
    

    public void Show()
    {
        gameObject.SetActive(true);
        advice.text = advices[UnityEngine.Random.Range(0, advices.Length - 1)];
    }


    public void Hide()
    {
        gameObject.SetActive(false);
    }

}

