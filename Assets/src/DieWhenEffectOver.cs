using UnityEngine;
using System.Collections;

public class DieWhenEffectOver : MonoBehaviour {

	//
    void Start()
    {
        Destroy( gameObject, GetComponent<ParticleSystem>().duration );
	}
	
}
