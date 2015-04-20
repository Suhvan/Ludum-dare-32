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
    public int seconds=3;

    private string[] advices = {"Save people! Harvest them with your gravitygun (LMB)",
        "When rocket hits city, it kills people.",
        "You are not immortal!",
        "It's not a cat!",
        "Redirect rockets using your gravitygun (LMB)",
        "Red rockets aims at YOU!",
        "There is gravitygun (LMB) charge at top left corner",
        "You must save everyone!",
        "Don't let people die!"};

    void Start()
    {
        advice.text = advices[UnityEngine.Random.Range(0, advices.Length - 1)];
        StartCoroutine(Hider());
    }

    System.Collections.IEnumerator Hider()
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);     
    }
}

