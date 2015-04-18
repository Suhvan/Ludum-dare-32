using UnityEngine;
using System.Collections;

public class Thrust : MonoBehaviour {

    Rigidbody2D rigidBody;

    public float thrust = 10;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	

    void FixedUpdate()
    {
        
    }

	// Update is called once per frame
	void Update () {
        rigidBody.AddForce(transform.forward * thrust);
	}
}
