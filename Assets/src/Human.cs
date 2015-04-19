using UnityEngine;
using System.Collections;

public class Human : MonoBehaviour {

    public float walkSpeed = 5;

    GameObject destinationPoint;

    public GameObject parent;

    public Rigidbody2D rigidBody;

    private bool isCaptured;

    public bool IsCaptured
    {
        get
        {
            return isCaptured;
        }
        set
        {
            isCaptured = value;
            //rigidBody.isKinematic = isCaptured;
        }
    }

    public bool IsFalling
    {
        get
        {
            return rigidBody.velocity.y < -0.1f;
        }
    }

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
        if (!(IsCaptured || IsFalling))
        {
            //rigidBody.velocity = new Vector2(walkSpeed * Mathf.Sign(destinationPoint.transform.position.x - transform.position.x), rigidBody.velocity.y);
            rigidBody.AddForce(new Vector2(walkSpeed * Mathf.Sign(destinationPoint.transform.position.x - transform.position.x), rigidBody.velocity.y));
        }
	}
}
