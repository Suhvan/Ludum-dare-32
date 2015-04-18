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
    public GameObject TargetPoint;

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
        GameObject rocket = Instantiate(RocketPref, SpawnPoint.transform.position, new Quaternion(0,0,0,0)) as GameObject;
        Thrust thrust = rocket.GetComponent<Thrust>();



        thrust.SetImpulse(new Vector2((7 + Random.value * 12) * Mathf.Sign(TargetPoint.transform.position.x - transform.position.x), 4 + Random.value * 5));
        //Debug.Log("Pew-pew");
    }


}