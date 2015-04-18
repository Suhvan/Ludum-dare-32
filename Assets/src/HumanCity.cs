using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class HumanCity : MonoBehaviour
{
    public float rocketSpawnCD;
    public float rocketSpawnClock;

    public GameObject RocketPref;
    public GameObject SpawnPoint;   

    void Update () 
    {
        rocketSpawnClock += Time.deltaTime;
        if (rocketSpawnClock > rocketSpawnCD)
        {
            SpawnRocket();
            rocketSpawnClock = 0;
        }    
    }


    private void SpawnRocket()
    {
        Instantiate(RocketPref, SpawnPoint.transform.position, new Quaternion(0,0,0,0));
        Debug.Log("Pew-pew");
    }


}