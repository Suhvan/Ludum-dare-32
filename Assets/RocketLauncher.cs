using UnityEngine;
using System.Collections;

public class RocketLauncher : MonoBehaviour {

    public float rocketSpawnCD = 2;
    public float rocketSpawnClock = 0;
    private bool preEffectShown = false;

    public GameObject RocketPref;
    public GameObject SpawnPoint;
    public GameObject PreRocketSpawnPref;
    public GameObject TargetPoint;

    public float MinHeight = 2;
    public float MaxHeight = 13;

    public float DistanceSpread = 5;

    void Update()
    {
        rocketSpawnClock += Time.deltaTime;
        if (rocketSpawnClock > rocketSpawnCD)
        {
            SpawnRocket();
            rocketSpawnClock = 0;
            preEffectShown = false;
        }

        if (rocketSpawnCD - rocketSpawnClock < PreRocketSpawnPref.GetComponent<ParticleSystem>().duration && !preEffectShown)
        {
            preEffectShown = true;
            Instantiate(PreRocketSpawnPref, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        }
    }

    private Vector2 RocketImpulse()
    {


        float height = Mathf.Abs(MinHeight + Random.value * (MaxHeight - MinHeight));

        float dx = TargetPoint.transform.position.x - SpawnPoint.transform.position.x;

        float distance = Mathf.Abs(dx) + (Random.value - 0.5f) * DistanceSpread;

        float direction = Mathf.Sign(dx);

        float gravity = -Physics2D.gravity.y;

        float V0y = Mathf.Sqrt(2 * gravity * height);
        float time = V0y / gravity * 2;
        float V0x = distance / time;
        return new Vector2(V0x * direction, V0y);
    }

    private void SpawnRocket()
    {
        GameObject rocket = Instantiate(RocketPref, SpawnPoint.transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
        Thrust thrust = rocket.GetComponent<Thrust>();
        thrust.SetImpulse(RocketImpulse());
    }

}
