using UnityEngine;
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

    GameObject destinationPoint;

    public Rigidbody2D rigidBody;

    private bool isCaptured;

    public float DeadSpeed = 120;

    private float prevSpeed = 0;

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
        anim = GetComponent<Animator>();
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
            var sign = Mathf.Sign(destinationPoint.transform.position.x - transform.position.x);
            if(sign>0)
            {
                state = AnimatorState.RIGTH;
            }
            else
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
                GameCore.instance.onHumanSaved(gameObject);
                Destroy(gameObject);
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
}

/*
 using UnityEngine;
using System.Collections;

public class CollisionExplosion : MonoBehaviour {

    //
    [SerializeField]
    GameObject ExplosionPref;

    public float armDelay;

    private float spawnTime;

    //
    void Start()
    {
        spawnTime = Time.time;
    }

    //
    void OnCollisionEnter2D( Collision2D col )
    {
        if (armDelay + spawnTime > Time.time)
            return;

     
        switch(col.collider.gameObject.name)
        {
            case "Houses":
                GameCore.instance.onCityDamaged(col.collider.gameObject);
                break;
            case "Rocket(Clone)":
                GameCore.instance.onExplosionStack();
                break;
            case "UFO":
                GameCore.instance.onUFODamaged();
                break;
            default:
                GameCore.instance.OnRocketDisabled();
                Debug.Log(string.Format("Collision with {0}", col.collider.gameObject.name));
                break;

        }
        
        Explode( col.contacts[ 0 ].point );
        Destroy( gameObject );
    }

    void OnCollisionStay2D(Collision2D col)
    {
        OnCollisionEnter2D(col);
    }


    //
    void Explode( Vector2 pos )
    {
        Instantiate( ExplosionPref, pos, new Quaternion( 0, 0, 0, 0 ) );
    }
}

 */
