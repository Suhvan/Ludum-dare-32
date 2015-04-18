using UnityEngine;
using System.Collections;

public class Thrust : MonoBehaviour
{

    Rigidbody2D rigidBody;

    public float thrust = 10;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(4, 9);
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collision");
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collision");
    }

    void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 moveDirection = rigidBody.velocity;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(-moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }
}
