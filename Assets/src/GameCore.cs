using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class GameCore : MonoBehaviour
{
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

    public int score = 0;

    public void OnRocketSpawn()
    {
        score++;
    }

    public void onCityDamaged()
    {
        score -= 10;
    }

}

