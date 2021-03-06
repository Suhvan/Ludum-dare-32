﻿using UnityEngine;
using System.Collections;

public class Human : MonoBehaviour {

    private enum AnimatorState 
    {
        RIGTH=0,
        LEFT=1,
        VERTICAL=2,
        STAND=3
    }
    private AnimatorState _state;
    private AnimatorState state 
    {
        set
        {
            if (_state != value)
            {
                _state = value;
                anim.SetInteger("State", (int)_state);
            }
        }
    }

    public Animator anim;

    public float walkSpeed = 5;

    public GameObject ExplosionPref;

    public Rigidbody2D rigidBody;

    private bool isCaptured;

    public float DeadSpeed = 120;

    private float prevSpeed = 0;

    private float destinationX = 0;

    public GameObject ExplosionSave;

    public bool IsCaptured
    {
        get
        {
            return isCaptured;
        }
        set
        {
            if (isCaptured && !value)
            {
                rigidBody.velocity = Vector2.zero;
            }
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
        anim = GetComponent<Animator>();
    }

    public void SetDestination(float x)
    {
        destinationX = x;
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (!(IsCaptured || IsFalling))
        {
            //rigidBody.velocity = new Vector2(walkSpeed * Mathf.Sign(destinationPoint.transform.position.x - transform.position.x), rigidBody.velocity.y);
            float dx = destinationX - transform.position.x;
            float sign = Mathf.Sign(dx);

            if(Mathf.Abs(dx) < 0.1f)
            {
                state = AnimatorState.STAND;
            }
            else if (sign > 0)
            {
                state = AnimatorState.RIGTH;
            }
            else if (sign < 0)
            {
                state = AnimatorState.LEFT;
            }

            rigidBody.AddForce(new Vector2(walkSpeed * sign, rigidBody.velocity.y));
        }
        else
        {
            state = AnimatorState.VERTICAL;
        }

        float speed = rigidBody.velocity.sqrMagnitude;
        if (Mathf.Abs(prevSpeed - speed) > DeadSpeed && !isCaptured)
        {
            Debug.LogWarning("Human died crashed " + Mathf.Abs(prevSpeed - speed));
            Die(transform.position);          
        }
        prevSpeed = speed;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.collider.gameObject.name)
        {
            case "Rocket(Clone)":                
                Die(col.contacts[0].point);                
                break;
            case "UFO":
                Save(col.contacts[0].point);
                break;
            case "Ground":
                if (rigidBody.velocity.sqrMagnitude > DeadSpeed)
                {
                    Die(col.contacts[0].point);
                }
                break;
            default:
                Debug.Log(string.Format("Collision with {0}", col.collider.gameObject.name));
                break;

        }
    }

    void Die(Vector2 pos)
    {
        GameCore.instance.onHumanDied(gameObject);
        Instantiate(ExplosionPref, pos, new Quaternion(0, 0, 0, 0));
        Destroy(gameObject);
    }

    void Save(Vector2 pos)
    {
        GameCore.instance.onHumanSaved(gameObject);        
        Instantiate(ExplosionSave, pos, new Quaternion(0, 0, 0, 0));
        Destroy(gameObject);
    }
}

