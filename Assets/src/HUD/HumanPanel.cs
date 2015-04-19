using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class HumanPanel : MonoBehaviour
{
    public List<SpriteRenderer> humanIcons;

    private List<bool> humanStats = new List<bool>();    

    public void addHumanStatus(bool survive)
    {
        if (humanStats.Count < humanIcons.Count)
            humanStats.Add(survive);
    }

    public bool noMoreLeft { get { return humanIcons.Count == humanStats.Count; } }

    public bool allDead 
    { 
        get 
        {
            return checkAllState(false);
        } 
    }

    public int survivalCount
    {
        get
        {
            return humanStats.Count(x => x == true);
        }
    }

    public int totalCount
    {
        get
        {
            return humanIcons.Count;
        }
    }

    public bool allSurvive
    {
        get
        {
            return checkAllState(false);
        }
    }

    private bool checkAllState(bool state2Check)
    {
        if (humanIcons.Count == humanStats.Count)
        {
            foreach (var survived in humanStats)
            {
                if (survived != state2Check)
                    return false;
            }
            return true;
        }
        return false;
    }

    void Update()
    {
        for (int i = 0; i < humanStats.Count; i++ )
        {
            if (humanStats[i])
            {
                humanIcons[i].color = Color.green;
            }
            else
            {
                humanIcons[i].color = Color.red;
            }
        }
    }
}

