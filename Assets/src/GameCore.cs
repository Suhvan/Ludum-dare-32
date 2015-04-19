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

    private int _score;
    public int score 
    { 
        get {return _score;} 
        set 
        {
            _score = value;
            if (_score < looserScore || _score > winnerScore)
            {
                gameOver = true;
            }
        } 
    } 

    public bool Victorious 
    {
        get { return _score > winnerScore; }
    }

    public void OnRocketDisabled()
    {
        score++;
    }

    public void onUFODamaged()
    {
        score -= 5;
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
        AddDeadBody(city);
        score -= 10;
    }

    private void CheckGameover()
    {
        gameOver = leftCity.humans.noMoreLeft && rightCity.humans.noMoreLeft;
    }

    public void onExplosionStack()
    {
        score += 3;
    }

    

}

