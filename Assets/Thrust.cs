using UnityEngine;
using System.Collections;

public class Thrust : MonoBehaviour
{

    public Rigidbody2D rigidBody;

    public float thrust = 10;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void SetImpulse(Vector2 velocity)
    {
        
        rigidBody.velocity = velocity;
    }

    void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 moveDirection = rigidBody.velocity;
        if (moveDirection.magnitude > 2)
        {
            float angle = Mathf.Atan2(-moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        //var rotation = Quaternion.LookRotation(transform.up);
        //float dirx = rotation.y;
        //float diry = -rotation.x;
        //Debug.Log(string.Format("{0} {1}", dirx, diry));
        //rigidBody.AddForce(new Vector2(dirx, diry) * thrust);
    }
}
