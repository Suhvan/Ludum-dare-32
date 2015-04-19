using UnityEngine;
using System.Collections;

public class RocketLauncher : MonoBehaviour {

    public float rocketSpawnCD = 2;
    public float rocketSpawnClock;
    public float gravitySpread = 10;
    private bool preEffectShown = false;

    public GameObject RocketPref;
    public GameObject RocketSpawnPoint;
    public GameObject PreRocketSpawnPref;
    public GameObject TargetPoint;
    public GameObject UFO;
    public float UFOTargetProbability = 0.1f;
    

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
            Instantiate(PreRocketSpawnPref, RocketSpawnPoint.transform.position, RocketSpawnPoint.transform.rotation);
        }


    }

    private Vector2 RocketImpulse(Thrust tr, Vector2 targetPos, float DistanceSpread = 0, float MinHeight = 0, float MaxHeight = 0)
    {

        //Vector2 targetPos = TargetPoint.transform.position;
        Vector2 startPos = RocketSpawnPoint.transform.position;

        float absoluteHeight = Mathf.Abs(MinHeight + Random.value * (MaxHeight - MinHeight)) + Mathf.Min(startPos.y, targetPos.y);
        float dx = targetPos.x - startPos.x;
        float distance = Mathf.Abs(dx) + (Random.value - 0.5f) * DistanceSpread;

        absoluteHeight = Mathf.Max(absoluteHeight, targetPos.y, startPos.y);

        float direction = Mathf.Sign(dx);

        float gravity = -Physics2D.gravity.y * tr.rigidBody.gravityScale;

        float V0y = Mathf.Sqrt(2 * gravity * (absoluteHeight - startPos.y));
        float timeup = V0y / gravity;

        float timedown = Mathf.Sqrt(2 * (absoluteHeight - targetPos.y) / gravity);

        float V0x = distance / (timeup + timedown);
        return new Vector2(V0x * direction, V0y);
    }

    private void SpawnRocket()
    {
        GameObject rocket = Instantiate(RocketPref, RocketSpawnPoint.transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
        Thrust thrust = rocket.GetComponent<Thrust>();
        thrust.rigidBody.gravityScale = Random.value * gravitySpread + 1;

        if (Random.value >= UFOTargetProbability)
        {
            thrust.SetImpulse(RocketImpulse(thrust, TargetPoint.transform.position, DistanceSpread, MinHeight, MaxHeight));
        }
        else
        {
            thrust.SetImpulse(RocketImpulse(thrust, UFO.transform.position));
        }

    }

}
