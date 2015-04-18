using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class HumanCity : MonoBehaviour
{
    public float rocketSpawnCD;
    public float rocketSpawnClock;
    private bool preEffectShown = false;

    public GameObject RocketPref;
    public GameObject SpawnPoint;
    public GameObject PreRocketSpawnPref;
    public GameObject TargetPoint;

    void Update () 
    {
        rocketSpawnClock += Time.deltaTime;
        if( rocketSpawnClock > rocketSpawnCD )
        {
            SpawnRocket();
            rocketSpawnClock = 0;
            preEffectShown = false;
        }

        if( rocketSpawnCD - rocketSpawnClock < PreRocketSpawnPref.GetComponent<ParticleSystem>().duration && !preEffectShown )
        {
            preEffectShown = true;
            Instantiate( PreRocketSpawnPref, SpawnPoint.transform.position, SpawnPoint.transform.rotation );
        }
    }

    private float p2(float x)
    {
        return Mathf.Pow(x, 2);
    }

    private float p4(float x)
    {
        return Mathf.Pow(x, 4);
    }

    private Vector2 RocketImpulse()
    {
        float height = 3 + Random.value * 8;

        float distance = Mathf.Abs(TargetPoint.transform.position.x - transform.position.x) - Random.value * 10;

        float direction = Mathf.Sign(TargetPoint.transform.position.x - transform.position.x);

        float gravity = 9.81f;

        float V0y = Mathf.Sqrt(2 * gravity * height);
        float time = V0y / gravity * 2;
        float V0x = distance / time;
        return new Vector2(V0x * direction, V0y);
    }

    private void SpawnRocket()
    {
        GameObject rocket = Instantiate(RocketPref, SpawnPoint.transform.position, new Quaternion(0,0,0,0)) as GameObject;
        Thrust thrust = rocket.GetComponent<Thrust>();

        

        thrust.SetImpulse(RocketImpulse());
        //Debug.Log("Pew-pew");
        GameCore.instance.OnRocketSpawn();
    }


}