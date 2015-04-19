using UnityEngine;
using System.Collections;

public class PukingPower : MonoBehaviour {

	public float emissionMod = 1.0f;
	public float speedMod = 1.0f;

    private float baseEmissionRate;
    private float baseParticleSpeed;

    public ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>() as ParticleSystem;
        baseEmissionRate = ps.emissionRate;
        baseParticleSpeed = ps.startSpeed;
    }

	public void ApplyThrust( Vector2 power )
	{
        float powerF = power.magnitude;

        ParticleSystem ps = GetComponent<ParticleSystem>() as ParticleSystem;

        float angle = Mathf.Atan2(-power.x, power.y) * Mathf.Rad2Deg;
        ps.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        ps.emissionRate = baseEmissionRate * powerF * emissionMod;
        ps.startSpeed = baseParticleSpeed * powerF * speedMod;
	}
}
