using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class GameCore : MonoBehaviour
{

    public int looserScore = -100;
	private static GameCore m_intance;
    public static GameCore instance
    {
        get
        {
			if (m_intance == null)
			{
				var gObj = new GameObject();
				m_intance = gObj.AddComponent<GameCore>();
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
            if (_score < looserScore)
            {
                Time.timeScale = 0;
            }
        } 
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

    public void onCityDamaged()
    {
        score -= 10;
    }

    public void onExplosionStack()
    {
        score += 3;
    }

}

