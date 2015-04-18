using UnityEngine;
using System.Collections;

public class Human : MonoBehaviour {

    public float walkSpeed = 5;

    GameObject destinationPoint;

    Rigidbody2D rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void SetDestination(GameObject destinationPoint)
    {
        this.destinationPoint = destinationPoint;
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        rigidBody.velocity = new Vector2(walkSpeed * Mathf.Sign(destinationPoint.transform.position.x - transform.position.x), rigidBody.velocity.y);
	}
}
