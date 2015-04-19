using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class GameCore : MonoBehaviour
{

    public int looserScore = -100;
    public int winnerScore = 100;
    public HumanCity leftCity;
    public HumanCity rightCity;

    public bool gameOver = false;
	private static GameCore m_intance;
    public static GameCore instance
    {
        get
        {
			if (m_intance == null)
			{
				var gObj = new GameObject();
				m_intance = gObj.AddComponent<GameCore>();
                var cities = FindObjectsOfType<HumanCity>();
                if (cities.Length != 2)
                {
                    Debug.LogError("Defuq? can't find cites");
                }
                else                
                {
                    m_intance.leftCity = cities[0];
                    m_intance.rightCity = cities[1];
                }
			}
			return m_intance;
        }
    }

	private float m_stamina = 1.0f;
	public float stamina { get { return m_stamina; } set { m_stamina = Mathf.Clamp01(value); } }

	private bool m_onPause = false;
	public bool onPause { get { return m_onPause; } set 
	{ 
		m_onPause = value; 
		if (value)
			Time.timeScale = 0f;
		else
			Time.timeScale = 1f;
		}
	}

    private int _score;
    public int score 
    { 
        get {return _score;} 
        set 
        {
            _score = value;
        } 
    } 

    public bool TotalLoss 
    {
        get 
        {
            return leftCity.humans.allDead || rightCity.humans.allDead;
        }
    }

    public bool TotalWin
    {
        get
        {
            return leftCity.humans.allSurvive || rightCity.humans.allSurvive;
        }
    }

    public void OnRocketDisabled()
    {
        score++;
    }

    public void onUFODamaged()
    {
        stamina = 0;
    }

    public void onHumanDied(GameObject human)
    {
        var city = human.GetComponentInParent<HumanCity>();
        AddDeadBody(city);
    }

    public void onHumanSaved(GameObject human)
    {
       var city = human.GetComponentInParent<HumanCity>();
       city.humans.addHumanStatus(true);            
       CheckGameover();
    }

    private void AddDeadBody(HumanCity city)
    {
        if (!city.humans.noMoreLeft)
        {
            city.humans.addHumanStatus(false);
            if (city.humans.allDead)
            {
                gameOver = true;
            }
        }
        else
        {
            CheckGameover();
        }
    }
    

    public void onCityDamaged(GameObject cityHouses )
    {
        var city = cityHouses.GetComponentInParent<HumanCity>();
        if (city.HumanSpawnPoint.GetComponent<HumanSpawn>().CountUnspawned() > 0)
        {
            city.HumanSpawnPoint.GetComponent<HumanSpawn>().OnDamaged();
            AddDeadBody(city);
        }
    }

    private void CheckGameover()
    {
        gameOver = leftCity.humans.noMoreLeft && rightCity.humans.noMoreLeft;
    }

    public void onExplosionStack()
    {
        score += 2;
    }

    

}

