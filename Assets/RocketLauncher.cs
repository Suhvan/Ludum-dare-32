using UnityEngine;
using System.Collections;

public class RocketLauncher : MonoBehaviour {

    public float rocketSpawnCD = 2;
    public float rocketSpawnClock;
    public float gravitySpread = 10;
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

    private Vector2 RocketImpulse(Thrust tr)
    {

        Vector2 targetPos = TargetPoint.transform.position;
        Vector2 startPos = SpawnPoint.transform.position;

        float height = Mathf.Abs(MinHeight + Random.value * (MaxHeight - MinHeight)) + Mathf.Min(startPos.y, targetPos.y);


        height = Mathf.Max(height, targetPos.y, startPos.y);

        float dx = targetPos.x - startPos.x;

        float distance = Mathf.Abs(dx) + (Random.value - 0.5f) * DistanceSpread;

        float direction = Mathf.Sign(dx);

        float gravity = -Physics2D.gravity.y * tr.rigidBody.gravityScale;

        float V0y = Mathf.Sqrt(2 * gravity * (height - startPos.y));
        float timeup = V0y / gravity;

        float timedown = Mathf.Sqrt(2 * (height - targetPos.y) / gravity);

        float V0x = distance / (timeup + timedown);
        return new Vector2(V0x * direction, V0y);
    }

    private void SpawnRocket()
    {
        GameObject rocket = Instantiate(RocketPref, SpawnPoint.transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
        Thrust thrust = rocket.GetComponent<Thrust>();
        thrust.rigidBody.gravityScale = Random.value * gravitySpread + 1;
        thrust.SetImpulse(RocketImpulse(thrust));
    }

}
