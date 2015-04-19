using UnityEngine;
using System.Collections;

public class FixHeight : MonoBehaviour {

	private float fixedHeight;

	[SerializeField]
	private ParticleSystem ps;

	public Vector3 gpPosition;

	void Awake()
	{
		fixedHeight = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		var oldPos = this.transform.position;
		oldPos.Set(oldPos.x, fixedHeight, oldPos.z);
		this.transform.position = oldPos;
		ps.startLifetime = (gpPosition - this.transform.position).sqrMagnitude / 150f;

		 ParticleSystem.Particle []ParticleList = new ParticleSystem.Particle[ps.particleCount];
         ps.GetParticles(ParticleList);
         for(int i = 0; i < ParticleList.Length; ++i)
         {
			 if (ParticleList[i].position.y > gpPosition.y)
			 {
				 ParticleList[i].lifetime = 0f;
			 }
         }

		 ps.SetParticles(ParticleList, ps.particleCount);

		//Debug.Log((gpPosition - this.transform.position).sqrMagnitude);
	}
}
