using UnityEngine;
using System.Collections;

public class Thrust : MonoBehaviour {

    Rigidbody2D rigidBody;

    public float thrust = 10;

	void Start () 
	{
        
	}
	

    void FixedUpdate()
    {
        
    }

	void Update () 
	{
        rigidBody.AddForce(transform.forward * thrust);
	}
}
